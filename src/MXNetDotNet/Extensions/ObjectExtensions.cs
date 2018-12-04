﻿using MXNetDotNet.Interop;
using System;

namespace MXNetDotNet.Extensions
{

    public static class ObjectExtensions
    {

        public static string ToValueString(this object source)
        {
            return source is bool b ? (b ? "1" : "0") : source.ToString();
        }

    }

}
