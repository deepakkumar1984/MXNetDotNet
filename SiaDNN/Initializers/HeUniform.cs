﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SiaDNN.Initializers
{
    public class HeUniform : VarianceScaling
    {
        public HeUniform()
            :base(2, "fan_in", "uniform")
        {
            Name = "he_uniform";
        }
    }
}
