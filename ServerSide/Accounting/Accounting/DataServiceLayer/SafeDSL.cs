using AutoMapper;
using Data.Entities;
using Accouting.DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities.Debit;
using Data.Entities.Debit;
using Shared.Entities.Shared;

namespace Accouting.DataServiceLayer
{
    public class SafeDSL : ISafeDSL
    {
        ISafeDAL _safeDAL;
        private readonly IMapper _mapper;
        public SafeDSL(ISafeDAL safeDAL, IMapper mapper)
        {
            this._safeDAL = safeDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(SafeDTO entity)
        {
            try
            {
                return await _safeDAL.Add(_mapper.Map<Safe>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _safeDAL.Delete(id);
        }

        public async Task<ResponseEntityList<SafeDTO>> GetAll(SafeDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<SafeDTO>>(await _safeDAL.GetAll());

                //var filteredList = list.Where(a =>
                //      //(String.IsNullOrEmpty(entity.Date.ToString()) ? true : a.Date.ToString().Contains(entity.Date.ToString()))
                //      (String.IsNullOrEmpty(entity.CarPlate) ? true : a.CarPlate.Contains(entity.CarPlate))
                //     && (String.IsNullOrEmpty(entity.Weight.ToString()) ? true : a.Weight.ToString().Contains(entity.Weight.ToString()))
                //     && (String.IsNullOrEmpty(entity.Price.ToString()) ? true : a.Price.ToString().Contains(entity.Price.ToString()))
                //     && (String.IsNullOrEmpty(entity.Debit.ToString()) ? true : a.Debit.ToString().Contains(entity.Debit.ToString()))
                //     && (String.IsNullOrEmpty(entity.Debit.ToString()) ? true : a.Debit.ToString().Contains(entity.Debit.ToString()))
                //     && (String.IsNullOrEmpty(entity.Total.ToString()) ? true : a.Total.ToString().Contains(entity.Total.ToString()))
                //     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                //     );

                ResponseEntityList<SafeDTO> responseEntityList = new ResponseEntityList<SafeDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<SafeDTO> GetById(long id)
        {
            return _mapper.Map<SafeDTO>(await _safeDAL.GetById(id));
        }

        public async Task<long> Update(SafeDTO entity)
        {
            return await _safeDAL.Update(_mapper.Map<Safe>(entity));
        }

        public async Task<ResponseEntityList<SafeDTO>> GetAllLite()
        {
            return new ResponseEntityList<SafeDTO>()
            {
                List = _mapper.Map<IEnumerable<SafeDTO>>(await _safeDAL.GetAll()).ToList(),
            };
        }
    }
}
