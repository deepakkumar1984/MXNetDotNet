using System;
using System.Collections.Generic;
using System.Text;

namespace Mxnet.DNN.Initializers
{
    public class GlorotNormal : VarianceScaling
    {
        public GlorotNormal()
            :base(1, "fan_avg", "normal")
        {
            Name = "glorot_normal";
        }
    }
}
