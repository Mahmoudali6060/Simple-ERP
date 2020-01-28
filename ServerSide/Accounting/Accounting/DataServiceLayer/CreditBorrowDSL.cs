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

        public async Task<ResponseEntityList<CreditBorrowDTO>> GetAll(CreditBorrowDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<CreditBorrowDTO>>(await _creditBorrowDAL.GetAll());

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

                ResponseEntityList<CreditBorrowDTO> responseEntityList = new ResponseEntityList<CreditBorrowDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


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
