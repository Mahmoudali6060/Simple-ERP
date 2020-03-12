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
using Accouting.Shared.DataServiceLayer;

namespace Clients.DataServiceLayer
{
    public class ReaperDSL : IReaperDSL
    {
        IReaperDAL _reaperDAL;
        IAccountingSharedDSL _accountingSharedDSL;

        private readonly IMapper _mapper;
        public ReaperDSL(IReaperDAL reaperDAL, IAccountingSharedDSL accountingSharedDSL, IMapper mapper)
        {
            _reaperDAL = reaperDAL;
            _accountingSharedDSL = accountingSharedDSL;
            _mapper = mapper;
        }

        public async Task<long> Save(ReaperDTO entity)
        {
            try
            {
                if (entity.Id > 0)
                {
                    await _accountingSharedDSL.UpdateAccountName(entity.Id, entity.HeadName);
                }
                return await _reaperDAL.Save(_mapper.Map<Reaper>(entity));
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

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<Reaper>>(await _reaperDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }

        public async Task<ReaperDTO> GetById(long id)
        {
            return _mapper.Map<ReaperDTO>(await _reaperDAL.GetById(id));
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
