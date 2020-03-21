
using Data.Contexts;
using Data.Entities.Credit;
using Data.Entities.Debit;
using Data.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Accouting.DataAccessLayer
{
    public class AccountTreeDAL : IAccountTreeDAL
    {
        private AppDbContext _context;
        private DbSet<AccountTree> _entity;

        public AccountTreeDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<AccountTree>();
        }

        public async Task<long> Save(AccountTree entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            AccountTree farm = await GetById(id);
            _context.AccountTrees.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<AccountTree>> GetAll()
        {
            return await _context.AccountTrees.ToListAsync();
        }

        public async Task<AccountTree> GetById(long id)
        {
            return await _context.AccountTrees.SingleOrDefaultAsync(x => x.Id == id);
        }

    }
}
