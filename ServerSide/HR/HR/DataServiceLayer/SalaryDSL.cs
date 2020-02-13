using AutoMapper;
using Clients.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entities.Shared;
using Shared.Entities.Credit;
using Data.Entities.Credit;
using Shared.Classes;

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

        public async Task<long> Save(SalaryDTO entity)
        {
            try
            {
                return await _salaryDAL.Save(_mapper.Map<Salary>(entity));
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

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<SalaryDTO>>(await _salaryDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<SalaryDTO> GetById(long id)
        {
            return _mapper.Map<SalaryDTO>(await _salaryDAL.GetById(id));
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
