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
    public class ReaperAccountDSL : IReaperAccountDSL
    {
        IReaperAccountDAL _reaperAccountDAL;
        private readonly IMapper _mapper;
        public ReaperAccountDSL(IReaperAccountDAL reaperAccountDAL, IMapper mapper)
        {
            this._reaperAccountDAL = reaperAccountDAL;
            _mapper = mapper;
        }

        public async Task<long> Save(ReaperAccountDTO entity)
        {
            return await _reaperAccountDAL.Save(_mapper.Map<ReaperAccount>(entity));
        }

        public async Task<long> Delete(long id)
        {
            return await _reaperAccountDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<ReaperAccountDTO>>(await _reaperAccountDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }

        public async Task<ReaperAccountDTO> GetById(long id)
        {
            return _mapper.Map<ReaperAccountDTO>(await _reaperAccountDAL.GetById(id));
        }

        public async Task<ResponseEntityList<ReaperAccountDTO>> GetAllLite()
        {
            return new ResponseEntityList<ReaperAccountDTO>()
            {
                List = _mapper.Map<IEnumerable<ReaperAccountDTO>>(await _reaperAccountDAL.GetAll()).ToList(),
            };
        }
        public async Task<Response> GetAllByReaperId(long reaperId, DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<ReaperAccountDTO>>(await _reaperAccountDAL.GetAllByReaperId(reaperId)).AsQueryable();
            Response response = Helper.ToResult(list, dataSource);
            response.Entity = new ReaperAccountListDTO()
            {
                PaidUpTotal = list.Sum(x => x.PaidUp)
            };
            return response;
        }
    }
}
