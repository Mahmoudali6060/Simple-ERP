
using Data.Contexts;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clients.DataAccessLayer
{
    public class TransferDAL : ITransferDAL
    {
        private AppDbContext _context;
        private DbSet<Transfer> _entity;

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

        public async Task<IEnumerable<Transfer>> GetAll()
        {
            return await _context.Transfers.ToListAsync();
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
    }
}
