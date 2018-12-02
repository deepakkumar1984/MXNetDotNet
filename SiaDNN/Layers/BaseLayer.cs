using System;
using System.Collections.Generic;
using System.Text;

namespace SiaNet.Layers
{
    public class BaseLayer
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public BaseLayer(string name)
        {
            Name = name;
            ID = UUID.GetID(name);
        }
    }
}
