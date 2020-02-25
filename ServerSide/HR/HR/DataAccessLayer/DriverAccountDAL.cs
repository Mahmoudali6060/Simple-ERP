
using Data.Contexts;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.DataAccessLayer
{
    public class DriverAccountDAL : IDriverAccountDAL
    {
        private AppDbContext _context;
        private DbSet<DriverAccount> _entity;

        public DriverAccountDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<DriverAccount>();
        }

        public async Task<long> Save(DriverAccount entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            DriverAccount driverAccount = await GetById(id);
            _context.DriverAccounts.Remove(driverAccount);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<DriverAccount>> GetAll()
        {
            return await _context.DriverAccounts.ToListAsync();
        }

        public async Task<DriverAccount> GetById(long id)
        {
            return await _context.DriverAccounts.SingleOrDefaultAsync(x => x.Id == id);
        }

    }
}
