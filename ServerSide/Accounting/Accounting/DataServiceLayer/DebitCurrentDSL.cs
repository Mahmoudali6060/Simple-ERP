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
using Shared.Classes;

namespace Accouting.DataServiceLayer
{
    public class DebitCurrentDSL : IDebitCurrentDSL
    {
        IDebitCurrentDAL _debitCurrentDAL;
        private readonly IMapper _mapper;
        public DebitCurrentDSL(IDebitCurrentDAL debitCurrentDAL, IMapper mapper)
        {
            this._debitCurrentDAL = debitCurrentDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(DebitCurrentDTO entity)
        {
            try
            {
                return await _debitCurrentDAL.Add(_mapper.Map<DebitCurrent>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _debitCurrentDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<DebitCurrentDTO>>(await _debitCurrentDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<DebitCurrentDTO> GetById(long id)
        {
            return _mapper.Map<DebitCurrentDTO>(await _debitCurrentDAL.GetById(id));
        }

        public async Task<long> Update(DebitCurrentDTO entity)
        {
            return await _debitCurrentDAL.Update(_mapper.Map<DebitCurrent>(entity));
        }

        public async Task<ResponseEntityList<DebitCurrentDTO>> GetAllLite()
        {
            return new ResponseEntityList<DebitCurrentDTO>()
            {
                List = _mapper.Map<IEnumerable<DebitCurrentDTO>>(await _debitCurrentDAL.GetAll()).ToList(),
            };
        }
    }
}
