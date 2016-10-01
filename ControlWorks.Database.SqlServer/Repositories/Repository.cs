using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Database.SqlServer
{
    public class Repository<T> : IDisposable where T : class
    {

        protected CoilInfoContext Context { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public Repository() { }
        public Repository(CoilInfoContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        private bool _disposed;
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
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
