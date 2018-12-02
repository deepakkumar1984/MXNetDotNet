﻿using System;
using MXNetDotNet.Interop;

// ReSharper disable once CheckNamespace
namespace MXNetDotNet
{

    public sealed class PredictorHandle : DisposableMXNetObject
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PredictorHandle"/> class.
        /// </summary>
        /// <param name="handle">The handle of the PredictorHandle.</param>
        internal PredictorHandle(IntPtr handle)
        {
            this.NativePtr = handle;
        }

        #endregion

        #region Methods

        #region Overrides

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            if (NativeMethods.MXPredFree(this.NativePtr) == NativeMethods.Error)
                throw new ApplicationException($"Failed to release {nameof(PredictorHandle)}");
        }

        #endregion

        #endregion

    }

}