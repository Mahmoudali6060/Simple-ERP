using AutoMapper;
using Clients.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Shared.Entities.Shared;
using Shared.Entities.Credit;
using Data.Entities.Credit;
using Shared.Classes;

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

        public async Task<long> Save(ReaperDetailDTO entity)
        {
            try
            {
                return await _reaperDetailDAL.Save(_mapper.Map<ReaperDetail>(entity));
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
        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<ReaperDetail>>(await _reaperDetailDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<ReaperDetailDTO> GetById(long id)
        {
            return _mapper.Map<ReaperDetailDTO>(await _reaperDetailDAL.GetById(id));
        }

        public async Task<ResponseEntityList<ReaperDetailDTO>> GetAllLite()
        {
            return new ResponseEntityList<ReaperDetailDTO>()
            {
                List = _mapper.Map<IEnumerable<ReaperDetailDTO>>(await _reaperDetailDAL.GetAll()).ToList(),
            };
        }

        public async Task<Response> GetAllByReaperId(long reaperId, DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<ReaperDetailDTO>>(await _reaperDetailDAL.GetAllByReaperId(reaperId)).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
    }
}
