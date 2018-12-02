using System;
using System.Collections.Generic;
using System.Text;

namespace Mxnet.DNN.Initializers
{
    public class Ones : Constant
    {
        public Ones()
            : base(1f)
        {
        }
    }
}
