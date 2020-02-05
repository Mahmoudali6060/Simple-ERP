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

        public async Task<long> Add(OutcomeDTO entity)
        {
            try
            {
                return await _outcomeDAL.Add(_mapper.Map<Outcome>(entity));
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

        public async Task<ResponseEntityList<OutcomeDTO>> GetAll(OutcomeDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<OutcomeDTO>>(await _outcomeDAL.GetAll());

                //var filteredList = list.Where(a =>
                //      //(String.IsNullOrEmpty(entity.Date.ToString()) ? true : a.Date.ToString().Contains(entity.Date.ToString()))
                //      (String.IsNullOrEmpty(entity.CarPlate) ? true : a.CarPlate.Contains(entity.CarPlate))
                //     && (String.IsNullOrEmpty(entity.Weight.ToString()) ? true : a.Weight.ToString().Contains(entity.Weight.ToString()))
                //     && (String.IsNullOrEmpty(entity.Price.ToString()) ? true : a.Price.ToString().Contains(entity.Price.ToString()))
                //     && (String.IsNullOrEmpty(entity.Debit.ToString()) ? true : a.Debit.ToString().Contains(entity.Debit.ToString()))
                //     && (String.IsNullOrEmpty(entity.Credit.ToString()) ? true : a.Credit.ToString().Contains(entity.Credit.ToString()))
                //     && (String.IsNullOrEmpty(entity.Total.ToString()) ? true : a.Total.ToString().Contains(entity.Total.ToString()))
                //     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                //     );

                ResponseEntityList<OutcomeDTO> responseEntityList = new ResponseEntityList<OutcomeDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<OutcomeDTO> GetById(long id)
        {
            return _mapper.Map<OutcomeDTO>(await _outcomeDAL.GetById(id));
        }

        public async Task<long> Update(OutcomeDTO entity)
        {
            return await _outcomeDAL.Update(_mapper.Map<Outcome>(entity));
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
