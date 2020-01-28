using AutoMapper;
using Clients.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Shared.Entities.Shared;
using Shared.Entities.Credit;
using Data.Entities.Credit;

namespace Clients.DataServiceLayer
{
    public class DriverDSL : IDriverDSL
    {
        IDriverDAL _driverDAL;
        private readonly IMapper _mapper;
        public DriverDSL(IDriverDAL driverDAL, IMapper mapper)
        {
            this._driverDAL = driverDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(DriverDTO entity)
        {
            try
            {
                return await _driverDAL.Add(_mapper.Map<Driver>(entity));
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

        public async Task<ResponseEntityList<DriverDTO>> GetAll(DriverDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<DriverDTO>>(await _driverDAL.GetAll());

                //var filteredList = list.Where(a =>
                //        (String.IsNullOrEmpty(entity.OwnerName) ? true : a.OwnerName.Contains(entity.OwnerName))
                //     && (String.IsNullOrEmpty(entity.OwnerMobile) ? true : a.OwnerMobile.Contains(entity.OwnerMobile))
                //     && (String.IsNullOrEmpty(entity.Address) ? true : a.Address.Contains(entity.Address))
                //     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                //     );

                ResponseEntityList<DriverDTO> responseEntityList = new ResponseEntityList<DriverDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<DriverDTO> GetById(long id)
        {
            return _mapper.Map<DriverDTO>(await _driverDAL.GetById(id));
        }

        public async Task<long> Update(DriverDTO entity)
        {
            return await _driverDAL.Update(_mapper.Map<Driver>(entity));
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
