﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXNetDotNet.Numerics
{
    public partial struct Int64Calculator : ICalculator<long>
    {
        public long Sum(long[] data)
        {
            return data.Sum();
        }

        public int Argmax(long[] data)
        {
            return !data.Any()
                ? -1
                : data
                    .Select((value, index) => new { Value = value, Index = index })
                    .Aggregate((a, b) => (a.Value >= b.Value) ? a : b)
                    .Index;
        }

        public long[] Log(long[] data)
        {
            return data.Select(s => (long)Math.Log(s)).ToArray();
        }

        public long[] Abs(long[] data)
        {
            return data.Select(Math.Abs).ToArray();
        }

        public long Mean(long[] data)
        {
            return (long)data.Average();
        }

        public long[] Minus(long[] data)
        {
            return data.Select(s => -s).ToArray();
        }

        public long[] Minus(long[] ldata, long[] rdata)
        {
            return ldata.Zip(rdata, (l, r) => l - r).ToArray();
        }

        public long[] Pow(long[] data, long y)
        {
            return data.Select(s => (long)Math.Pow(s, y)).ToArray();
        }

        public long Compare(long a, long b)
        {
            return a == b ? 1 : 0;
        }
    }

    public partial class Int64NArray : NArray<long, Int64Calculator, Int64NArray>
    {
        public Int64NArray()
        {

        }
        public Int64NArray(Shape shape) : base(shape)
        {
        }

        public Int64NArray(Shape shape, long[] data) : base(shape, data)
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
