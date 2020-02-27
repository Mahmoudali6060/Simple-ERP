
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
    public class SelectorAccountDAL : ISelectorAccountDAL
    {
        private AppDbContext _context;
        private DbSet<SelectorAccount> _entity;

        public SelectorAccountDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<SelectorAccount>();
        }

        public async Task<long> Save(SelectorAccount entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            SelectorAccount driverAccount = await GetById(id);
            _context.SelectorAccounts.Remove(driverAccount);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<SelectorAccount>> GetAll()
        {
            return await _context.SelectorAccounts.ToListAsync();
        }

        public async Task<SelectorAccount> GetById(long id)
        {
            return await _context.SelectorAccounts.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<SelectorAccount>> GetAllBySelectorId(long selectorId)
        {
            return await _context.SelectorAccounts.Where(x => x.SelectorId == selectorId).ToListAsync();
        }
    }
}
