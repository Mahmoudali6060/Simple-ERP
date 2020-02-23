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
using Shared.Enums;

namespace Accouting.DataServiceLayer
{
    public class SafeDSL : ISafeDSL
    {
        ISafeDAL _safeDAL;
        private readonly IMapper _mapper;
        public SafeDSL(ISafeDAL safeDAL, IMapper mapper)
        {
            this._safeDAL = safeDAL;
            _mapper = mapper;
        }

        public async Task<long> Save(SafeDTO entity)
        {
            try
            {
                return await _safeDAL.Save(_mapper.Map<Safe>(entity));
                //if(entity.AccountTreeId==AccountTreeEnum.In)
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _safeDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<SafeDTO>>(await _safeDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<SafeDTO> GetById(long id)
        {
            return _mapper.Map<SafeDTO>(await _safeDAL.GetById(id));
        }

        public async Task<ResponseEntityList<SafeDTO>> GetAllLite()
        {
            return new ResponseEntityList<SafeDTO>()
            {
                List = _mapper.Map<IEnumerable<SafeDTO>>(await _safeDAL.GetAll()).ToList(),
            };
        }
    }
}
