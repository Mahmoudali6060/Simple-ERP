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
using Data.Entities.Shared;

namespace Accouting.DataServiceLayer
{
    public class AccountTreeDSL : IAccountTreeDSL
    {
        IAccountTreeDAL _accountTreeDAL;
        private readonly IMapper _mapper;
        public AccountTreeDSL(IAccountTreeDAL accountTreeDAL, IMapper mapper)
        {
            this._accountTreeDAL = accountTreeDAL;
            _mapper = mapper;
        }

        public async Task<long> Save(AccountTree entity)
        {
            try
            {
                return await _accountTreeDAL.Save(_mapper.Map<AccountTree>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _accountTreeDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<AccountTree>>(await _accountTreeDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<AccountTree> GetById(long id)
        {
            return _mapper.Map<AccountTree>(await _accountTreeDAL.GetById(id));
        }

        public async Task<ResponseEntityList<AccountTree>> GetAllLite()
        {
            return new ResponseEntityList<AccountTree>()
            {
                List = _mapper.Map<IEnumerable<AccountTree>>(await _accountTreeDAL.GetAll()).ToList(),
            };
        }
    }
}
