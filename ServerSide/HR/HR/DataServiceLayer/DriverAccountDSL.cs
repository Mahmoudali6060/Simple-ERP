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
    public class DriverAccountDSL : IDriverAccountDSL
    {
        IDriverAccountDAL _driverAccountDAL;
        private readonly IMapper _mapper;
        public DriverAccountDSL(IDriverAccountDAL driverAccountDAL, IMapper mapper)
        {
            this._driverAccountDAL = driverAccountDAL;
            _mapper = mapper;
        }

        public async Task<long> Save(DriverAccountDTO entity)
        {
            return await _driverAccountDAL.Save(_mapper.Map<DriverAccount>(entity));
        }

        public async Task<long> Delete(long id)
        {
            return await _driverAccountDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<DriverAccountDTO>>(await _driverAccountDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }

        public async Task<DriverAccountDTO> GetById(long id)
        {
            return _mapper.Map<DriverAccountDTO>(await _driverAccountDAL.GetById(id));
        }

        public async Task<ResponseEntityList<DriverAccountDTO>> GetAllLite()
        {
            return new ResponseEntityList<DriverAccountDTO>()
            {
                List = _mapper.Map<IEnumerable<DriverAccountDTO>>(await _driverAccountDAL.GetAll()).ToList(),
            };
        }

        public async Task<Response> GetAllByDriverId(long driverId, DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<DriverAccountDTO>>(await _driverAccountDAL.GetAllByDriverId(driverId)).AsQueryable();
            Response response = Helper.ToResult(list, dataSource);
            response.Entity = new DriverAccountListDTO()
            {
                PaidUpTotal = list.Sum(x => x.PaidUp)
            };
            return response;
        }
    }
}
