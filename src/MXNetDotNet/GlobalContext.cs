using System;
using System.Collections.Generic;
using System.Text;

namespace MXNetDotNet
{
    public class GlobalContext
    {
        public static Context Device { get; set; } = Context.Cpu();
    }
}
