using MXNetDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiaDNN
{
    public class GlobalParam
    {
        public static Context Device { get; set; } = Context.Cpu();
    }
}
