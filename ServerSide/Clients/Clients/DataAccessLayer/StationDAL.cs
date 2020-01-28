
using Data.Contexts;
using Data.Entities;
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
    public class StationDAL : IStationDAL
    {
        private AppDbContext _context;
        private DbSet<Station> _entity;

        public StationDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Station>();
        }

        public async Task<long> Add(Station entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Station farm = await GetById(id);
            _context.Stations.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Station>> GetAll()
        {
            return await _context.Stations.ToListAsync();
        }

        public async Task<Station> GetById(long id)
        {
            return await _context.Stations.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(Station entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
