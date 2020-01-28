using AutoMapper;
using Accouting.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entities.Debit;
using Data.Entities.Debit;
using Shared.Entities.Shared;

namespace Accouting.DataServiceLayer
{
    public class DebitBorrowDSL : IDebitBorrowDSL
    {
        IDebitBorrowDAL _creditBorrowDAL;
        private readonly IMapper _mapper;
        public DebitBorrowDSL(IDebitBorrowDAL creditBorrowDAL, IMapper mapper)
        {
            this._creditBorrowDAL = creditBorrowDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(DebitBorrowDTO entity)
        {
            try
            {
                return await _creditBorrowDAL.Add(_mapper.Map<DebitBorrow>(entity));
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

        public async Task<ResponseEntityList<DebitBorrowDTO>> GetAll(DebitBorrowDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<DebitBorrowDTO>>(await _creditBorrowDAL.GetAll());

                //var filteredList = list.Where(a =>
                //      //(String.IsNullOrEmpty(entity.Date.ToString()) ? true : a.Date.ToString().Contains(entity.Date.ToString()))
                //      (String.IsNullOrEmpty(entity.CarPlate) ? true : a.CarPlate.Contains(entity.CarPlate))
                //     && (String.IsNullOrEmpty(entity.Weight.ToString()) ? true : a.Weight.ToString().Contains(entity.Weight.ToString()))
                //     && (String.IsNullOrEmpty(entity.Price.ToString()) ? true : a.Price.ToString().Contains(entity.Price.ToString()))
                //     && (String.IsNullOrEmpty(entity.Debit.ToString()) ? true : a.Debit.ToString().Contains(entity.Debit.ToString()))
                //     && (String.IsNullOrEmpty(entity.Debit.ToString()) ? true : a.Debit.ToString().Contains(entity.Debit.ToString()))
                //     && (String.IsNullOrEmpty(entity.Total.ToString()) ? true : a.Total.ToString().Contains(entity.Total.ToString()))
                //     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                //     );

                ResponseEntityList<DebitBorrowDTO> responseEntityList = new ResponseEntityList<DebitBorrowDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<DebitBorrowDTO> GetById(long id)
        {
            return _mapper.Map<DebitBorrowDTO>(await _creditBorrowDAL.GetById(id));
        }

        public async Task<long> Update(DebitBorrowDTO entity)
        {
            return await _creditBorrowDAL.Update(_mapper.Map<DebitBorrow>(entity));
        }

        public async Task<ResponseEntityList<DebitBorrowDTO>> GetAllLite()
        {
            return new ResponseEntityList<DebitBorrowDTO>()
            {
                List = _mapper.Map<IEnumerable<DebitBorrowDTO>>(await _creditBorrowDAL.GetAll()).ToList(),
            };
        }
    }
}
