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
    public class CreditCurrentDAL : ICreditCurrentDAL
    {
        private AppDbContext _context;
        private DbSet<CreditCurrent> _entity;

        public CreditCurrentDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<CreditCurrent>();
        }

        public async Task<long> Save(CreditCurrent entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            CreditCurrent farm = await GetById(id);
            _context.CreditCurrents.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<CreditCurrent>> GetAll()
        {
            return await _context.CreditCurrents.ToListAsync();
        }

        public async Task<CreditCurrent> GetById(long id)
        {
            return await _context.CreditCurrents.SingleOrDefaultAsync(x => x.Id == id);
        }

    }
}
