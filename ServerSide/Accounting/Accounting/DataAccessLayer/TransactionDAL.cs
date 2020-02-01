
using Data.Contexts;
using Data.Entities.Credit;
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
    public class TransactionDAL : ITransactionDAL
    {
        private AppDbContext _context;
        private DbSet<Transaction> _entity;

        public TransactionDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Transaction>();
        }

        public async Task<long> Add(Transaction entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Transaction transaction = await GetById(id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _context.Transactions.OrderByDescending(x => x.Date).ToListAsync();
        }

        public async Task<Transaction> GetById(long id)
        {
            return await _context.Transactions.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(Transaction entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
