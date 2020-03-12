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
    public class SelectorDSL : ISelectorDSL
    {
        ISelectorDAL _selectorDAL;
        IAccountingSharedDSL _accountingSharedDSL;
        private readonly IMapper _mapper;
        public SelectorDSL(ISelectorDAL selectorDAL, IAccountingSharedDSL accountingSharedDSL, IMapper mapper)
        {
            _selectorDAL = selectorDAL;
            _accountingSharedDSL = accountingSharedDSL;
            _mapper = mapper;
        }

        public async Task<long> Save(SelectorDTO entity)
        {
            try
            {
                await _accountingSharedDSL.UpdateAccountName(entity.Id, entity.HeadName);
                return await _selectorDAL.Save(_mapper.Map<Selector>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _selectorDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<Selector>>(await _selectorDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }

        public async Task<SelectorDTO> GetById(long id)
        {
            return _mapper.Map<SelectorDTO>(await _selectorDAL.GetById(id));
        }

        public async Task<ResponseEntityList<SelectorDTO>> GetAllLite()
        {
            return new ResponseEntityList<SelectorDTO>()
            {
                List = _mapper.Map<IEnumerable<SelectorDTO>>(await _selectorDAL.GetAll()).ToList(),
            };
        }
    }
}
