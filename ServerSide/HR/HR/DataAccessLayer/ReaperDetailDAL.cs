
using Data.Contexts;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using Shared.Entities.Credit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Clients.DataAccessLayer
{
    public class ReaperDetailDAL : IReaperDetailDAL
    {
        private AppDbContext _context;
        private DbSet<ReaperDetail> _entity;

        public ReaperDetailDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<ReaperDetail>();
        }

        public async Task<long> Save(ReaperDetail entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            ReaperDetail farm = await GetById(id);
            _context.ReaperDetails.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<ReaperDetail>> GetAll()
        {
            return await _context.ReaperDetails.ToListAsync();
        }

        public async Task<ReaperDetail> GetById(long id)
        {
            return await _context.ReaperDetails.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ReaperDetailDTO>> GetAllByReaperId(long reaperId)
        {

            try
            {
                return from rd in _context.ReaperDetails
                       join r in _context.Reapers on rd.ReaperId equals r.Id
                       where rd.ReaperId == reaperId
                       orderby rd.Date
                       select new ReaperDetailDTO
                       {
                           Date = rd.Date,
                           Weight = rd.Weight,
                           Price = rd.Price,
                           HeadName = r.HeadName,
                           Reaper = new ReaperDTO()
                           {
                               HeadName = r.HeadName,
                               LastTonPrice = r.LastTonPrice,
                               Balance = r.Balance
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
