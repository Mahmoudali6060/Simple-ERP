using AutoMapper;
using Supplier.DataAccessLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities.Credit;
using Shared.Entities.Credit;
using Shared.Entities.Shared;

namespace Supplier.DataServiceLayer
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
            return await _incomeDAL.Add(_mapper.Map<Income>(entity));
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

                //var filteredList = list.Where(a =>
                //      //(String.IsNullOrEmpty(entity.Date.ToString()) ? true : a.Date.ToString().Contains(entity.Date.ToString()))
                //      (String.IsNullOrEmpty(entity.CarPlate) ? true : a.CarPlate.Contains(entity.CarPlate))
                //     && (String.IsNullOrEmpty(entity.Weight.ToString()) ? true : a.Weight.ToString().Contains(entity.Weight.ToString()))
                //     && (String.IsNullOrEmpty(entity.Pardon.ToString()) ? true : a.Pardon.ToString().Contains(entity.Pardon.ToString()))
                //     && (String.IsNullOrEmpty(entity.WeightAfterPardon.ToString()) ? true : a.WeightAfterPardon.ToString().Contains(entity.WeightAfterPardon.ToString()))
                //     && (String.IsNullOrEmpty(entity.Price.ToString()) ? true : a.Price.ToString().Contains(entity.Price.ToString()))
                //     && (String.IsNullOrEmpty(entity.Debit.ToString()) ? true : a.Debit.ToString().Contains(entity.Debit.ToString()))
                //     && (String.IsNullOrEmpty(entity.Credit.ToString()) ? true : a.Credit.ToString().Contains(entity.Credit.ToString()))
                //     && (String.IsNullOrEmpty(entity.Total.ToString()) ? true : a.Total.ToString().Contains(entity.Total.ToString()))
                //     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                //     );

                ResponseEntityList<IncomeDTO> responseEntityList = new ResponseEntityList<IncomeDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.Take(take).Skip(skip).ToList();

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

        public async Task<ResponseEntityList<IncomeDTO>> GetIncomesByFarmId(long farmId)
        {
            return new ResponseEntityList<IncomeDTO>()
            {
                List = _mapper.Map<IEnumerable<IncomeDTO>>(await _incomeDAL.GetIncomesByFarmId(farmId)).ToList(),
            };
        }

    }
}
