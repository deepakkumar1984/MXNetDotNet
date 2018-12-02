﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXNetDotNet.Numerics
{
    public partial struct Int32Calculator : ICalculator<int>
    {
        public int Sum(int[] data)
        {
            return data.Sum();
        }

        public int Argmax(int[] data)
        {
            return !data.Any()
                ? -1
                : data
                    .Select((value, index) => new { Value = value, Index = index })
                    .Aggregate((a, b) => (a.Value >= b.Value) ? a : b)
                    .Index;
        }

        public int[] Log(int[] data)
        {
            return data.Select(s => (int)Math.Log(s)).ToArray();
        }

        public int[] Abs(int[] data)
        {
            return data.Select(Math.Abs).ToArray();
        }

        public int Mean(int[] data)
        {
            return (int)data.Average();
        }

        public int[] Minus(int[] data)
        {
            return data.Select(s => -s).ToArray();
        }

        public int[] Minus(int[] ldata, int[] rdata)
        {
            return ldata.Zip(rdata, (l, r) => l - r).ToArray();
        }

        public int[] Pow(int[] data, int y)
        {
            return data.Select(s => (int)Math.Pow(s, y)).ToArray();
        }

        public int Compare(int a, int b)
        {
            return a == b ? 1 : 0;
        }
    }

    public partial class Int32NArray : NArray<int, Int32Calculator, Int32NArray>
    {
        public Int32NArray()
        {

        }
        public Int32NArray(Shape shape) : base(shape)
        {
        }

        public Int32NArray(Shape shape, int[] data) : base(shape, data)
        {

        }
        #region Convert
        public SingleNArray ToSingle()
        {
            return new SingleNArray(Shape, Storage.Select(s => (float)s).ToArray());
        }

        public Int32NArray ToInt32()
        {
            return new Int32NArray(Shape, Storage.Select(s => (int)s).ToArray());
        }

        public Int64NArray ToInt64()
        {
            return new Int64NArray(Shape, Storage.Select(s => (long)s).ToArray());
        }
        #endregion
    }

}
