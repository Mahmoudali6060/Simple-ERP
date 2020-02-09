using AutoMapper;
using Data.Entities;
using Accouting.DataAccessLayer;
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
using Shared.Entities.Credit;
using Data.Entities.Credit;
using Shared.Classes;

namespace Accouting.DataServiceLayer
{
    public class CreditCurrentDSL : ICreditCurrentDSL
    {
        ICreditCurrentDAL _creditCurrentDAL;
        private readonly IMapper _mapper;
        public CreditCurrentDSL(ICreditCurrentDAL creditCurrentDAL, IMapper mapper)
        {
            this._creditCurrentDAL = creditCurrentDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(CreditCurrentDTO entity)
        {
            try
            {
                return await _creditCurrentDAL.Add(_mapper.Map<CreditCurrent>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _creditCurrentDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<CreditCurrentDTO>>(await _creditCurrentDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }

        public async Task<CreditCurrentDTO> GetById(long id)
        {
            return _mapper.Map<CreditCurrentDTO>(await _creditCurrentDAL.GetById(id));
        }

        public async Task<long> Update(CreditCurrentDTO entity)
        {
            return await _creditCurrentDAL.Update(_mapper.Map<CreditCurrent>(entity));
        }

        public async Task<ResponseEntityList<CreditCurrentDTO>> GetAllLite()
        {
            return new ResponseEntityList<CreditCurrentDTO>()
            {
                List = _mapper.Map<IEnumerable<CreditCurrentDTO>>(await _creditCurrentDAL.GetAll()).ToList(),
            };
        }
    }
}
