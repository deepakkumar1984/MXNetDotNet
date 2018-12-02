using System;
using System.Collections.Generic;
using System.Text;
using MXNetDotNet;

namespace Mxnet.DNN.Constraints
{
    public class MaxNorm : BaseConstraint
    {
        public float MaxValue { get; set; }
        public int Axis { get; set; }

        public MaxNorm(float maxValue, int axis=-1)
        {
            MaxValue = maxValue;
            Axis = axis;
        }

        public override NDArray Call(NDArray w)
        {
            Symbol weight = new Symbol("w");
            var norms = OperatorSupply.PowerScalar(weight, 2);
            return w;
        }
    }
}
