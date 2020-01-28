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
using Shared.Entities.Credit;
using Data.Entities.Credit;

namespace Accouting.DataServiceLayer
{
    public class CreditCurrentDSL : ICreditCurrentDSL
    {
        ICreditCurrentDAL _creditCurrentDAL;
        private readonly IMapper _mapper;
        public CreditCurrentDSL(ICreditCurrentDAL creditCurrentDAL, IMapper mapper)
        {
            this._creditCurrentDAL = creditCurrentDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(CreditCurrentDTO entity)
        {
            try
            {
                return await _creditCurrentDAL.Add(_mapper.Map<CreditCurrent>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _creditCurrentDAL.Delete(id);
        }

        public async Task<ResponseEntityList<CreditCurrentDTO>> GetAll(CreditCurrentDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<CreditCurrentDTO>>(await _creditCurrentDAL.GetAll());

                //var filteredList = list.Where(a =>
                //      //(String.IsNullOrEmpty(entity.Date.ToString()) ? true : a.Date.ToString().Contains(entity.Date.ToString()))
                //      (String.IsNullOrEmpty(entity.CarPlate) ? true : a.CarPlate.Contains(entity.CarPlate))
                //     && (String.IsNullOrEmpty(entity.Weight.ToString()) ? true : a.Weight.ToString().Contains(entity.Weight.ToString()))
                //     && (String.IsNullOrEmpty(entity.Price.ToString()) ? true : a.Price.ToString().Contains(entity.Price.ToString()))
                //     && (String.IsNullOrEmpty(entity.Debit.ToString()) ? true : a.Debit.ToString().Contains(entity.Debit.ToString()))
                //     && (String.IsNullOrEmpty(entity.Credit.ToString()) ? true : a.Credit.ToString().Contains(entity.Credit.ToString()))
                //     && (String.IsNullOrEmpty(entity.Total.ToString()) ? true : a.Total.ToString().Contains(entity.Total.ToString()))
                //     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                //     );

                ResponseEntityList<CreditCurrentDTO> responseEntityList = new ResponseEntityList<CreditCurrentDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<CreditCurrentDTO> GetById(long id)
        {
            return _mapper.Map<CreditCurrentDTO>(await _creditCurrentDAL.GetById(id));
        }

        public async Task<long> Update(CreditCurrentDTO entity)
        {
            return await _creditCurrentDAL.Update(_mapper.Map<CreditCurrent>(entity));
        }

        public async Task<ResponseEntityList<CreditCurrentDTO>> GetAllLite()
        {
            return new ResponseEntityList<CreditCurrentDTO>()
            {
                List = _mapper.Map<IEnumerable<CreditCurrentDTO>>(await _creditCurrentDAL.GetAll()).ToList(),
            };
        }
    }
}
