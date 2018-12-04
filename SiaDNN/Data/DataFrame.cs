using MXNetDotNet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using CsvHelper;

namespace SiaNet.Data
{
    public class DataFrame : NDArray
    {
        List<float> dataList = new List<float>();

        public DataFrame(params uint[] shape)
            :base(shape)
        {
            
        }

        public DataFrame(Shape shape, params float[] data)
            : base(data, shape)
        {
            dataList = data.ToList();
        }

        public void AddData(params float[] data)
        {
            dataList.AddRange(data);
            SyncCopyFromCPU(dataList.ToArray());
        }

        public new float[] GetData()
        {
            return dataList.ToArray();
        }

        public static DataFrame ReadCsv(string path, bool hasHeaders = false, string delimiter = ",")
        {
            using (TextReader fileReader = File.OpenText(path))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = false;
            }

            return new DataFrame(1, 1);
        }
    }
}
