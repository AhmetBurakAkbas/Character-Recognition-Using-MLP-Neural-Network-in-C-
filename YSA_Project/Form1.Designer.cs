namespace YSA_Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Panel panelMatrix;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.panelMatrix = new System.Windows.Forms.Panel();
            this.lblErrorRate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.epsilonTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(30, 501);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(100, 40);
            this.btnTrain.TabIndex = 1;
            this.btnTrain.Text = "Eğit";
            this.btnTrain.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(215, 501);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 40);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test Et";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(394, 501);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 40);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(530, 72);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(217, 318);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "Sonuç: ";
            // 
            // panelMatrix
            // 
            this.panelMatrix.Location = new System.Drawing.Point(30, 72);
            this.panelMatrix.Name = "panelMatrix";
            this.panelMatrix.Size = new System.Drawing.Size(464, 392);
            this.panelMatrix.TabIndex = 0;
            // 
            // lblErrorRate
            // 
            this.lblErrorRate.AutoSize = true;
            this.lblErrorRate.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorRate.Location = new System.Drawing.Point(531, 419);
            this.lblErrorRate.Name = "lblErrorRate";
            this.lblErrorRate.Size = new System.Drawing.Size(0, 29);
            this.lblErrorRate.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(581, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "A, B, C, D, E, F, G  Harflerinden herhangi birini giriniz.";
            // 
            // epsilonTxt
            // 
            this.epsilonTxt.Location = new System.Drawing.Point(689, 510);
            this.epsilonTxt.Name = "epsilonTxt";
            this.epsilonTxt.Size = new System.Drawing.Size(58, 22);
            this.epsilonTxt.TabIndex = 7;
            this.epsilonTxt.Text = "0,01";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(552, 513);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Epsilon Değeri:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(848, 612);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.epsilonTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblErrorRate);
            this.Controls.Add(this.panelMatrix);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblResult);
            this.Name = "Form1";
            this.Text = "YSA Harf Tanıma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblErrorRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox epsilonTxt;
        private System.Windows.Forms.Label label2;
    }
}

