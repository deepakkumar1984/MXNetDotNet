using MXNetDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiaNet.Layers.Activations
{
    public class SoftRelu : BaseLayer, ILayer
    {
        public SoftRelu()
            : base("softrelu")
        {

        }

        public Symbol Build(Symbol x)
        {
            return new Operator("Activation").SetParam("act_type", "softrelu")
                                            .SetInput("data", x)
                                            .CreateSymbol(ID);
        }
    }
}
