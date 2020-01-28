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
    public class DebitCurrentDSL : IDebitCurrentDSL
    {
        IDebitCurrentDAL _debitCurrentDAL;
        private readonly IMapper _mapper;
        public DebitCurrentDSL(IDebitCurrentDAL debitCurrentDAL, IMapper mapper)
        {
            this._debitCurrentDAL = debitCurrentDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(DebitCurrentDTO entity)
        {
            try
            {
                return await _debitCurrentDAL.Add(_mapper.Map<DebitCurrent>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _debitCurrentDAL.Delete(id);
        }

        public async Task<ResponseEntityList<DebitCurrentDTO>> GetAll(DebitCurrentDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<DebitCurrentDTO>>(await _debitCurrentDAL.GetAll());

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

                ResponseEntityList<DebitCurrentDTO> responseEntityList = new ResponseEntityList<DebitCurrentDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<DebitCurrentDTO> GetById(long id)
        {
            return _mapper.Map<DebitCurrentDTO>(await _debitCurrentDAL.GetById(id));
        }

        public async Task<long> Update(DebitCurrentDTO entity)
        {
            return await _debitCurrentDAL.Update(_mapper.Map<DebitCurrent>(entity));
        }

        public async Task<ResponseEntityList<DebitCurrentDTO>> GetAllLite()
        {
            return new ResponseEntityList<DebitCurrentDTO>()
            {
                List = _mapper.Map<IEnumerable<DebitCurrentDTO>>(await _debitCurrentDAL.GetAll()).ToList(),
            };
        }
    }
}
