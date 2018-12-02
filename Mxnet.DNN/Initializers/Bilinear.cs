using System;
using System.Collections.Generic;
using System.Text;
using MXNetDotNet;

namespace Mxnet.DNN.Initializers
{
    public class Bilinear : Initializer
    {
        public string Name
        {
            get
            {
                return "bilinear";
            }
        }

        public override void Operator(string name, NDArray array)
        {
            base.InitBilinear(array);
        }

    }
}
