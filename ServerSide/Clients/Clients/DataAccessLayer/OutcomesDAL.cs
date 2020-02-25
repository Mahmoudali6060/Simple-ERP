
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

        public async Task<long> Save(Outcome entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Detached;
                _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
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
                return (from o in _context.Outcomes
                        join c in _context.Categories on o.CategoryId equals c.Id
                        join d in _context.Drivers on o.DriverId equals d.Id
                        join f in _context.Farms on o.FarmId equals f.Id
                        join s in _context.Stations on o.StationId equals s.Id
                        select new OutcomeDTO
                        {
                            Date = o.Date,
                            CartNumber = o.CartNumber,
                            CategoryId = c.Id,
                            CategoryName = c.Name,
                            FarmId = f.Id,
                            FarmName = f.OwnerName,
                            DriverId = d.Id,
                            CarPlate = d.CarPlate,
                            Quantity = o.Quantity,
                            KiloDiscount = o.KiloDiscount,
                            QuantityAfterDiscount = o.Quantity - o.KiloDiscount,
                            KiloPrice = o.KiloPrice,
                            Total = o.KiloPrice * (o.Quantity - o.KiloDiscount),
                            MoneyDiscount = o.MoneyDiscount,
                            //Balance = (o.KiloPrice * (o.Quantity - o.KiloDiscount)) - (decimal)o.PaidUp,
                            Balance = (o.KiloPrice * (o.Quantity - o.KiloDiscount)),
                            StationId = s.Id,
                            StationName = s.OwnerName,
                            //PaidUp = o.PaidUp,
                            //PaidDate = o.PaidDate,
                            //RecieptNumber = o.RecieptNumber,
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
