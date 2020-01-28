
using Data.Contexts;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Accouting.DataAccessLayer
{
    public class CreditBorrowDAL : ICreditBorrowDAL
    {
        private AppDbContext _context;
        private DbSet<CreditBorrow> _entity;

        public CreditBorrowDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<CreditBorrow>();
        }

        public async Task<long> Add(CreditBorrow entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            CreditBorrow farm = await GetById(id);
            _context.CreditBorrows.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<CreditBorrow>> GetAll()
        {
            return await _context.CreditBorrows.ToListAsync();
        }

        public async Task<CreditBorrow> GetById(long id)
        {
            return await _context.CreditBorrows.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(CreditBorrow entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
