using System;
using System.Collections.Generic;
using System.Text;

namespace Mxnet.DNN.Initializers
{
    public class LecunUniform : VarianceScaling
    {
        public LecunUniform()
            :base(1, "fan_in", "uniform")
        {
            Name = "lecun_uniform";
        }
    }
}
