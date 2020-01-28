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
    public class ReaperDetailDSL : IReaperDetailDSL
    {
        IReaperDetailDAL _reaperDetailDAL;
        private readonly IMapper _mapper;
        public ReaperDetailDSL(IReaperDetailDAL reaperDetailDAL, IMapper mapper)
        {
            this._reaperDetailDAL = reaperDetailDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(ReaperDetailDTO entity)
        {
            try
            {
                return await _reaperDetailDAL.Add(_mapper.Map<ReaperDetail>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _reaperDetailDAL.Delete(id);
        }

        public async Task<ResponseEntityList<ReaperDetailDTO>> GetAll(ReaperDetailDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<ReaperDetailDTO>>(await _reaperDetailDAL.GetAll());

                //var filteredList = list.Where(a =>
                //        (String.IsNullOrEmpty(entity.OwnerName) ? true : a.OwnerName.Contains(entity.OwnerName))
                //     && (String.IsNullOrEmpty(entity.OwnerMobile) ? true : a.OwnerMobile.Contains(entity.OwnerMobile))
                //     && (String.IsNullOrEmpty(entity.Address) ? true : a.Address.Contains(entity.Address))
                //     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                //     );

                ResponseEntityList<ReaperDetailDTO> responseEntityList = new ResponseEntityList<ReaperDetailDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<ReaperDetailDTO> GetById(long id)
        {
            return _mapper.Map<ReaperDetailDTO>(await _reaperDetailDAL.GetById(id));
        }

        public async Task<long> Update(ReaperDetailDTO entity)
        {
            return await _reaperDetailDAL.Update(_mapper.Map<ReaperDetail>(entity));
        }
        public async Task<ResponseEntityList<ReaperDetailDTO>> GetAllLite()
        {
            return new ResponseEntityList<ReaperDetailDTO>()
            {
                List = _mapper.Map<IEnumerable<ReaperDetailDTO>>(await _reaperDetailDAL.GetAll()).ToList(),
            };
        }
    }
}
