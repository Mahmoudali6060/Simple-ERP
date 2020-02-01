
using Data.Contexts;
using Data.Entities.Credit;
using Data.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Accouting.DataAccessLayer
{
    public class CategoryDAL : ICategoryDAL
    {
        private AppDbContext _context;
        private DbSet<Category> _entity;

        public CategoryDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Category>();
        }

        public async Task<long> Add(Category entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Category category = await GetById(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(long id)
        {
            return await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
