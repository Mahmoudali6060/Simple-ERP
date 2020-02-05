
using Data.Contexts;
using Data.Entities.Debit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clients.DataAccessLayer
{
    public class OutcomeDAL : IOutcomeDAL
    {
        private AppDbContext _context;
        private DbSet<Outcome> _entity;

        public OutcomeDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Outcome>();
        }

        public async Task<long> Add(Outcome entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Outcome farm = await GetById(id);
            _context.Outcomes.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Outcome>> GetAll()
        {
            return await _context.Outcomes.ToListAsync();
        }

        public async Task<Outcome> GetById(long id)
        {
            return await _context.Outcomes.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(Outcome entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<Outcome>> GetOutcomesByStationId(long stationId)
        {
            return await _context.Outcomes.Where(x => x.StationId == stationId).ToListAsync();
        }
    }
}
