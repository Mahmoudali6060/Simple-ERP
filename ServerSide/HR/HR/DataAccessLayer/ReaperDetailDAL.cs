
using Data.Contexts;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clients.DataAccessLayer
{
    public class ReaperDetailDAL : IReaperDetailDAL
    {
        private AppDbContext _context;
        private DbSet<ReaperDetail> _entity;

        public ReaperDetailDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<ReaperDetail>();
        }

        public async Task<long> Add(ReaperDetail entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            ReaperDetail farm = await GetById(id);
            _context.ReaperDetails.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<ReaperDetail>> GetAll()
        {
            return await _context.ReaperDetails.ToListAsync();
        }

        public async Task<ReaperDetail> GetById(long id)
        {
            return await _context.ReaperDetails.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(ReaperDetail entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
