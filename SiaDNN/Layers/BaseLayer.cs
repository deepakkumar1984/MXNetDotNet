using MXNetDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiaNet.Layers
{
    public abstract class BaseLayer
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public Dictionary<string, Symbol> Params;

        public BaseLayer(string name)
        {
            Name = name;
            ID = UUID.GetID(name);
            Params = new Dictionary<string, Symbol>();
        }
    }
}
