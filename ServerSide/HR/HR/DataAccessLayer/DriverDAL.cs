
using Data.Contexts;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clients.DataAccessLayer
{
    public class DriverDAL : IDriverDAL
    {
        private AppDbContext _context;
        private DbSet<Driver> _entity;

        public DriverDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Driver>();
        }

        public async Task<long> Save(Driver entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Driver farm = await GetById(id);
            _context.Drivers.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Driver>> GetAll()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task<Driver> GetById(long id)
        {
            return await _context.Drivers.SingleOrDefaultAsync(x => x.Id == id);
        }

    }
}
