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
using Shared.Classes;

namespace Supplier.DataServiceLayer
{
    public class FarmDSL : IFarmDSL
    {
        IFarmDAL _farmDAL;
        private readonly IMapper _mapper;
        public FarmDSL(IFarmDAL farmDAL, IMapper mapper)
        {
            this._farmDAL = farmDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(FarmDTO entity)
        {
            return await _farmDAL.Add(_mapper.Map<Farm>(entity));
        }

        public async Task<long> Delete(long id)
        {
            return await _farmDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<FarmDTO>>(await _farmDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }

        public async Task<FarmDTO> GetById(long id)
        {
            return _mapper.Map<FarmDTO>(await _farmDAL.GetById(id));
        }

        public async Task<long> Update(FarmDTO entity)
        {
            return await _farmDAL.Update(_mapper.Map<Farm>(entity));
        }

        public async Task<ResponseEntityList<FarmDTO>> GetAllLite()
        {
            return new ResponseEntityList<FarmDTO>()
            {
                List = _mapper.Map<IEnumerable<FarmDTO>>(await _farmDAL.GetAll()).ToList(),
            };
        }
    }
}
