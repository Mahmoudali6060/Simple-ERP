
using Data.Contexts;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.DataAccessLayer
{
    public class FarmDAL : IFarmDAL
    {
        private AppDbContext _context;
        private DbSet<Farm> _entity;

        public FarmDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Farm>();
        }

        public async Task<long> Add(Farm entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Farm farm = await GetById(id);
            _context.Farms.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Farm>> GetAll()
        {
            return await _context.Farms.ToListAsync();
        }

        public async Task<Farm> GetById(long id)
        {
            return await _context.Farms.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(Farm entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
