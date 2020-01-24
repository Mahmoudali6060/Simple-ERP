using AutoMapper;
using Data.Entities;
using Stations.DataAccessLayer;
using Stations.Models;
using Stations.RepositoryLayer;
using Microsoft.AspNetCore.Identity;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stations.DataServiceLayer
{
    public class IncomeDSL : IIncomeDSL
    {
        IIncomeDAL _incomeDAL;
        private readonly IMapper _mapper;
        public IncomeDSL(IIncomeDAL incomeDAL, IMapper mapper)
        {
            this._incomeDAL = incomeDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(IncomeDTO entity)
        {
            try
            {
                return await _incomeDAL.Add(_mapper.Map<Income>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _incomeDAL.Delete(id);
        }

        public async Task<ResponseEntityList<IncomeDTO>> GetAll(IncomeDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<IncomeDTO>>(await _incomeDAL.GetAll());

                var filteredList = list.Where(a =>
                      //(String.IsNullOrEmpty(entity.Date.ToString()) ? true : a.Date.ToString().Contains(entity.Date.ToString()))
                      (String.IsNullOrEmpty(entity.CarPlate) ? true : a.CarPlate.Contains(entity.CarPlate))
                     && (String.IsNullOrEmpty(entity.Weight.ToString()) ? true : a.Weight.ToString().Contains(entity.Weight.ToString()))
                     && (String.IsNullOrEmpty(entity.Price.ToString()) ? true : a.Price.ToString().Contains(entity.Price.ToString()))
                     && (String.IsNullOrEmpty(entity.Debit.ToString()) ? true : a.Debit.ToString().Contains(entity.Debit.ToString()))
                     && (String.IsNullOrEmpty(entity.Credit.ToString()) ? true : a.Credit.ToString().Contains(entity.Credit.ToString()))
                     && (String.IsNullOrEmpty(entity.Total.ToString()) ? true : a.Total.ToString().Contains(entity.Total.ToString()))
                     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                     );

                ResponseEntityList<IncomeDTO> responseEntityList = new ResponseEntityList<IncomeDTO>();
                responseEntityList.Total = filteredList.Count();
                responseEntityList.List = filteredList.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<IncomeDTO> GetById(long id)
        {
            return _mapper.Map<IncomeDTO>(await _incomeDAL.GetById(id));
        }

        public async Task<long> Update(IncomeDTO entity)
        {
            return await _incomeDAL.Update(_mapper.Map<Income>(entity));
        }

        public async Task<ResponseEntityList<IncomeDTO>> GetAllLite()
        {
            return new ResponseEntityList<IncomeDTO>()
            {
                List = _mapper.Map<IEnumerable<IncomeDTO>>(await _incomeDAL.GetAll()).ToList(),
            };
        }

        public async Task<ResponseEntityList<IncomeDTO>> GetIncomesByStationId(long stationId)
        {
            return new ResponseEntityList<IncomeDTO>()
            {
                List = _mapper.Map<IEnumerable<IncomeDTO>>(await _incomeDAL.GetIncomesByStationId(stationId)).ToList(),
            };
        }

    }
}
