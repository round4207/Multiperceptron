using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiPerceptron
{
    class Node
    {
        private double output;
        private List<double> weights;
        //private List<double> gradients;
        private double gradient;
        private List<double> deltas;
        private List<double> deltaSums;

        public Node(double newValue, List<double> newWeights)
        {
            output = newValue;
            weights = newWeights;
            gradient = 0;
            deltaSums = new List<double>();
        }

        public void SetOutput(double newValue)
        {
            output = newValue;
        }

        public double GetOutput()
        {
            return output;
        }

        public void SetWeights(List<double> newWeights)
        {
            weights = newWeights;
        }

        public List<double> GetWeights()
        {
            return weights;
        }

        public void SetGradient(double newGradient)
        {
            gradient = newGradient;
        }

        public double GetGradient()
        {
            return gradient;
        }

        //public void SetGradients(List<double> newGradients)
        //{
        //    gradients = newGradients;
        //}

        //public List<double> GetGradients()
        //{
        //    return gradients;
        //}

        public void SetDeltas(List<double> newDeltas)
        {
            deltas = newDeltas;
            if (deltaSums.Count != deltas.Count)
            {
                Console.WriteLine("DELTA SUMS WERE CLEARED!!!" + Thread.CurrentThread.Name);
                deltaSums.Clear();
                for (int i = 0; i < deltas.Count; i++)
                {
                    deltaSums.Add(0.0);
                }
            }
            UpdateDeltaSums();
        }

        public List<double> GetDeltas()
        {
            return deltas;
        }

        private void UpdateDeltaSums()
        {
            for (int i = 0; i < deltas.Count; i++)
            {
                deltaSums[i] += deltas[i];
            }
        }

        public List<double> GetDeltaSums()
        {
            return deltaSums;
        }

        public void OverrideDeltasWithSums()
        {
            deltas = deltaSums;
        }

        public void PrintInfo()
        {
            string print = "";
            //print += "\n";
            print += "Output " + output + "\n";
            print += "Weights" + "\n";
            foreach (var item in weights)
            {
                print += item + "\n";
            }
            //print += "Deltas" + "\n";
            //foreach (var item in deltas)
            //{
            //    print += item + "\n";
            //}
            print += gradient + "\n";
            Console.WriteLine(print);
        }
    }
}
