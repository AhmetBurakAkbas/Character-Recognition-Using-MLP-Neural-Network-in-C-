using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YSA_Project
{
    public partial class Form1 : Form
    {
        private Button[,] matrixButtons = new Button[7, 5];
        private int[,] matrixState = new int[7, 5];
        private NeuralNetwork nn;
        private bool isTrained = false;

        public Form1()
        {
            InitializeComponent();
            CreateMatrixButtons();
            btnClear.Click += BtnClear_Click;
            btnTrain.Click += BtnTrain_Click;
            btnTest.Click += BtnTest_Click;
        }

        private void CreateMatrixButtons()
        {
            int btnSize = 40;
            int spacing = 2;
            for (int row = 0; row < 7; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Button btn = new Button();
                    btn.Width = btn.Height = btnSize;
                    btn.Left = col * (btnSize + spacing);
                    btn.Top = row * (btnSize + spacing);
                    btn.BackColor = Color.White;
                    btn.Tag = new Point(row, col);
                    btn.Click += MatrixButton_Click;
                    panelMatrix.Controls.Add(btn);
                    matrixButtons[row, col] = btn;
                    matrixState[row, col] = 0;
                }
            }
        }

        private void MatrixButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Point p = (Point)btn.Tag;
            int row = p.X, col = p.Y;
            if (matrixState[row, col] == 0)
            {
                btn.BackColor = Color.Black;
                matrixState[row, col] = 1;
            }
            else
            {
                btn.BackColor = Color.White;
                matrixState[row, col] = 0;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < 7; row++)
                for (int col = 0; col < 5; col++)
                {
                    matrixButtons[row, col].BackColor = Color.White;
                    matrixState[row, col] = 0;
                }
            lblResult.Text = "Sonuç: ";
        }

        private void BtnTrain_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan epsilon değerini al
            if (!double.TryParse(epsilonTxt.Text, out double epsilon) || epsilon <= 0)
            {
                MessageBox.Show("Geçerli bir epsilon değeri girin (örneğin: 0.01).");
                return;
            }

            int letterCount = TrainingData.Inputs.Length;
            double[][] inputs = new double[letterCount][];
            double[][] outputs = new double[letterCount][];

            for (int i = 0; i < letterCount; i++)
            {
                int[,] inputMatrix = TrainingData.Inputs[i];
                inputs[i] = inputMatrix.Cast<int>().Select(x => (double)x).ToArray();
                outputs[i] = TrainingData.Outputs[i].Select(x => (double)x).ToArray();
            }

            nn = new NeuralNetwork(35, 20, letterCount); 

            // Eğitim süreci
            for (int epoch = 0; epoch < 5000; epoch++) // Maksimum 5000 epoch
            {
                nn.Train(inputs, outputs, 1, 0.1); 
                double errorRate = nn.CalculateErrorRate(inputs, outputs);

                // Hata epsilon değerinin altına düştüyse eğitimi durdur
                if (errorRate < epsilon)
                {
                    lblResult.Text = $"Eğitim tamamlandı. Epoch: {epoch + 1}, Hata oranı: {errorRate:F4}";
                    isTrained = true; 
                    return;
                }
            }

            lblResult.Text = "Eğitim tamamlandı. Maksimum epoch sayısına ulaşıldı.";
            isTrained = true; 
        }



        private void BtnTest_Click(object sender, EventArgs e)
        {
            if (!isTrained)
            {
                lblResult.Text = "Önce ağı eğitin.";
                return;
            }

         
            double[] input = matrixState.Cast<int>().Select(x => (double)x).ToArray(); 

            double[] output = nn.Forward(input);
            int maxIdx = Array.IndexOf(output, output.Max());
            string[] harfler = { "A", "B", "C", "D", "E", "F", "G" }; 

          
            StringBuilder outputDetails = new StringBuilder();
            for (int i = 0; i < output.Length; i++)
            {
                outputDetails.AppendLine($"{harfler[i]}: {output[i]:F3}");
            }

            lblResult.Text = $"Sonuç: {harfler[maxIdx]}\nÇıkışlar:\n{outputDetails}";
      
            double[][] convertedInputs = TrainingData.Inputs
                .Select(inputMatrix => inputMatrix.Cast<int>().Select(x => (double)x).ToArray())
                .ToArray();

            double[][] convertedOutputs = TrainingData.Outputs
                .Select(outputArray => outputArray.Select(x => (double)x).ToArray())
                .ToArray();

            double errorRate = nn.CalculateErrorRate(convertedInputs, convertedOutputs);
            lblErrorRate.Text = $"Hata Oranı: {errorRate:F4}";
        }

    }
}
