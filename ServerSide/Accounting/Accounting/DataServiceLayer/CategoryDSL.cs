using AutoMapper;
using Data.Entities;
using Supplier.DataAccessLayer;
using Supplier.RepositoryLayer;
using Microsoft.AspNetCore.Identity;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Credit;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using Data.Entities.Shared;
using Accouting.DataAccessLayer;
using Shared.Classes;

namespace Accouting.DataServiceLayer
{
    public class CategoryDSL : ICategoryDSL
    {
        ICategoryDAL _categoryDAL;
        private readonly IMapper _mapper;
        public CategoryDSL(ICategoryDAL categoryDAL, IMapper mapper)
        {
            this._categoryDAL = categoryDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(CategoryDTO entity)
        {
            return await _categoryDAL.Add(_mapper.Map<Category>(entity));
        }

        public async Task<long> Delete(long id)
        {
            return await _categoryDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<CategoryDTO>>(await _categoryDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<CategoryDTO> GetById(long id)
        {
            return _mapper.Map<CategoryDTO>(await _categoryDAL.GetById(id));
        }

        public async Task<long> Update(CategoryDTO entity)
        {
            return await _categoryDAL.Update(_mapper.Map<Category>(entity));
        }

        public async Task<ResponseEntityList<CategoryDTO>> GetAllLite()
        {
            return new ResponseEntityList<CategoryDTO>()
            {
                List = _mapper.Map<IEnumerable<CategoryDTO>>(await _categoryDAL.GetAll()).ToList(),
            };
        }
    }
}
