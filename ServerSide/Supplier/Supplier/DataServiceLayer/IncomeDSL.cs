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
using Shared.Classes;

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

        public async Task<long> Save(IncomeDTO entity)
        {
            return await _incomeDAL.Save(_mapper.Map<Income>(entity));
        }

        public async Task<long> Delete(long id)
        {
            return await _incomeDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = (await _incomeDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }

        public async Task<IncomeDTO> GetById(long id)
        {
            return _mapper.Map<IncomeDTO>(await _incomeDAL.GetById(id));
        }


        public async Task<ResponseEntityList<IncomeDTO>> GetAllLite()
        {
            return new ResponseEntityList<IncomeDTO>()
            {
                List = _mapper.Map<IEnumerable<IncomeDTO>>(await _incomeDAL.GetAll()).ToList(),
            };
        }

        public async Task<Response> GetIncomesByFarmId(long farmId, DataSource dataSource)
        {
            var list = (await _incomeDAL.GetIncomesByFarmId(farmId)).AsQueryable();
            Response response = Helper.ToResult(list, dataSource);
            response.Entity = new IncomeListDTO()
            {
                BalanceTotal = list.Sum(x => x.Balance)
            };
            return response;
        }

    }
}
