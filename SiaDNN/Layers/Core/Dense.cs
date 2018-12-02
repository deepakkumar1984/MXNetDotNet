using System;
using System.Collections.Generic;
using System.Text;
using MXNetDotNet;

namespace SiaNet.Layers.Core
{
    public class Dense : BaseLayer, ILayer
    {
        public Symbol Build(Symbol x)
        {
            Operators.FullyConnected()
            throw new NotImplementedException();
        }
    }
}
