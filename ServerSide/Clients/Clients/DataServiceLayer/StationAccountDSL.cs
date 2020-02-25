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
using Shared.Classes;
using Shared.Entities.Debit;
using Data.Entities.Debit;

namespace Supplier.DataServiceLayer
{
    public class StationAccountDSL : IStationAccountDSL
    {
        IStationAccountDAL _stationAccountDAL;
        private readonly IMapper _mapper;
        public StationAccountDSL(IStationAccountDAL stationAccountDAL, IMapper mapper)
        {
            this._stationAccountDAL = stationAccountDAL;
            _mapper = mapper;
        }

        public async Task<long> Save(StationAccountDTO entity)
        {
            return await _stationAccountDAL.Save(_mapper.Map<StationAccount>(entity));
        }

        public async Task<long> Delete(long id)
        {
            return await _stationAccountDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<StationAccountDTO>>(await _stationAccountDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }

        public async Task<StationAccountDTO> GetById(long id)
        {
            return _mapper.Map<StationAccountDTO>(await _stationAccountDAL.GetById(id));
        }

        public async Task<ResponseEntityList<StationAccountDTO>> GetAllLite()
        {
            return new ResponseEntityList<StationAccountDTO>()
            {
                List = _mapper.Map<IEnumerable<StationAccountDTO>>(await _stationAccountDAL.GetAll()).ToList(),
            };
        }
    }
}
