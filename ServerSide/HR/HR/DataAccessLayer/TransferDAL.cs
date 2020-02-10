
using Data.Contexts;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using Shared.DataAccessLayer;
using Shared.Entities.Credit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Clients.DataAccessLayer
{
    public class TransferDAL : ITransferDAL
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Transfer> _entity;

        public TransferDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Transfer>();
        }

        public async Task<long> Add(Transfer entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Transfer farm = await GetById(id);
            _context.Transfers.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<TransferDTO>> GetAll()
        {
            try
            {
                return from t in _context.Transfers
                       join f in _context.Farms on t.FarmId equals f.Id
                       join s in _context.Stations on t.StationId equals s.Id
                       select new TransferDTO
                       {
                           Date = t.Date,
                           FarmId = f.Id,
                           FarmName = f.OwnerName,
                           StationId = s.Id,
                           StationName = s.OwnerName,
                           Nolon = t.Nolon,
                           Custody = t.Custody,
                           Withdraws = t.Withdraws,
                           Balance = t.Balance,
                           Notes = t.Notes
                       };

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<Transfer> GetById(long id)
        {
            return await _context.Transfers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(Transfer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        Task<IEnumerable<Transfer>> ICRUDOperationsDAL<Transfer>.GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
