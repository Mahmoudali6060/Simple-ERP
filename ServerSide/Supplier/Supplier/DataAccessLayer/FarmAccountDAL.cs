
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
    public class FarmAccountDAL : IFarmAccountDAL
    {
        private AppDbContext _context;
        private DbSet<FarmAccount> _entity;

        public FarmAccountDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<FarmAccount>();
        }

        public async Task<long> Save(FarmAccount entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            FarmAccount farmAccount = await GetById(id);
            _context.FarmAccounts.Remove(farmAccount);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<FarmAccount>> GetAll()
        {
            return await _context.FarmAccounts.ToListAsync();
        }

        public async Task<FarmAccount> GetById(long id)
        {
            return await _context.FarmAccounts.SingleOrDefaultAsync(x => x.Id == id);
        }


        public async Task<IEnumerable<FarmAccount>> GetAllByFarmId(long farmId)
        {
            return await _context.FarmAccounts.Where(x => x.FarmId == farmId).ToListAsync();
        }
    }
}
