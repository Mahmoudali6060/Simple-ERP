
using Data.Contexts;
using Data.Entities.Debit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Accouting.DataAccessLayer
{
    public class DebitBorrowDAL : IDebitBorrowDAL
    {
        private AppDbContext _context;
        private DbSet<DebitBorrow> _entity;

        public DebitBorrowDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<DebitBorrow>();
        }

        public async Task<long> Save(DebitBorrow entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            DebitBorrow farm = await GetById(id);
            _context.DebitBorrows.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<DebitBorrow>> GetAll()
        {
            return await _context.DebitBorrows.ToListAsync();
        }

        public async Task<DebitBorrow> GetById(long id)
        {
            return await _context.DebitBorrows.SingleOrDefaultAsync(x => x.Id == id);
        }

    }
}
