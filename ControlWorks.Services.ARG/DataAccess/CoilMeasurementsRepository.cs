using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Services
{

    public class CoilMeasurementsRepository : IDisposable
    {
        private CoilDataContext _context;

        private bool _disposed = false;

        protected DbSet<CoilMeasurement> DbSet { get; set; }


        public CoilMeasurementsRepository() :this(new CoilDataContext())
        { }

        public CoilMeasurementsRepository(CoilDataContext context)
        {
            _context = context;
            DbSet = _context.Set<CoilMeasurement>();
        }
        public async Task Add(CoilMeasurement measurement)
        {
            DbSet.Add(measurement);
            await _context.SaveChangesAsync();
        }

        public async Task AddAll(IEnumerable<CoilMeasurement> measurements)
        {
            foreach (var m in measurements)
            {
                DbSet.Add(m);
            }
            await _context.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
