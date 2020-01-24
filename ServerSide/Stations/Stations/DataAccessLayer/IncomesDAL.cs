
using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Stations.DataAccessLayer
{
    public class IncomeDAL : IIncomeDAL
    {
        private AppDbContext _context;
        private DbSet<Income> _entity;

        public IncomeDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Income>();
        }

        public async Task<long> Add(Income entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Income farm = await GetById(id);
            _context.Incomes.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Income>> GetAll()
        {
            return await _context.Incomes.ToListAsync();
        }

        public async Task<Income> GetById(long id)
        {
            return await _context.Incomes.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(Income entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<Income>> GetIncomesByStationId(long stationId)
        {
            return await _context.Incomes.Where(x => x.StationId == stationId).ToListAsync();
        }
    }
}
