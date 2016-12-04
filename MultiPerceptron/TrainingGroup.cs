using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPerceptron
{
    class TrainingGroup
    {
        List<List<double>> trainingList;
        List<List<Node>> layers;
        List<int> topology;
        //double error = 0;
        double learningRate;
        double defaultWeightValue;
        int numOfIterations;
        double bias;
        double biasWeight;

        public TrainingGroup(List<List<double>> rowsToCopy, List<int> topology, double learningRate, double defaultWeight, decimal iterations, double bias, double biasWeight)
        {
            trainingList = rowsToCopy;
            layers = new List<List<Node>>();
            this.topology = topology;
            this.learningRate = learningRate;
            defaultWeightValue = defaultWeight;
            numOfIterations = (int) iterations;
            this.bias = bias;
            this.biasWeight = biasWeight;
        }

        public void TrainWeights()
        {
            double defaultWeightValue = 0.35;
            //check if training and test data have equal column numbers

            layers.Clear();

            int dataRow = 0;
            double expectedRowOutput = trainingList[dataRow][trainingList[dataRow].Count - 1];

            //INPUT LAYER
            layers.Add(new List<Node>());
            //intialize input values
            for (int i = 0; i < trainingList[0].Count - 1; i++)
            {
                layers[0].Add(new Node(trainingList[0][i], new List<double>()));
            }

            //HIDDEN LAYER
            for (int i = 0; i < topology.Count; i++)
            {
                //setting up number of Nodes per hidden layer
                //int currentLayer = layers.Count + 1;
                layers.Add(new List<Node>()); //1
                for (int j = 0; j < topology[i]; j++) //0
                {
                    //setting up each Node
                    List<double> weights = new List<double>();
                    for (int a = 0; a < layers[i].Count; a++) //has 6 nodes already
                    {
                        weights.Add(defaultWeightValue);
                    }
                    layers[i + 1].Add(new Node(0, weights));
                    int lastNodeIndex = layers[i + 1].Count - 1;
                    layers[i + 1][lastNodeIndex].SetWeights(weights);
                    layers[i + 1][lastNodeIndex].SetOutput(ProcessOutput(layers[i], layers[i + 1][lastNodeIndex]));
                }
            }

            //OUTPUT LAYER
            //layers.Add(new List<Node>());
            //List<double> outputWeights = new List<double>();
            int outputLayerIndex = layers.Count - 1;
            //for (int a = 0; a <= layers[outputLayerIndex - 1].Count; a++)
            //{
            //    outputWeights.Add(defaultWeightValue);
            //}
            //layers[outputLayerIndex].Add(new Node(0, outputWeights));
            Node outputNode = layers[outputLayerIndex][0];
            outputNode.SetOutput(ProcessOutput(layers[outputLayerIndex - 1], outputNode));

            //git error
            //0.5*((expected - actual)^2)
            //error = 0.5*Math.Pow((expectedRowOutput - outputNode.GetOutput()),2);
            //error = GetError(outputNode.GetOutput(), expectedRowOutput);
            //begin backprop huhu
            //OUTPUT -> HIDDEN
            //gradient stuff
            //=(B$26-C$26)*B$26*(1-B$26)
            // (actual - expected) * actual * (1 - actual)
            //SetGradient(outputNode, expectedRowOutput);
            //delta stuff
            //=$G9*J9
            //each input * gradient
            //SetDeltas(outputNode, layers[outputLayerIndex - 1]);
            SetGradientAndDeltaValues(outputNode, expectedRowOutput, layers[outputLayerIndex - 1]);

            //OKAY DEAL WITH THE MYRIAD OF HIDDEN ONES NOW
            for (int activeLayer = outputLayerIndex - 1; activeLayer >= 1; activeLayer--)
            {
                for (int nodeNum = 0; nodeNum < layers[activeLayer].Count; nodeNum++)
                {
                    double expectedOutput = 0;
                    for (int i = 0; i < layers[activeLayer + 1].Count; i++)
                    {
                        expectedOutput += layers[activeLayer + 1][i].GetWeights()[nodeNum] * layers[activeLayer + 1][i].GetGradient();
                    }
                    //actual - ($J$9*$H$9)+($K$9*$I$9) 
                    expectedOutput = layers[activeLayer][nodeNum].GetOutput() - expectedOutput;
                    SetGradientAndDeltaValues(layers[activeLayer][nodeNum], expectedOutput, layers[activeLayer - 1]);
                }
            }

            //backprop should be done????
            //REPLACE THE WEIGHTS NOW MEHN
            for (int activeLayer = 1; activeLayer < layers.Count; activeLayer++)
            {
                for (int activeNode = 0; activeNode < layers[activeLayer].Count; activeNode++)
                {
                    SetNewWeights(layers[activeLayer][activeNode]);
                }
            }

            //OLD METHOD
            //finish prcessing first row first time
            //for (int i = 1; i < numOfIterations; i++)
            //{
            //    ProcessAgain(dataRow);
            //}

            ////do the rest of the rows
            //for (int i = 1; i < trainingList.Count; i++)
            //{
            //    for (int j = 0; j < numOfIterations; j++)
            //    {
            //        ProcessAgain(i);
            //    }
            //}

            //NEW METHOD
            //finish processing first row
            for (int i = 1; i < trainingList.Count; i++)
            {
                ProcessAgain(i);
            }

            //do the rest of the rows
            for (int i = 1; i < numOfIterations; i++)
            {
                for (int j = 0; j < trainingList.Count; j++)
                {
                    ProcessAgain(j);
                }
            }

            ////VALIDATION PART YOOOOOOO
            //for (int i = 0; i < testList.Count; i++)
            //{
            //    ValidateTheResults(i);
            //    Console.WriteLine("ERROR: " + error);
            //}
        }

        public double ProcessOutput(List<Node> prevLayerNodes, Node nodeToProcess)
        {
            double newOutput = 0;

            List<double> weightsToUse = nodeToProcess.GetWeights();

            for (int i = 0; i < weightsToUse.Count; i++)
            {
                newOutput += (weightsToUse[i] * prevLayerNodes[i].GetOutput());
            }

            //Console.WriteLine("non-biased value: " + newOutput);

            newOutput += (bias * biasWeight);

            //Console.WriteLine("BIAS THINGY: " + ((double.Parse(biasField.Text) * double.Parse(biasWeightField.Text))));

            //=(1/(1+EXP(-C8)))
            newOutput = 1.0 / (1.0 + Math.Exp(-newOutput));

            return newOutput;
        }

        private void ForwardProp(int dataRowIndex)
        {
            //List<List<double>> trainingList = new List<List<double>>();
            //if (!validation)
            //{
            //    trainingList = this.trainingList;
            //}
            //else
            //{
            //    trainingList = this.testList;
            //}
            double expectedRowOutput = trainingList[dataRowIndex][trainingList[dataRowIndex].Count - 1];

            //INPUT LAYER
            //layers.Add(new List<Node>());
            //intialize input values
            for (int i = 0; i < trainingList[dataRowIndex].Count - 1; i++)
            {
                //layers[0].Add(new Node(trainingList[0][i], new List<double>()));
                layers[0][i].SetOutput(trainingList[dataRowIndex][i]);
            }

            //HIDDEN LAYER
            for (int i = 0; i < topology.Count; i++)
            {
                //setting up number of Nodes per hidden layer
                //int currentLayer = layers.Count + 1;
                //layers.Add(new List<Node>()); //1
                for (int j = 0; j < topology[i]; j++) //0
                {
                    //setting up each Node
                    //List<double> weights = new List<double>();
                    //for (int a = 0; a < layers[i].Count; a++) //has 6 nodes already
                    //{
                    //    weights.Add(defaultWeightValue);
                    //}
                    //layers[i + 1].Add(new Node(0, weights));
                    //int lastNodeIndex = layers[i + 1].Count - 1;
                    //layers[i + 1][j].SetWeights(weights);
                    layers[i + 1][j].SetOutput(ProcessOutput(layers[i], layers[i + 1][j]));
                }
            }

            //OUTPUT LAYER
            //layers.Add(new List<Node>());
            //List<double> outputWeights = new List<double>();
            int outputLayerIndex = layers.Count - 1;
            //for (int a = 0; a <= layers[outputLayerIndex - 1].Count; a++)
            //{
            //    outputWeights.Add(defaultWeightValue);
            //}
            //layers[outputLayerIndex].Add(new Node(0, outputWeights));
            Node outputNode = layers[outputLayerIndex][0];
            outputNode.SetOutput(ProcessOutput(layers[outputLayerIndex - 1], outputNode));

            //git error
            //0.5*((expected - actual)^2)
            //error = GetError(outputNode.GetOutput(), expectedRowOutput);



            //PrintInfo();
        }

        private void BackProp(int dataRowIndex)
        {
            int outputLayerIndex = layers.Count - 1;
            Node outputNode = layers[outputLayerIndex][0];
            double expectedRowOutput = trainingList[dataRowIndex][trainingList[dataRowIndex].Count - 1];

            //begin backprop huhu
            //OUTPUT -> HIDDEN
            //gradient stuff
            //=(B$26-C$26)*B$26*(1-B$26)
            // (actual - expected) * actual * (1 - actual)
            //SetGradient(outputNode, expectedRowOutput);
            //delta stuff
            //=$G9*J9
            //each input * gradient
            //SetDeltas(outputNode, layers[outputLayerIndex - 1]);
            SetGradientAndDeltaValues(outputNode, expectedRowOutput, layers[outputLayerIndex - 1]);

            //OKAY DEAL WITH THE MYRIAD OF HIDDEN ONES NOW
            for (int activeLayer = outputLayerIndex - 1; activeLayer >= 1; activeLayer--)
            {
                for (int nodeNum = 0; nodeNum < layers[activeLayer].Count; nodeNum++)
                {
                    double expectedOutput = 0;
                    for (int i = 0; i < layers[activeLayer + 1].Count; i++)
                    {
                        expectedOutput += layers[activeLayer + 1][i].GetWeights()[nodeNum] * layers[activeLayer + 1][i].GetGradient();
                    }
                    //actual - ($J$9*$H$9)+($K$9*$I$9) 
                    expectedOutput = layers[activeLayer][nodeNum].GetOutput() - expectedOutput;
                    SetGradientAndDeltaValues(layers[activeLayer][nodeNum], expectedOutput, layers[activeLayer - 1]);
                }
            }

            //backprop should be done????
            //REPLACE THE WEIGHTS NOW MEHN
            for (int activeLayer = 1; activeLayer < layers.Count; activeLayer++)
            {
                for (int activeNode = 0; activeNode < layers[activeLayer].Count; activeNode++)
                {
                    SetNewWeights(layers[activeLayer][activeNode]);
                }
            }
        }

        private void ProcessAgain(int dataRowIndex)
        {
            ForwardProp(dataRowIndex);
            BackProp(dataRowIndex);
        }

        private void SetGradientAndDeltaValues(Node nodeToProcess, double expectedOutput, List<Node> inputNodes)
        {
            nodeToProcess.SetGradient((nodeToProcess.GetOutput() - expectedOutput) * nodeToProcess.GetOutput() * (1 - nodeToProcess.GetOutput()));
            //Console.WriteLine("GRADIENT: " + nodeToProcess.GetGradient());
            List<double> deltas = new List<double>();
            for (int i = 0; i < inputNodes.Count; i++)
            {
                deltas.Add(inputNodes[i].GetOutput() * nodeToProcess.GetGradient());
            }
            nodeToProcess.SetDeltas(deltas);
        }

        public void SetNewWeights(Node nodeToProcess)
        {
            List<double> newWeights = new List<double>();
            for (int i = 0; i < nodeToProcess.GetWeights().Count; i++)
            {
                //origWeight - (learningRate * delta)
                //Console.WriteLine("Index: " + i);
                //Console.WriteLine("Old Weight: " + nodeToProcess.GetWeights()[i]);
                //Console.WriteLine("Gradient: " + nodeToProcess.GetGradient());
                //Console.WriteLine("Weights: " + nodeToProcess.GetWeights().Count + " || Deltas: " + nodeToProcess.GetDeltas().Count);
                //Console.WriteLine("Delta: " + nodeToProcess.GetDeltas()[i]);
                newWeights.Add(nodeToProcess.GetWeights()[i] - (learningRate * nodeToProcess.GetDeltas()[i]));
                //Console.WriteLine(newWeights[newWeights.Count - 1]);
            }
            nodeToProcess.SetWeights(newWeights);
        }

        public List<List<Node>> GetLayers()
        {
            return layers;
        }

        public void DeltasToSumDeltas()
        {
            foreach (List<Node> nodes in layers)
            {
                foreach (Node node in nodes)
                {
                    node.OverrideDeltasWithSums();
                    SetNewWeights(node);
                }
            }
        }
    }
}
