
using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Farms.DataAccessLayer
{
    public class ExportDAL : IExportDAL
    {
        private AppDbContext _context;
        private DbSet<Export> _entity;

        public ExportDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Export>();
        }

        public async Task<long> Add(Export entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Export entity = await GetById(id);
            _context.Exports.Remove(entity);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Export>> GetAll()
        {
            return await _context.Exports.ToListAsync();
        }

        public async Task<Export> GetById(long id)
        {
            return await _context.Exports.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(Export entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<Export>> GetExportsByFarmId(long farmId)
        {
            return await _context.Exports.Where(x => x.FarmId == farmId).ToListAsync();
        }
    }
}
