using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Database.SqlServer
{
    public class SensorDataRepository : Repository<SensorData>
    {
        public SensorDataRepository() { }
        public SensorDataRepository(CoilInfoContext context) : base(context)
        {
        }

        public void Insert(int coilDataId, IEnumerable<SensorDataInternal> sensorData)
        {
            foreach(var data in sensorData)
            {
                var entity = MapFromInternal(coilDataId, data);
                DbSet.Add(entity);
            }
            Context.SaveChanges();
        }

        public SensorData MapFromInternal(int coilDataId, SensorDataInternal data)
        {
            var entity = new SensorData
            {
                CoilDataId = coilDataId,
                SensorNumber = data.SensorNumber,
                Position = data.Position,
                SensorData0 = data.SensorData0,
                SensorData1 = data.SensorData1,
                SensorData2 = data.SensorData2,
                SensorData3 = data.SensorData3,
                SensorData4 = data.SensorData4
            };

            return entity;
        }


    }
}
