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
    public class SelectorDetailDSL : ISelectorDetailDSL
    {
        ISelectorDetailDAL _selectorDetailDAL;
        private readonly IMapper _mapper;
        public SelectorDetailDSL(ISelectorDetailDAL selectorDAL, IMapper mapper)
        {
            this._selectorDetailDAL = selectorDAL;
            _mapper = mapper;
        }

        public async Task<long> Save(SelectorDetailDTO entity)
        {
            try
            {
                return await _selectorDetailDAL.Save(_mapper.Map<SelectorDetail>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _selectorDetailDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<SelectorDetailDTO>>(await _selectorDetailDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<SelectorDetailDTO> GetById(long id)
        {
            return _mapper.Map<SelectorDetailDTO>(await _selectorDetailDAL.GetById(id));
        }

        public async Task<ResponseEntityList<SelectorDetailDTO>> GetAllLite()
        {
            return new ResponseEntityList<SelectorDetailDTO>()
            {
                List = _mapper.Map<IEnumerable<SelectorDetailDTO>>(await _selectorDetailDAL.GetAll()).ToList(),
            };
        }

        public async Task<Response> GetAllBySelectorId(long selectorId, DataSource dataSource)
        {
            var list = (await _selectorDetailDAL.GetAllBySelectorId(selectorId)).AsQueryable();
            Response response = Helper.ToResult(list, dataSource);
            response.Entity = new SelectorDetailListDTO()
            {
                BalanceTotal = list.Sum(x => x.Balance)
            };
            return response;
        }
    }
}
