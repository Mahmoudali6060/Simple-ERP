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

        public async Task<ResponseEntityList<CategoryDTO>> GetAll(CategoryDTO entity)
        {
            try
            {
                //int take = entity.Page * entity.RecordPerPage;
                //int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<CategoryDTO>>(await _categoryDAL.GetAll());

                //var filteredList = list.Where(a =>
                //        (String.IsNullOrEmpty(entity.OwnerName) ? true : a.OwnerName.Contains(entity.OwnerName))
                //     && (String.IsNullOrEmpty(entity.OwnerMobile) ? true : a.OwnerMobile.Contains(entity.OwnerMobile))
                //     && (String.IsNullOrEmpty(entity.Address) ? true : a.Address.Contains(entity.Address))
                //     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                //     );

                ResponseEntityList<CategoryDTO> responseEntityList = new ResponseEntityList<CategoryDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


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
