
using Data.Contexts;
using Data.Entities.Credit;
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
    public class SafeDAL : ISafeDAL
    {
        private AppDbContext _context;
        private DbSet<Safe> _entity;

        public SafeDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Safe>();
        }

        public async Task<long> Save(Safe entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Safe farm = await GetById(id);
            _context.Safes.Remove(farm);

            ///Delete related table >>> Should be in DSL Layer
            /////[1] FarmAccount
            var farmAccount = _context.FarmAccounts.Where(x => x.SafeId == id);
            _context.FarmAccounts.RemoveRange(farmAccount);
            /////[2] StationAccount
            var stationAccount = _context.StationAccounts.Where(x => x.SafeId == id);
            _context.StationAccounts.RemoveRange(stationAccount);
            /////[3] DriverAccount
            var driverAccount = _context.DriverAccounts.Where(x => x.SafeId == id);
            _context.DriverAccounts.RemoveRange(driverAccount);
            /////[4] ReaperAccount
            var reaperAccount = _context.ReaperAccounts.Where(x => x.SafeId == id);
            _context.ReaperAccounts.RemoveRange(reaperAccount);
            /////[5] SelectorAccount
            var selectorAccount = _context.SelectorAccounts.Where(x => x.SafeId == id);
            _context.SelectorAccounts.RemoveRange(selectorAccount);

            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Safe>> GetAll()
        {
            return await _context.Safes.ToListAsync();
        }

        public async Task<Safe> GetById(long id)
        {
            return await _context.Safes.SingleOrDefaultAsync(x => x.Id == id);
        }

        public FarmAccount GetFarmAccountBySafeId(long safeId)
        {
            return _context.FarmAccounts.Where(x => x.SafeId == safeId).SingleOrDefault();
        }

        public StationAccount GetStationAccountBySafeId(long safeId)
        {
            return _context.StationAccounts.Where(x => x.SafeId == safeId).SingleOrDefault();
        }

        public DriverAccount GetDriverAccountBySafeId(long safeId)
        {
            return _context.DriverAccounts.Where(x => x.SafeId == safeId).SingleOrDefault();
        }

        public SelectorAccount GetSelectorAccountBySafeId(long safeId)
        {
            return _context.SelectorAccounts.Where(x => x.SafeId == safeId).SingleOrDefault();
        }

        public ReaperAccount GetReaperAccountBySafeId(long safeId)
        {
            return _context.ReaperAccounts.Where(x => x.SafeId == safeId).SingleOrDefault();
        }

        public async Task<long> UpdateAccountName(int accountId, string accountName)
        {
            try
            {
                var safes = (from s in _context.Safes
                             where s.AccountId == accountId
                             select new Safe
                             {
                                 Id = s.Id,
                                 AccountNameAr = accountName
                             });
                _context.Safes.UpdateRange(safes);
                await _context.SaveChangesAsync();
                return accountId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
