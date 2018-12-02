using System;
using System.Collections.Generic;
using System.Text;

namespace Mxnet.DNN.Initializers
{
    public class Zeros : Constant
    {
        public Zeros()
            : base(0f)
        {
        }
    }
}
