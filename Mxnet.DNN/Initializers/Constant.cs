using System;
using System.Collections.Generic;
using System.Text;
using MXNetDotNet;

namespace Mxnet.DNN.Initializers
{
    public class Constant : Initializer
    {
        public string Name
        {
            get
            {
                return "constant";
            }
        }

        public float Value { get; set; }

        public Constant(float value)
        {
            Value = value;
        }

        public override void Operator(string name, NDArray array)
        {
            array.Set(this.Value);
        }

    }
}
