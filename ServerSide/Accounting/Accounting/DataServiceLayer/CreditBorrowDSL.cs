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
    public class CreditBorrowDSL : ICreditBorrowDSL
    {
        ICreditBorrowDAL _creditBorrowDAL;
        private readonly IMapper _mapper;
        public CreditBorrowDSL(ICreditBorrowDAL creditBorrowDAL, IMapper mapper)
        {
            this._creditBorrowDAL = creditBorrowDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(CreditBorrowDTO entity)
        {
            try
            {
                return await _creditBorrowDAL.Add(_mapper.Map<CreditBorrow>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _creditBorrowDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<IncomeDTO>>(await _creditBorrowDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }

        public async Task<CreditBorrowDTO> GetById(long id)
        {
            return _mapper.Map<CreditBorrowDTO>(await _creditBorrowDAL.GetById(id));
        }

        public async Task<long> Update(CreditBorrowDTO entity)
        {
            return await _creditBorrowDAL.Update(_mapper.Map<CreditBorrow>(entity));
        }

        public async Task<ResponseEntityList<CreditBorrowDTO>> GetAllLite()
        {
            return new ResponseEntityList<CreditBorrowDTO>()
            {
                List = _mapper.Map<IEnumerable<CreditBorrowDTO>>(await _creditBorrowDAL.GetAll()).ToList(),
            };
        }
    }
}
