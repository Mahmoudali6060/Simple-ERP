using AutoMapper;
using Data.Entities;
using Clients.DataAccessLayer;
using Clients.RepositoryLayer;
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
using Shared.Classes;

namespace Clients.DataServiceLayer
{
    public class StationDSL : IStationDSL
    {
        IStationDAL _stationDAL;
        private readonly IMapper _mapper;
        public StationDSL(IStationDAL stationDAL, IMapper mapper)
        {
            this._stationDAL = stationDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(StationDTO entity)
        {
            try
            {
                return await _stationDAL.Add(_mapper.Map<Station>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _stationDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<StationDTO>>(await _stationDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<StationDTO> GetById(long id)
        {
            return _mapper.Map<StationDTO>(await _stationDAL.GetById(id));
        }

        public async Task<long> Update(StationDTO entity)
        {
            return await _stationDAL.Update(_mapper.Map<Station>(entity));
        }
        public async Task<ResponseEntityList<StationDTO>> GetAllLite()
        {
            return new ResponseEntityList<StationDTO>()
            {
                List = _mapper.Map<IEnumerable<StationDTO>>(await _stationDAL.GetAll()).ToList(),
            };
        }
    }
}
