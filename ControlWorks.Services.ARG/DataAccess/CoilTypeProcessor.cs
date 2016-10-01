using ControlWorks.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlWorks.Services
{
    public class CoilTypeProcessor
    {
        protected ILogger Logger { get; set; }

        public CoilTypeProcessor(ILogger logger)
        {
            Logger = logger;
        }

        public async Task ProcessCsv(string csvData)
        {
            Logger.LogDebug("Begin processing data");

            try
            {
                var mapper = new CoilTypeMapper();
                var coilTypes = mapper.MapFromCsv(csvData);

                await ProcessCoilTypes(coilTypes);

                await ProcessMeasurements(coilTypes);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

            Logger.LogDebug("End processing data");
        }

        private async Task ProcessCoilTypes(List<CoilType> coilTypes)
        {
            var mapper = new CoilMeasurementMapper();

            using (var repository = new CoilTypeRepository())
            {
                foreach (var coil in coilTypes)
                {
                    coil.Mean = mapper.Mean(coil);
                    await repository.Add(coil);
                }
            }
        }

        private async Task ProcessMeasurements(List<CoilType> coilTypes)
        {
            using (var repository = new CoilMeasurementsRepository())
            {
                foreach (var coil in coilTypes)
                {
                    var measureMapper = new CoilMeasurementMapper();
                    var measurements = measureMapper.MapFromCsv(coil);

                    await repository.AddAll(measurements);
                }
            }
        }
    }
}
