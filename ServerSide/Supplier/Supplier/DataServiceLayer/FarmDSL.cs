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
using Data.Entities.Debit;
using Accouting.Shared.DataServiceLayer;

namespace Supplier.DataServiceLayer
{
    public class FarmDSL : IFarmDSL
    {
        IFarmDAL _farmDAL;
        IAccountingSharedDSL _accountingSharedDSL;
        private readonly IMapper _mapper;

        public FarmDSL(IFarmDAL farmDAL, IAccountingSharedDSL accountingSharedDSL, IMapper mapper)
        {
            this._farmDAL = farmDAL;
            _accountingSharedDSL = accountingSharedDSL;
            _mapper = mapper;
        }

        public async Task<long> Save(FarmDTO entity)
        {
            if (entity.Id > 0)
            {
                await _accountingSharedDSL.UpdateAccountName(entity.Id, entity.OwnerName);
            }
            return await _farmDAL.Save(_mapper.Map<Farm>(entity));
        }

        public async Task<long> Delete(long id)
        {
            return await _farmDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<FarmDTO>>(await _farmDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }

        public async Task<FarmDTO> GetById(long id)
        {
            return _mapper.Map<FarmDTO>(await _farmDAL.GetById(id));
        }

        public async Task<ResponseEntityList<FarmDTO>> GetAllLite()
        {
            return new ResponseEntityList<FarmDTO>()
            {
                List = _mapper.Map<IEnumerable<FarmDTO>>(await _farmDAL.GetAll()).ToList(),
            };
        }
    }
}
