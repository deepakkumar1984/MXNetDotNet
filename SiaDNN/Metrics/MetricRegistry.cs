using System;
using System.Collections.Generic;
using System.Text;

namespace SiaNet.Metrics
{
    public class MetricRegistry
    {
        private static Dictionary<string, BaseMetric> metrics = new Dictionary<string, BaseMetric>();

        public static BaseMetric Get(string name)
        {
            metrics.Clear();
            metrics.Add("accuracy", new Accuracy());

            return metrics[name.ToLowerInvariant()];
        }
    }
}
