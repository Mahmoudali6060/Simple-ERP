using AutoMapper;
using Clients.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entities.Shared;
using Shared.Entities.Credit;
using Data.Entities.Credit;

namespace Clients.DataServiceLayer
{
    public class SalaryDSL : ISalaryDSL
    {
        ISalaryDAL _salaryDAL;
        private readonly IMapper _mapper;
        public SalaryDSL(ISalaryDAL salaryDAL, IMapper mapper)
        {
            this._salaryDAL = salaryDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(SalaryDTO entity)
        {
            try
            {
                return await _salaryDAL.Add(_mapper.Map<Salary>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _salaryDAL.Delete(id);
        }

        public async Task<ResponseEntityList<SalaryDTO>> GetAll(SalaryDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<SalaryDTO>>(await _salaryDAL.GetAll());

                //var filteredList = list.Where(a =>
                //        (String.IsNullOrEmpty(entity.OwnerName) ? true : a.OwnerName.Contains(entity.OwnerName))
                //     && (String.IsNullOrEmpty(entity.OwnerMobile) ? true : a.OwnerMobile.Contains(entity.OwnerMobile))
                //     && (String.IsNullOrEmpty(entity.Address) ? true : a.Address.Contains(entity.Address))
                //     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                //     );

                ResponseEntityList<SalaryDTO> responseEntityList = new ResponseEntityList<SalaryDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<SalaryDTO> GetById(long id)
        {
            return _mapper.Map<SalaryDTO>(await _salaryDAL.GetById(id));
        }

        public async Task<long> Update(SalaryDTO entity)
        {
            return await _salaryDAL.Update(_mapper.Map<Salary>(entity));
        }
        public async Task<ResponseEntityList<SalaryDTO>> GetAllLite()
        {
            return new ResponseEntityList<SalaryDTO>()
            {
                List = _mapper.Map<IEnumerable<SalaryDTO>>(await _salaryDAL.GetAll()).ToList(),
            };
        }
    }
}
