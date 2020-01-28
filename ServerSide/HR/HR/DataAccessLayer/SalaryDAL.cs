
using Data.Contexts;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clients.DataAccessLayer
{
    public class SalaryDAL : ISalaryDAL
    {
        private AppDbContext _context;
        private DbSet<Salary> _entity;

        public SalaryDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Salary>();
        }

        public async Task<long> Add(Salary entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Salary farm = await GetById(id);
            _context.Salaries.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Salary>> GetAll()
        {
            return await _context.Salaries.ToListAsync();
        }

        public async Task<Salary> GetById(long id)
        {
            return await _context.Salaries.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(Salary entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
