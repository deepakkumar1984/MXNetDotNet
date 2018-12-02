﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mxnet.DNN.Initializers
{
    public class HeNormal : VarianceScaling
    {
        public HeNormal()
            :base(2, "fan_in", "normal")
        {
            Name = "he_normal";
        }
    }
}
