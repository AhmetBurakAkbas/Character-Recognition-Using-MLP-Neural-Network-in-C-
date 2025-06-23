using System;

namespace YSA_Project
{
    public class NeuralNetwork
    {
        private int inputSize, hiddenSize, outputSize;
        private double[,] weightsInputHidden;
        private double[,] weightsHiddenOutput;
        private double[] hiddenBias;
        private double[] outputBias;
        private Random rand = new Random();

        public NeuralNetwork(int inputSize, int hiddenSize, int outputSize)
        {
            this.inputSize = inputSize;
            this.hiddenSize = hiddenSize;
            this.outputSize = outputSize;
            weightsInputHidden = new double[inputSize, hiddenSize];
            weightsHiddenOutput = new double[hiddenSize, outputSize];
            hiddenBias = new double[hiddenSize];
            outputBias = new double[outputSize];
            InitializeWeights();
        }

        private void InitializeWeights()
        {
            for (int i = 0; i < inputSize; i++)
                for (int j = 0; j < hiddenSize; j++)
                    weightsInputHidden[i, j] = rand.NextDouble() - 0.5;
            for (int i = 0; i < hiddenSize; i++)
                for (int j = 0; j < outputSize; j++)
                    weightsHiddenOutput[i, j] = rand.NextDouble() - 0.5;
            for (int i = 0; i < hiddenSize; i++)
                hiddenBias[i] = rand.NextDouble() - 0.5;
            for (int i = 0; i < outputSize; i++)
                outputBias[i] = rand.NextDouble() - 0.5;
        }

        private double Sigmoid(double x) => 1.0 / (1.0 + Math.Exp(-x));
        private double SigmoidDerivative(double x) => x * (1 - x);

        public double[] Forward(double[] input)
        {
            double[] hidden = new double[hiddenSize];
            double[] output = new double[outputSize];
            // Input -> Hidden
            for (int i = 0; i < hiddenSize; i++)
            {
                double sum = hiddenBias[i];
                for (int j = 0; j < inputSize; j++)
                    sum += input[j] * weightsInputHidden[j, i];
                hidden[i] = Sigmoid(sum);
            }
            // Hidden -> Output
            for (int i = 0; i < outputSize; i++)
            {
                double sum = outputBias[i];
                for (int j = 0; j < hiddenSize; j++)
                    sum += hidden[j] * weightsHiddenOutput[j, i];
                output[i] = Sigmoid(sum);
            }
            return output;
        }

        public void Train(double[][] inputs, double[][] targets, int epochs, double learningRate)
        {
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                for (int sample = 0; sample < inputs.Length; sample++)
                {
                    // Forward
                    double[] input = inputs[sample];
                    double[] hidden = new double[hiddenSize];
                    double[] output = new double[outputSize];
                    for (int i = 0; i < hiddenSize; i++)
                    {
                        double sum = hiddenBias[i];
                        for (int j = 0; j < inputSize; j++)
                            sum += input[j] * weightsInputHidden[j, i];
                        hidden[i] = Sigmoid(sum);
                    }
                    for (int i = 0; i < outputSize; i++)
                    {
                        double sum = outputBias[i];
                        for (int j = 0; j < hiddenSize; j++)
                            sum += hidden[j] * weightsHiddenOutput[j, i];
                        output[i] = Sigmoid(sum);
                    }
                    // Backward
                    double[] outputErrors = new double[outputSize];
                    double[] outputDeltas = new double[outputSize];
                    for (int i = 0; i < outputSize; i++)
                    {
                        outputErrors[i] = targets[sample][i] - output[i];
                        outputDeltas[i] = outputErrors[i] * SigmoidDerivative(output[i]);
                    }
                    double[] hiddenErrors = new double[hiddenSize];
                    double[] hiddenDeltas = new double[hiddenSize];
                    for (int i = 0; i < hiddenSize; i++)
                    {
                        double error = 0;
                        for (int j = 0; j < outputSize; j++)
                            error += outputDeltas[j] * weightsHiddenOutput[i, j];
                        hiddenErrors[i] = error;
                        hiddenDeltas[i] = hiddenErrors[i] * SigmoidDerivative(hidden[i]);
                    }
                    for (int i = 0; i < hiddenSize; i++)
                        for (int j = 0; j < outputSize; j++)
                            weightsHiddenOutput[i, j] += learningRate * outputDeltas[j] * hidden[i];
                    for (int i = 0; i < outputSize; i++)
                        outputBias[i] += learningRate * outputDeltas[i];
                    for (int i = 0; i < inputSize; i++)
                        for (int j = 0; j < hiddenSize; j++)
                            weightsInputHidden[i, j] += learningRate * hiddenDeltas[j] * input[i];
                    for (int i = 0; i < hiddenSize; i++)
                        hiddenBias[i] += learningRate * hiddenDeltas[i];
                }
            }
        }
        public double CalculateErrorRate(double[][] inputs, double[][] targets)
        {
            double totalError = 0;
            int totalSamples = inputs.Length;

            for (int sample = 0; sample < totalSamples; sample++)
            {
                double[] output = Forward(inputs[sample]);
                for (int i = 0; i < output.Length; i++)
                {
                    double error = targets[sample][i] - output[i];
                    totalError += Math.Pow(error, 2); 
                }
            }

            return totalError / totalSamples; 
        }
    }
} 