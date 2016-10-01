using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.UI.Console
{
    public class RmRRepository
    {
        private CoilDataContext _context;

        public RmRRepository()
        {
            _context = new CoilDataContext();
        }

        public List<RmrData> GetRmrData()
        {
            return _context.Set<RmrData>().ToList();
        }
    }
}
