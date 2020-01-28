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
    public class ReaperDSL : IReaperDSL
    {
        IReaperDAL _reaperDAL;
        private readonly IMapper _mapper;
        public ReaperDSL(IReaperDAL reaperDAL, IMapper mapper)
        {
            this._reaperDAL = reaperDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(ReaperDTO entity)
        {
            try
            {
                return await _reaperDAL.Add(_mapper.Map<Reaper>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _reaperDAL.Delete(id);
        }

        public async Task<ResponseEntityList<ReaperDTO>> GetAll(ReaperDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<ReaperDTO>>(await _reaperDAL.GetAll());

                //var filteredList = list.Where(a =>
                //        (String.IsNullOrEmpty(entity.OwnerName) ? true : a.OwnerName.Contains(entity.OwnerName))
                //     && (String.IsNullOrEmpty(entity.OwnerMobile) ? true : a.OwnerMobile.Contains(entity.OwnerMobile))
                //     && (String.IsNullOrEmpty(entity.Address) ? true : a.Address.Contains(entity.Address))
                //     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                //     );

                ResponseEntityList<ReaperDTO> responseEntityList = new ResponseEntityList<ReaperDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<ReaperDTO> GetById(long id)
        {
            return _mapper.Map<ReaperDTO>(await _reaperDAL.GetById(id));
        }

        public async Task<long> Update(ReaperDTO entity)
        {
            return await _reaperDAL.Update(_mapper.Map<Reaper>(entity));
        }
        public async Task<ResponseEntityList<ReaperDTO>> GetAllLite()
        {
            return new ResponseEntityList<ReaperDTO>()
            {
                List = _mapper.Map<IEnumerable<ReaperDTO>>(await _reaperDAL.GetAll()).ToList(),
            };
        }
    }
}
