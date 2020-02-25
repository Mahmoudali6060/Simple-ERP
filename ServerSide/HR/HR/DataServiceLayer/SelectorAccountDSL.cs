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
    public class SelectorAccountDSL : ISelectorAccountDSL
    {
        ISelectorAccountDAL _selectorAccountDAL;
        private readonly IMapper _mapper;
        public SelectorAccountDSL(ISelectorAccountDAL selectorAccountDAL, IMapper mapper)
        {
            this._selectorAccountDAL = selectorAccountDAL;
            _mapper = mapper;
        }

        public async Task<long> Save(SelectorAccountDTO entity)
        {
            return await _selectorAccountDAL.Save(_mapper.Map<SelectorAccount>(entity));
        }

        public async Task<long> Delete(long id)
        {
            return await _selectorAccountDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<SelectorAccountDTO>>(await _selectorAccountDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }

        public async Task<SelectorAccountDTO> GetById(long id)
        {
            return _mapper.Map<SelectorAccountDTO>(await _selectorAccountDAL.GetById(id));
        }

        public async Task<ResponseEntityList<SelectorAccountDTO>> GetAllLite()
        {
            return new ResponseEntityList<SelectorAccountDTO>()
            {
                List = _mapper.Map<IEnumerable<SelectorAccountDTO>>(await _selectorAccountDAL.GetAll()).ToList(),
            };
        }
    }
}
