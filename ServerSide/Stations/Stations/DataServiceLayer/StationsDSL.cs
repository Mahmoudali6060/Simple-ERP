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

        public async Task<ResponseEntityList<StationDTO>> GetAll(StationDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<StationDTO>>(await _stationDAL.GetAll());

                var filteredList = list.Where(a =>
                        (String.IsNullOrEmpty(entity.Name) ? true : a.Name.Contains(entity.Name))
                     && (String.IsNullOrEmpty(entity.OwnerMobile) ? true : a.OwnerMobile.Contains(entity.OwnerMobile))
                     && (String.IsNullOrEmpty(entity.Address) ? true : a.Address.Contains(entity.Address))
                     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                     );

                ResponseEntityList<StationDTO> responseEntityList = new ResponseEntityList<StationDTO>();
                responseEntityList.Total = filteredList.Count();
                responseEntityList.List = filteredList.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


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
