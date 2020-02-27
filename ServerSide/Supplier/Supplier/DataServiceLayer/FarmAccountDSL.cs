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

namespace Supplier.DataServiceLayer
{
    public class FarmAccountDSL : IFarmAccountDSL
    {
        IFarmAccountDAL _farmAccountDAL;
        private readonly IMapper _mapper;
        public FarmAccountDSL(IFarmAccountDAL farmAccountDAL, IMapper mapper)
        {
            this._farmAccountDAL = farmAccountDAL;
            _mapper = mapper;
        }

        public async Task<long> Save(FarmAccountDTO entity)
        {
            return await _farmAccountDAL.Save(_mapper.Map<FarmAccount>(entity));
        }

        public async Task<long> Delete(long id)
        {
            return await _farmAccountDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<FarmAccountDTO>>(await _farmAccountDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }

        public async Task<FarmAccountDTO> GetById(long id)
        {
            return _mapper.Map<FarmAccountDTO>(await _farmAccountDAL.GetById(id));
        }

        public async Task<ResponseEntityList<FarmAccountDTO>> GetAllLite()
        {
            return new ResponseEntityList<FarmAccountDTO>()
            {
                List = _mapper.Map<IEnumerable<FarmAccountDTO>>(await _farmAccountDAL.GetAll()).ToList(),
            };
        }

        public async Task<Response> GetAllByFarmId(long farmId, DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<FarmAccountDTO>>(await _farmAccountDAL.GetAllByFarmId(farmId)).AsQueryable();
            Response response = Helper.ToResult(list, dataSource);
            response.Entity = new FarmAccountListDTO()
            {
                PaidUpTotal = list.Sum(x => x.PaidUp)
            };
            return response;
        }
    }
}
