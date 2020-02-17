
using Data.Contexts;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using Shared.Entities.Credit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Clients.DataAccessLayer
{
    public class SelectorDetialDAL : ISelectorDetailDAL
    {
        private AppDbContext _context;
        private DbSet<SelectorDetail> _entity;

        public SelectorDetialDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<SelectorDetail>();
        }

        public async Task<long> Save(SelectorDetail entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            SelectorDetail farm = await GetById(id);
            _context.SelectorDetails.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<SelectorDetail>> GetAll()
        {
            return await _context.SelectorDetails.ToListAsync();
        }

        public async Task<SelectorDetail> GetById(long id)
        {
            return await _context.SelectorDetails.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<SelectorDetailDTO>> GetAllBySelectorId(long selectorId)
        {
            try
            {
                return from sd in _context.SelectorDetails
                       join s in _context.Selectors on sd.SelectorId equals s.Id
                       where sd.SelectorId == selectorId
                       select new SelectorDetailDTO
                       {
                           PayDate = sd.PayDate,
                           Pay = sd.Pay,
                           WithdrawsDate = sd.WithdrawsDate,
                           Withdraws = sd.Withdraws,
                           Balance = sd.Balance,
                           Selector = new SelectorDTO()
                           {
                               HeadName = s.HeadName,
                               LastTonPrice = s.LastTonPrice,
                               Balance = s.Balance
                           }
                       };
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
