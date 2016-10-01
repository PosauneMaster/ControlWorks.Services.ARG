using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Database.SqlServer
{
    class SensorReportRepository : Repository<SensorReport>
    {
        public SensorReportRepository() { }
        public SensorReportRepository(CoilInfoContext context) : base(context)
        {
        }

        public void Insert(int id, IEnumerable<SensorReportInternal> reports)
        {
            foreach (var r in reports)
            {
                var entity = new SensorReport
                {
                    CoilDataId = id,
                    SensorMeasurement = r.SensorMeasurement,
                    MeasurementCount = r.MeasurementCount
                };
                DbSet.Add(entity);
            }
            Context.SaveChanges();
        }
    }
}
