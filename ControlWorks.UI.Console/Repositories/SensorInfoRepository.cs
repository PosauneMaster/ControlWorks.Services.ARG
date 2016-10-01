using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.UI.Console
{
    public class SensorInfoRepository
    {
        private CoilDataContext _context;

        public SensorInfoRepository()
        {
            _context = new CoilDataContext();
        }

        public List<SensorData> GetSensorData(int coilId)
        {
            return _context.Set<SensorData>().Where(s => s.CoilDataId.Value == coilId).ToList();
        }
    }
}
