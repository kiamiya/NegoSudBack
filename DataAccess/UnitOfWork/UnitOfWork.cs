using DataAccess.dbContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NegoSudDBContext _db;

        public UnitOfWork(NegoSudDBContext db)
        {
            _db = db;
        }

        public async Task SaveIntoDbContextAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}