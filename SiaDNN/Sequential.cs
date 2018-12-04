﻿using MXNetDotNet;
using Newtonsoft.Json;
using SiaNet.EventArgs;
using SiaNet.Layers;
using SiaNet.Metrics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SiaNet
{
    public partial class Sequential
    {
        /// <summary>
        ///     Occurs when [on batch end].
        /// </summary>
        public event EventHandler<BatchEndEventArgs> BatchEnd;

        /// <summary>
        ///     Occurs when [on batch start].
        /// </summary>
        public event EventHandler<BatchStartEventArgs> BatchStart;

        /// <summary>
        ///     Occurs when [on epoch end].
        /// </summary>
        public event EventHandler<EpochEndEventArgs> EpochEnd;

        /// <summary>
        ///     Occurs when [on epoch start].
        /// </summary>
        public event EventHandler<EpochStartEventArgs> EpochStart;

        /// <summary>
        ///     Occurs when [on training end].
        /// </summary>
        public event EventHandler<TrainingEndEventArgs> TrainingEnd;

        private List<ILayer> layers = new List<ILayer>();

        public Shape InputShape { get; set; }

        public Shape OutputShape { get; set; }

        [JsonIgnore]
        public Symbol CompiledModel = null;

        public ILayer[] Layers
        {
            get => layers.ToArray();
        }

        [JsonIgnore]
        public Optimizer ModelOptimizer
        {
            get; set;
        }

        [JsonIgnore]
        public BaseMetric Metric { get; set; }

        private Dictionary<string, Symbol> trainableParams = new Dictionary<string, Symbol>();

        public Sequential(Shape inputShape, uint num_output)
        {
            InputShape = inputShape;
            OutputShape = new Shape(num_output);
            CompiledModel = Symbol.Variable("X");
        }

        public void AddHidden(ILayer l)
        {
            layers.Add(l);
        }

        public void Compile(Optimizer optimizer, LossType loss, string metric = "")
        {
            trainableParams.Clear();
            Dense outputLayer = new Dense((int)OutputShape.Size);
            Metric = !string.IsNullOrWhiteSpace(metric) ? MetricRegistry.Get(metric) : null;
            ModelOptimizer = optimizer;
            foreach (var layer in layers)
            {
                CompiledModel = layer.Build(CompiledModel);
            }

            CompiledModel = outputLayer.Build(CompiledModel);

            CompiledModel = Losses.Get(loss, CompiledModel, Symbol.Variable("label"));
        }

        public void Compile(OptimizerType optimizer, LossType loss, string metric = "")
        {
            Optimizer opt = Optimizers.Get(optimizer);
            Compile(opt, loss, metric);
        }

        public void SaveModel(string folder, bool saveSymbol = false)
        {
            string sequential = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(folder + "/seq.json", sequential);

            if (saveSymbol)
            {
                string symbol = CompiledModel.ToJSON();
                File.WriteAllText(folder + "/sym.json", symbol);
            }
        }
    }
}
