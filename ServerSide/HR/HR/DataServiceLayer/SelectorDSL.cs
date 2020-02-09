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
    public class SelectorDSL : ISelectorDSL
    {
        ISelectorDAL _selectorDAL;
        private readonly IMapper _mapper;
        public SelectorDSL(ISelectorDAL selectorDAL, IMapper mapper)
        {
            this._selectorDAL = selectorDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(SelectorDTO entity)
        {
            try
            {
                return await _selectorDAL.Add(_mapper.Map<Selector>(entity));
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
            var list = _mapper.Map<IEnumerable<SelectorDTO>>(await _selectorDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<SelectorDTO> GetById(long id)
        {
            return _mapper.Map<SelectorDTO>(await _selectorDAL.GetById(id));
        }

        public async Task<long> Update(SelectorDTO entity)
        {
            return await _selectorDAL.Update(_mapper.Map<Selector>(entity));
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
