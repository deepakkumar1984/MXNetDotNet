﻿using MXNetDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiaNet.Metrics
{
    public sealed class Accuracy : BaseMetric
    {
        #region Constructors

        public Accuracy() : base("accuracy") { }

        #endregion

        #region Methods

        public override void Update(NDArray labels, NDArray preds)
        {
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            if (preds == null)
                throw new ArgumentNullException(nameof(preds));

            Logging.CHECK_EQ(labels.GetShape().Count, preds.GetShape().Count);

            var len = labels.GetShape()[0];
            var predData = new float[len];
            var labelData = new float[len];

            predData = preds.ArgmaxChannel().AsArray();
            labels.SyncCopyToCPU(labelData);

            for (var i = 0; i < len; ++i)
            {
                this.SumMetric += Math.Abs(predData[i] - labelData[i]) < float.Epsilon ? 1 : 0;
                this.NumInst += 1;
            }
        }

        #endregion

    }
}
