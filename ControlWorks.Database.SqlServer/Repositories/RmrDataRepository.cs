using System;
using System.Linq;

namespace ControlWorks.Database.SqlServer
{
    public class RmrDataRepository : Repository<RmrData>
    {
        public RmrDataRepository() { }
        public RmrDataRepository(CoilInfoContext context) : base(context)
        {
        }

        public string GetRmR(string material)
        {
            var mat = DbSet.FirstOrDefault(r => r.Material.Equals(material));
            return mat == null ? String.Empty : mat.RMR;
        }
    }
}
