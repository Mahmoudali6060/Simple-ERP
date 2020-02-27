
using Data.Contexts;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.DataAccessLayer
{
    public class ReaperAccountDAL : IReaperAccountDAL
    {
        private AppDbContext _context;
        private DbSet<ReaperAccount> _entity;

        public ReaperAccountDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<ReaperAccount>();
        }

        public async Task<long> Save(ReaperAccount entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            ReaperAccount reaperAccount = await GetById(id);
            _context.ReaperAccounts.Remove(reaperAccount);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<ReaperAccount>> GetAll()
        {
            return await _context.ReaperAccounts.ToListAsync();
        }

        public async Task<ReaperAccount> GetById(long id)
        {
            return await _context.ReaperAccounts.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ReaperAccount>> GetAllByReaperId(long reaperId)
        {
            return await _context.ReaperAccounts.Where(x => x.ReaperId == reaperId).ToListAsync();
        }
    }
}
