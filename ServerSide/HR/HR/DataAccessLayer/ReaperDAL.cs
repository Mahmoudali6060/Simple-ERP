
using Data.Contexts;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clients.DataAccessLayer
{
    public class ReaperDAL : IReaperDAL
    {
        private AppDbContext _context;
        private DbSet<Reaper> _entity;

        public ReaperDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Reaper>();
        }

        public async Task<long> Add(Reaper entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Reaper farm = await GetById(id);
            _context.Reapers.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Reaper>> GetAll()
        {
            return await _context.Reapers.ToListAsync();
        }

        public async Task<Reaper> GetById(long id)
        {
            return await _context.Reapers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(Reaper entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
