using AutoMapper;
using Data.Entities;
using Supplier.DataAccessLayer;
using Supplier.RepositoryLayer;
using Microsoft.AspNetCore.Identity;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Credit;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using Data.Entities.Shared;
using Accouting.DataAccessLayer;

namespace Accouting.DataServiceLayer
{
    public class TransactionDSL : ITransactionDSL
    {
        ITransactionDAL _transactionDAL;
        private readonly IMapper _mapper;
        public TransactionDSL(ITransactionDAL transactionDAL, IMapper mapper)
        {
            this._transactionDAL = transactionDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(TransactionDTO entity)
        {
            return await _transactionDAL.Add(_mapper.Map<Transaction>(entity));
        }

        public async Task<long> Delete(long id)
        {
            return await _transactionDAL.Delete(id);
        }

        public async Task<ResponseEntityList<TransactionDTO>> GetAll(TransactionDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<TransactionDTO>>(await _transactionDAL.GetAll());

                //var filteredList = list.Where(a =>
                //        (String.IsNullOrEmpty(entity.OwnerName) ? true : a.OwnerName.Contains(entity.OwnerName))
                //     && (String.IsNullOrEmpty(entity.OwnerMobile) ? true : a.OwnerMobile.Contains(entity.OwnerMobile))
                //     && (String.IsNullOrEmpty(entity.Address) ? true : a.Address.Contains(entity.Address))
                //     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                //     );

                ResponseEntityList<TransactionDTO> responseEntityList = new ResponseEntityList<TransactionDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<TransactionDTO> GetById(long id)
        {
            return _mapper.Map<TransactionDTO>(await _transactionDAL.GetById(id));
        }

        public async Task<long> Update(TransactionDTO entity)
        {
            return await _transactionDAL.Update(_mapper.Map<Transaction>(entity));
        }

        public async Task<ResponseEntityList<TransactionDTO>> GetAllLite()
        {
            return new ResponseEntityList<TransactionDTO>()
            {
                List = _mapper.Map<IEnumerable<TransactionDTO>>(await _transactionDAL.GetAll()).ToList(),
            };
        }
    }
}
