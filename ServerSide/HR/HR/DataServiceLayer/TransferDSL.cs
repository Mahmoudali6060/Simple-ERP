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
    public class TransferDSL : ITransferDSL
    {
        ITransferDAL _transferDAL;
        private readonly IMapper _mapper;
        public TransferDSL(ITransferDAL transferDAL, IMapper mapper)
        {
            this._transferDAL = transferDAL;
            _mapper = mapper;
        }

        public async Task<long> Save(TransferDTO entity)
        {
            try
            {
                return await _transferDAL.Save(_mapper.Map<Transfer>(entity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<long> Delete(long id)
        {
            return await _transferDAL.Delete(id);
        }

        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<TransferDTO>>(await _transferDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<TransferDTO> GetById(long id)
        {
            return _mapper.Map<TransferDTO>(await _transferDAL.GetById(id));
        }

        public async Task<ResponseEntityList<TransferDTO>> GetAllLite()
        {
            return new ResponseEntityList<TransferDTO>()
            {
                List = _mapper.Map<IEnumerable<TransferDTO>>(await _transferDAL.GetAll()).ToList(),
            };
        }
    }
}
