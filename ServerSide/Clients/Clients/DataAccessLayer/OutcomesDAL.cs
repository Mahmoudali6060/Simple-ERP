
using Data.Contexts;
using Data.Entities.Debit;
using Microsoft.EntityFrameworkCore;
using Shared.DataAccessLayer;
using Shared.Entities.Debit;
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

       

        public async Task<IEnumerable<OutcomeDTO>> GetAll()
        {
            try
            {
                return (from i in _context.Outcomes
                        join c in _context.Categories on i.CategoryId equals c.Id
                        join d in _context.Drivers on i.DriverId equals d.Id
                        join f in _context.Farms on i.FarmId equals f.Id
                        join s in _context.Stations on i.StationId equals s.Id
                        select new OutcomeDTO
                        {
                            Date = i.Date,
                            CartNumber = d.CarPlate,
                            CategoryId = c.Id,
                            CategoryName = c.Name,
                            FarmId = f.Id,
                            FarmName = f.OwnerName,
                            DriverId = d.Id,
                            CarPlate = d.CarPlate,
                            Quantity = i.Quantity,
                            KiloDiscount = i.KiloDiscount,
                            Total = i.Total,
                            KiloPrice = i.KiloPrice,
                            MoneyDiscount = i.MoneyDiscount,
                            Balance = i.Balance,
                            StationId = s.Id,
                            StationName = s.OwnerName,
                            PaidUp = i.PaidUp,
                            PaidDate = i.PaidDate,
                            RecieptNumber = i.RecieptNumber,
                        });

            }
            catch (Exception ex)
            {
                return null;
            }
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

        Task<IEnumerable<Outcome>> ICRUDOperationsDAL<Outcome>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
