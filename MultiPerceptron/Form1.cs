using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace MultiPerceptron
{
    public partial class Form1 : Form
    {
        List<List<double>> trainingList = new List<List<double>>();
        List<List<double>> testList = new List<List<double>>();
        List<List<Node>> layers = new List<List<Node>>();
        List<int> topology = new List<int>();
        double error = 0;
        double learningRate = 0;

        public Form1()
        {
            InitializeComponent();
            Node test = new Node(0.05, null);
            Console.WriteLine(test.GetOutput());
            ResetOutput(test);
            Console.WriteLine(test.GetOutput());
            biasField.Text = "1";
            biasWeightField.Text = "0.35";
            topologyField.Text = "3";
            learningField.Text = "0.35";
        }

        private void ResetOutput(Node node)
        {
            node.SetOutput(0.00);
            Console.WriteLine("IN METHOD " + node.GetOutput());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trainingList.Clear();
            DialogResult fileChosen = trainingFileDialog.ShowDialog();
            bool firstLine = true;
            bool fileOk = true;
            if (fileChosen == DialogResult.OK) // Test result.
            {
                using (StreamReader reader = new StreamReader(trainingFileDialog.FileName))
                {
                    string line;
                    int columns = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        List<double> dataRow = new List<double>();
                        string[] rawData = line.Split(',');

                        if (firstLine)
                        {
                            columns = rawData.Length;
                            firstLine = false;
                        }
                        if (rawData.Length != columns)
                        {
                            MessageBox.Show("Error! Inconsistent data rows in training set.");
                            fileOk = false;
                            break;
                        }


                        for (int i = 0; i < rawData.Length; i++)
                        {
                            double result;
                            double.TryParse(rawData[i], out result);

                            dataRow.Add(result);
                        }

                        //dataRow.Add(trainingList.Count);
                        trainingList.Add(dataRow);
                    }
                    if (fileOk)
                    {
                        trainingLabel.Text = trainingFileDialog.FileName;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            testList.Clear();
            DialogResult fileChosen = testFileDialog.ShowDialog();
            bool firstLine = true;
            bool fileOk = true;
            if (fileChosen == DialogResult.OK) // Test result.
            {
                using (StreamReader reader = new StreamReader(testFileDialog.FileName))
                {
                    string line;
                    int columns = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        List<double> dataRow = new List<double>();
                        string[] rawData = line.Split(',');

                        if (firstLine)
                        {
                            columns = rawData.Length;
                            firstLine = false;
                        }
                        if (rawData.Length != columns)
                        {
                            MessageBox.Show("Error! Inconsistent data rows in test set.");
                            fileOk = false;
                            break;
                        }


                        for (int i = 0; i < rawData.Length; i++)
                        {
                            double result;
                            double.TryParse(rawData[i], out result);
                            //result = double.Parse(rawData[i]);

                            dataRow.Add(result);
                        }
                        testList.Add(dataRow);
                    }
                    if (fileOk)
                    {
                        testLabel.Text = testFileDialog.FileName;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<TrainingGroup> trainingGroupList = new List<TrainingGroup>();

            double defaultWeightValue = 0.35;
            //check if training and test data have equal column numbers
            if (trainingList[0].Count != testList[0].Count)
            {
                MessageBox.Show("Error! Training and Test set feature vector length inconsistent.");
                return;
            }

            topology = ValidateTopologyField(topologyField.Text);

            if (topology.Count == 0)
            {
                MessageBox.Show("Error! Something wrong with topology input.\nPlease remove spaces and decimal points.");
                return;
            }
            topology.Add(1);

            learningRate = double.Parse(learningField.Text);

            int threads = (int) threadField.Value; //50
            int cut = trainingList.Count / threads; //25

            for (int i = 0; i < trainingList.Count; i += cut)
            {
                List<List<double>> rowsToCopy = new List<List<double>>();
                for (int j = 0; j < cut && ((i + j) < trainingList.Count); j++)
                {
                    //use i + j to reference the trainingList entry
                    rowsToCopy.Add(trainingList[i + j]);
                }
                trainingGroupList.Add(new TrainingGroup(rowsToCopy, topology, learningRate, 0.35, iterationField.Value, double.Parse(biasField.Text), double.Parse(biasWeightField.Text))); 
            }

            //now the real fun begins
            List<Thread> threadList = new List<Thread>();
            for (int i = 0; i < trainingGroupList.Count; i++)
            {
                Thread t = new Thread(new ThreadStart(trainingGroupList[i].TrainWeights));
                threadList.Add(t);
                t.Start();
            }
            Console.WriteLine("THE THREADS HAVE ALL STARTED");
            for (int i = 0; i < threadList.Count; i++)
            {
                threadList[i].Join();
            }
            Console.WriteLine("THE THREADS HAVE ALL FINISHED");

            //trainingGroupList[0].DeltasToSumDeltas;
            for (int i = 1; i < trainingGroupList.Count; i++)
			{
                trainingGroupList[i].AddDeltasFrom(trainingGroupList[i - 1]);		    
			}

            TrainingGroup finalWeights = trainingGroupList[trainingGroupList.Count - 1];

            finalWeights.DeltasToSumDeltas();

            //add to it the rest of the groups' DeltaSums

            //now we can call finalWeights.ValidateForwardProp(List<double> testRow) for every test row! 
        }

        

        private void PrintWeights()
        {
            for (int activeLayer = 1; activeLayer < layers.Count; activeLayer++)
            {
                for (int activeNode = 0; activeNode < layers[activeLayer].Count; activeNode++)
                {
                    for (int i = 0; i < layers[activeLayer][activeNode].GetWeights().Count - 1; i++)
                    {
                        //origWeight - (learningRate * delta)
                        //newWeights.Add(nodeToProcess.GetWeights()[i] - (learningRate * nodeToProcess.GetDeltas()[i]));
                        Console.WriteLine(layers[activeLayer][activeNode].GetWeights()[i] + " " + activeLayer + "-" + activeNode);
                    }
                }
            }
        }

        private void PrintInfo()
        {
            for (int activeLayer = 1; activeLayer < layers.Count; activeLayer++)
            {
                for (int activeNode = 0; activeNode < layers[activeLayer].Count; activeNode++)
                {
                    for (int i = 0; i < layers[activeLayer][activeNode].GetWeights().Count - 1; i++)
                    {
                        //origWeight - (learningRate * delta)
                        //newWeights.Add(nodeToProcess.GetWeights()[i] - (learningRate * nodeToProcess.GetDeltas()[i]));
                        Console.WriteLine(activeLayer + "-" + activeNode);
                        layers[activeLayer][activeNode].PrintInfo();
                    }
                }
            }
        }

        private double GetError(double actualOutput, double expectedOutput)
        {
            return (0.5 * Math.Pow((actualOutput - expectedOutput), 2));
        }

        private void integer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void double_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private List<int> ValidateTopologyField(string inputText)
        {
            List<int> values = new List<int>();
            List<string> splitString = new List<string>();
            splitString.AddRange(inputText.Split(','));
            //check if input is valid
            foreach (string item in splitString)
            {
                int yay = 0;
                if (int.TryParse(item, out yay))
                {
                    if (yay != 0)
                    {
                        values.Add(yay);
                    }
                }
                else
                {
                    MessageBox.Show("Error! Invalid entry in the field with value of:\n" + inputText);
                    values.Clear();
                    return values;
                }
            }
            return values;
        }

        //private void ValidateTheResults(int dataRowIndex)
        //{
        //    ForwardProp(dataRowIndex, true);
        //}
    }
}
