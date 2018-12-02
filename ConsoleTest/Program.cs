using MXNetDotNet;
using MXNetDotNet.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("MXNET_ENGINE_TYPE", "NaiveEngine");
            NDArray array1 = new NDArray(new float[] { 4, 2, 4,5, 6, 9}, new Shape(6, 1), Context.Cpu());
            float[] data = array1.AsArray();
            //array1.SyncCopyToCPU(data);
            //var data = ObjectExtensions.AsNumerics(array1);
            Console.WriteLine(data);
            Console.ReadLine();
        }
    }
}
