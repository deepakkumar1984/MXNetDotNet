using MXNetDotNet;
using MXNetDotNet.Extensions;
using SiaDNN.Initializers;
using SiaNet;
using SiaNet.Layers.Activations;
using SiaNet.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiaNet.Data;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("MXNET_ENGINE_TYPE", "NaiveEngine");
            GlobalParam.Device = Context.Cpu();
            //MNISTTraining();
            ORGate();

            Console.ReadLine();
        }

        private static void ORGate()
        {
            DataFrame train_x = new DataFrame(4, 2);
            DataFrame train_y = new DataFrame(4, 1);
            train_x.AddData(0, 0);
            train_x.AddData(0, 1);
            train_x.AddData(1, 0);
            train_x.AddData(1, 1);

            train_y.AddData(0);
            train_y.AddData(1);
            train_y.AddData(1);
            train_y.AddData(1);
            
            DataFrameIter train = new DataFrameIter(train_x, train_y);

            Sequential model = new Sequential(new Shape(2), 1);
            model.AddHidden(new Dense(4, ActivationType.ReLU, new GlorotUniform()));

            model.Compile(OptimizerType.SGD, LossType.BinaryCrossEntropy, "accuracy");

            model.Fit(train, 100, 2);
            model.SaveModel(@"C:\Users\bdkadmin\Desktop\SSHKeys\");
        }

        private static void MNISTTraining()
        {
            uint batchSize = 32;
            var trainIter = new MXDataIter("MNISTIter")
                .SetParam("image", "./mnist_data/train-images-idx3-ubyte")
                .SetParam("label", "./mnist_data/train-labels-idx1-ubyte")
                .SetParam("batch_size", batchSize)
                .SetParam("flat", 1)
                .CreateDataIter();
            var valIter = new MXDataIter("MNISTIter")
                .SetParam("image", "./mnist_data/t10k-images-idx3-ubyte")
                .SetParam("label", "./mnist_data/t10k-labels-idx1-ubyte")
                .SetParam("batch_size", batchSize)
                .SetParam("flat", 1)
                .CreateDataIter();
            
            var model = new Sequential(new Shape(28 * 28), 10);
            model.AddHidden(new Dense(28 * 28, ActivationType.ReLU, new GlorotUniform()));
            model.AddHidden(new Dropout(0.25f));
            model.AddHidden(new Dense(28 * 28, ActivationType.ReLU, new GlorotUniform()));

            model.Compile(OptimizerType.SGD, LossType.CategorialCrossEntropy, "accuracy");
            model.Fit(trainIter, 10, batchSize, valIter);
        }
    }
}
