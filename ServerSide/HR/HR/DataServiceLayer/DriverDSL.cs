﻿using AutoMapper;
using Clients.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Shared.Entities.Shared;
using Shared.Entities.Credit;
using Data.Entities.Credit;
using Shared.Classes;
using Accouting.Shared.DataServiceLayer;

namespace Clients.DataServiceLayer
{
    public class DriverDSL : IDriverDSL
    {
        IDriverDAL _driverDAL;
        IAccountingSharedDSL _accountingSharedDSL;

        private readonly IMapper _mapper;
        public DriverDSL(IDriverDAL driverDAL, IAccountingSharedDSL accountingSharedDSL, IMapper mapper)
        {
            _accountingSharedDSL = accountingSharedDSL;
            this._driverDAL = driverDAL;
            _mapper = mapper;
        }

        public async Task<long> Save(DriverDTO entity)
        {
            try
            {
                if (entity.Id > 0)
                {
                    await _accountingSharedDSL.UpdateAccountName(entity.Id, entity.FullName);
                }
                return await _driverDAL.Save(_mapper.Map<Driver>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _driverDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<DriverDTO>>(await _driverDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<DriverDTO> GetById(long id)
        {
            return _mapper.Map<DriverDTO>(await _driverDAL.GetById(id));
        }

        public async Task<ResponseEntityList<DriverDTO>> GetAllLite()
        {
            return new ResponseEntityList<DriverDTO>()
            {
                List = _mapper.Map<IEnumerable<DriverDTO>>(await _driverDAL.GetAll()).ToList(),
            };
        }
    }
}
