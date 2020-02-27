
using Data.Contexts;
using Data.Entities.Credit;
using Data.Entities.Debit;
using Microsoft.EntityFrameworkCore;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.DataAccessLayer
{
    public class StationAccountDAL : IStationAccountDAL
    {
        private AppDbContext _context;
        private DbSet<StationAccount> _entity;

        public StationAccountDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<StationAccount>();
        }

        public async Task<long> Save(StationAccount entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            StationAccount stationAccount = await GetById(id);
            _context.StationAccounts.Remove(stationAccount);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<StationAccount>> GetAll()
        {
            return await _context.StationAccounts.ToListAsync();
        }

        public async Task<StationAccount> GetById(long id)
        {
            return await _context.StationAccounts.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<StationAccount>> GetAllByStationId(long stationId)
        {
            return await _context.StationAccounts.Where(x => x.StationId == stationId).ToListAsync();
        }
    }
}
