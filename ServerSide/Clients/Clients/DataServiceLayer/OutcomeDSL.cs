using AutoMapper;
using Data.Entities;
using Clients.DataAccessLayer;
using Clients.RepositoryLayer;
using Microsoft.AspNetCore.Identity;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities.Debit;
using Data.Entities.Debit;
using Shared.Entities.Shared;
using Shared.Classes;

namespace Clients.DataServiceLayer
{
    public class OutcomeDSL : IOutcomeDSL
    {
        IOutcomeDAL _outcomeDAL;
        private readonly IMapper _mapper;
        public OutcomeDSL(IOutcomeDAL outcomeDAL, IMapper mapper)
        {
            this._outcomeDAL = outcomeDAL;
            _mapper = mapper;
        }

        public async Task<long> Save(OutcomeDTO entity)
        {
            try
            {
                return await _outcomeDAL.Save(_mapper.Map<Outcome>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _outcomeDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<OutcomeDTO>>(await _outcomeDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<OutcomeDTO> GetById(long id)
        {
            return _mapper.Map<OutcomeDTO>(await _outcomeDAL.GetById(id));
        }

        public async Task<ResponseEntityList<OutcomeDTO>> GetAllLite()
        {
            return new ResponseEntityList<OutcomeDTO>()
            {
                List = _mapper.Map<IEnumerable<OutcomeDTO>>(await _outcomeDAL.GetAll()).ToList(),
            };
        }

        public async Task<ResponseEntityList<OutcomeDTO>> GetOutcomesByStationId(long stationId)
        {
            return new ResponseEntityList<OutcomeDTO>()
            {
                List = _mapper.Map<IEnumerable<OutcomeDTO>>(await _outcomeDAL.GetOutcomesByStationId(stationId)).ToList(),
            };
        }

    }
}
