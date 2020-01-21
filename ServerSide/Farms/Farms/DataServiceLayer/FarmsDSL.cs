using AutoMapper;
using Data.Entities;
using Farms.DataAccessLayer;
using Farms.Models;
using Farms.RepositoryLayer;
using Microsoft.AspNetCore.Identity;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farms.DataServiceLayer
{
    public class FarmDSL : IFarmDSL
    {
        IFarmDAL _farmDAL;
        private readonly IMapper _mapper;
        public FarmDSL(IFarmDAL farmDAL, IMapper mapper)
        {
            this._farmDAL = farmDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(FarmDTO entity)
        {
            return await _farmDAL.Add(_mapper.Map<Farm>(entity));
        }

        public async Task<long> Delete(long id)
        {
            return await _farmDAL.Delete(id);
        }

        public async Task<ResponseEntityList<FarmDTO>> GetAll(FarmDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<FarmDTO>>(await _farmDAL.GetAll());

                var filteredList = list.Where(a =>
                        (String.IsNullOrEmpty(entity.OwnerName) ? true : a.OwnerName.Contains(entity.OwnerName))
                     && (String.IsNullOrEmpty(entity.OwnerMobile) ? true : a.OwnerMobile.Contains(entity.OwnerMobile))
                     && (String.IsNullOrEmpty(entity.Address) ? true : a.Address.Contains(entity.Address))
                     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                     );
                
                ResponseEntityList<FarmDTO> responseEntityList = new ResponseEntityList<FarmDTO>();
                responseEntityList.Total = filteredList.Count();
                responseEntityList.List = filteredList.Take(take).Skip(skip).ToList();
                
                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<FarmDTO> GetById(long id)
        {
            return _mapper.Map<FarmDTO>(await _farmDAL.GetById(id));
        }

        public async Task<long> Update(FarmDTO entity)
        {
            return await _farmDAL.Update(_mapper.Map<Farm>(entity));
        }
    }
}
