
using Data.Contexts;
using Data.Entities.Credit;
using Data.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using Shared.DataAccessLayer;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Accouting.DataAccessLayer
{
    public class TransactionDAL : ITransactionDAL
    {
        private AppDbContext _context;
        private DbSet<Transaction> _entity;

        public TransactionDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Transaction>();
        }

        public async Task<long> Add(Transaction entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Transaction transaction = await GetById(id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<TransactionDTO>> GetAll()
        {
            try
            {
                return (from t in _context.Transactions
                        join c in _context.Categories on t.CategoryId equals c.Id
                        join d in _context.Drivers on t.DriverId equals d.Id
                        join f in _context.Farms on t.FarmId equals f.Id
                        join s in _context.Stations on t.StationId equals s.Id
                        select new TransactionDTO
                        {
                            Date = t.Date,
                            FarmId = f.Id,
                            FarmOwnerName = f.OwnerName,
                            CategoryId = c.Id,
                            CategoryName = c.Name,
                            DriverId = d.Id,
                            CarPlate = d.CarPlate,
                            SupplierQuantity = t.SupplierQuantity,
                            Pardon = t.Pardon,
                            TotalAfterPardon = t.SupplierQuantity - t.Pardon,
                            SupplierPrice = t.SupplierPrice,
                            SupplierAmount = t.SupplierPrice * (t.SupplierQuantity - t.Pardon),
                            Nolon = t.Nolon,
                            ReapersPay = t.ReapersPay,
                            SelectorsPay = t.SelectorsPay,
                            FarmExpense = t.FarmExpense,
                            SupplierTotal = ((t.SupplierPrice * (t.SupplierQuantity - t.Pardon)) + t.Nolon + t.ReapersPay + t.SelectorsPay + t.FarmExpense),
                            StationId = t.StationId,
                            StationOwnerName = s.OwnerName,
                            CartNumber = t.CartNumber,
                            ClientQuantity = t.ClientQuantity,
                            ClientDiscount = t.ClientDiscount,
                            TotalAfterDiscount = t.ClientQuantity - t.ClientDiscount,
                            ClientPrice = t.ClientPrice,
                            ClientTotal = t.ClientPrice * (t.ClientQuantity - t.ClientDiscount),
                            Sum = (t.ClientPrice * (t.ClientQuantity - t.ClientDiscount)) - ((t.SupplierPrice * (t.SupplierQuantity - t.Pardon)) + t.Nolon + t.ReapersPay + t.SelectorsPay + t.FarmExpense)
                        });

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<Transaction> GetById(long id)
        {
            return await _context.Transactions.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(Transaction entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        Task<IEnumerable<Transaction>> ICRUDOperationsDAL<Transaction>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
