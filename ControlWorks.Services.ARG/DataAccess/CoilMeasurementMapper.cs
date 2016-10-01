using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Services
{
    public class CoilMeasurementMapper
    {
        public List<CoilMeasurement> MapFromCsv(CoilType coilType)
        {
            var measurements = new Dictionary<decimal, CoilMeasurement>();

            try
            {
                var reader = new StringReader(coilType.Data);
                var parser = new CsvParser(reader);

                string[] row = parser.Read();

                foreach (var m in row)
                {
                    decimal d;
                    if (Decimal.TryParse(m, out d))
                    {
                        if (!measurements.ContainsKey(d))
                        {
                            measurements.Add(d, new CoilMeasurement()
                            {
                                CoilTypeId = coilType.CoilTypeId,
                                Measurement = d,
                                MeasurementCount = 0
                            });
                        }
                        measurements[d].MeasurementCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return measurements.Values.ToList();
        }

        public decimal Mean(CoilType coilType)
        {
            var list = MapFromCsv(coilType);

            decimal count = Decimal.Zero;
            decimal weight = Decimal.Zero;

            foreach (var c in list)
            {
                count = count + c.MeasurementCount;
                weight = weight + (c.MeasurementCount * c.Measurement);
            }

            return weight / count;
        }
    }
}
