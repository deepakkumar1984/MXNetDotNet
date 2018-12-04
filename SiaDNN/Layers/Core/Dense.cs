using System;
using System.Collections.Generic;
using System.Text;
using MXNetDotNet;
using Newtonsoft.Json;
using SiaDNN.Initializers;
using SiaNet.Layers.Activations;

namespace SiaNet.Layers
{
    public class Dense : BaseLayer, ILayer
    {
        public int Dim { get; set; }

        public ILayer Activation { get; set; }

        public bool UseBias { get; set; }

        public BaseInitializer WeightInitializer { get; set; }

        public BaseInitializer BiasInitializer { get; set; }

        public Dense(
           int dim,
           ActivationType activation = ActivationType.Linear,
           BaseInitializer weightInitializer = null,
           bool useBias = false,
           BaseInitializer biasInitializer = null)
            : base("dense")
        {
            Dim = dim;
            Activation = ActivationRegistry.Get(activation);
            UseBias = useBias;
            WeightInitializer = weightInitializer ?? new GlorotUniform();
            if(useBias)
                BiasInitializer = biasInitializer ?? new Zeros();
        }

        public Symbol Build(Symbol data)
        {
            Symbol layer = Operators.FullyConnected(ID, data, Symbol.Variable(UUID.GetID(ID + "_w")), Symbol.Variable(UUID.GetID(ID + "_b")), Dim);

            if (Activation != null)
            {
                return Activation.Build(layer);
            }

            return layer;
        }
    }
}
