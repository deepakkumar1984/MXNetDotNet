using Microsoft.VisualStudio.TestTools.UnitTesting;
using MXNetDotNet.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXNetDotNet.Tests.MXNet
{
    [TestClass]
    public class NDArrayOpTest
    {
        [TestMethod]
        public void TestMath()
        {
            NDArray array1 = new NDArray(new float[] { 4, 2 }, new Shape(2), Context.Cpu());
            NDArray array2 = new NDArray(new float[] { 3.23f, 4 }, new Shape(2), Context.Cpu());

            array2 = NDArray.Cast(array2, DType.Int32);
            var arr1 = array1.AsArray();
            var arr2 = array2.AsArray();

            List<float> result = new List<float>();
            Symbol a = Symbol.Variable("a");

            var c = 2 * a;

            Dictionary<string, NDArray> inputs = new Dictionary<string, NDArray>();
            inputs.Add("a", array1);

            
            var exec = c.SimpleBind(Context.Cpu(), inputs);
            exec.Forward(false);
            var output = exec.Outputs[0];
            var data = output.AsArray();
         }

        [TestMethod]
        public void DisplayArrayData()
        {
            NDArray array1 = new NDArray(new float[] { 4, 2 }, new Shape(2, 1), Context.Cpu());
            string data = array1.ToString();
        }
    }
}
