
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
    public class DebitCurrentDAL : IDebitCurrentDAL
    {
        private AppDbContext _context;
        private DbSet<DebitCurrent> _entity;

        public DebitCurrentDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<DebitCurrent>();
        }

        public async Task<long> Save(DebitCurrent entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            DebitCurrent farm = await GetById(id);
            _context.DebitCurrents.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<DebitCurrent>> GetAll()
        {
            return await _context.DebitCurrents.ToListAsync();
        }

        public async Task<DebitCurrent> GetById(long id)
        {
            return await _context.DebitCurrents.SingleOrDefaultAsync(x => x.Id == id);
        }

    }
}
