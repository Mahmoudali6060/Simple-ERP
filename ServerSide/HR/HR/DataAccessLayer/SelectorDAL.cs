
using Data.Contexts;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clients.DataAccessLayer
{
    public class SelectorDAL : ISelectorDAL
    {
        private AppDbContext _context;
        private DbSet<Selector> _entity;

        public SelectorDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Selector>();
        }

        public async Task<long> Save(Selector entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Selector farm = await GetById(id);
            _context.Selectors.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Selector>> GetAll()
        {
            return await _context.Selectors.ToListAsync();
        }

        public async Task<Selector> GetById(long id)
        {
            return await _context.Selectors.SingleOrDefaultAsync(x => x.Id == id);
        }

    }
}
