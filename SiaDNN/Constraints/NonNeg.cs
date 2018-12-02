﻿using System;
using System.Collections.Generic;
using System.Text;
using MXNetDotNet;

namespace SiaDNN.Constraints
{
    public class NonNeg : BaseConstraint
    {
        public NonNeg()
        {
        }

        public override NDArray Call(NDArray w)
        {
            w *= NDArray.Cast(NDArray.GreaterEqual(w, 0), DType.Float32);
            return w;
        }
    }
}
