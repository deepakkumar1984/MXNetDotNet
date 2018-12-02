using System;
using System.Collections.Generic;
using System.Text;

namespace SiaNet
{
    public class UUID
    {
        private static int CurrentIndex { get; set; }

        public static void Reset()
        {
            CurrentIndex = 0;
        }

        public static int Next()
        {
            return CurrentIndex++;
        }

        public static string GetID(string name)
        {
            return string.Format("{0}_{1}", name.ToLower(), Next());
        }
    }
}
