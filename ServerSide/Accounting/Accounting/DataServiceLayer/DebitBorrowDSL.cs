using AutoMapper;
using Accouting.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entities.Debit;
using Data.Entities.Debit;
using Shared.Entities.Shared;
using Shared.Classes;

namespace Accouting.DataServiceLayer
{
    public class DebitBorrowDSL : IDebitBorrowDSL
    {
        IDebitBorrowDAL _debitBorrowDAL;
        private readonly IMapper _mapper;
        public DebitBorrowDSL(IDebitBorrowDAL debitBorrowDAL, IMapper mapper)
        {
            this._debitBorrowDAL = debitBorrowDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(DebitBorrowDTO entity)
        {
            try
            {
                return await _debitBorrowDAL.Add(_mapper.Map<DebitBorrow>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _debitBorrowDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<DebitBorrowDTO>>(await _debitBorrowDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<DebitBorrowDTO> GetById(long id)
        {
            return _mapper.Map<DebitBorrowDTO>(await _debitBorrowDAL.GetById(id));
        }

        public async Task<long> Update(DebitBorrowDTO entity)
        {
            return await _debitBorrowDAL.Update(_mapper.Map<DebitBorrow>(entity));
        }

        public async Task<ResponseEntityList<DebitBorrowDTO>> GetAllLite()
        {
            return new ResponseEntityList<DebitBorrowDTO>()
            {
                List = _mapper.Map<IEnumerable<DebitBorrowDTO>>(await _debitBorrowDAL.GetAll()).ToList(),
            };
        }
    }
}
