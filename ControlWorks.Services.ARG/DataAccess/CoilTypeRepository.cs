using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Services
{
    public class CoilTypeRepository : IDisposable
    {
        private CoilDataContext _context;
        private bool _disposed = false;

        protected DbSet<CoilType> DbSet { get; set; }


        public CoilTypeRepository() :this(new CoilDataContext())
        { }

        public CoilTypeRepository(CoilDataContext context)
        {
            _context = context;
            DbSet = _context.Set<CoilType>();
        }

        public async Task<CoilType> Add(CoilType coilType)
        {
            DbSet.Add(coilType);
            await _context.SaveChangesAsync();

            return coilType;
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
