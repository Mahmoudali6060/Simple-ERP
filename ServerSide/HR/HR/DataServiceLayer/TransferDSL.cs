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
    public class TransferDSL : ITransferDSL
    {
        ITransferDAL _transferDAL;
        private readonly IMapper _mapper;
        public TransferDSL(ITransferDAL transferDAL, IMapper mapper)
        {
            this._transferDAL = transferDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(TransferDTO entity)
        {
            try
            {
                return await _transferDAL.Add(_mapper.Map<Transfer>(entity));
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

        public async Task<ResponseEntityList<TransferDTO>> GetAll(TransferDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<TransferDTO>>(await _transferDAL.GetAll());

                //var filteredList = list.Where(a =>
                //        (String.IsNullOrEmpty(entity.OwnerName) ? true : a.OwnerName.Contains(entity.OwnerName))
                //     && (String.IsNullOrEmpty(entity.OwnerMobile) ? true : a.OwnerMobile.Contains(entity.OwnerMobile))
                //     && (String.IsNullOrEmpty(entity.Address) ? true : a.Address.Contains(entity.Address))
                //     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                //     );

                ResponseEntityList<TransferDTO> responseEntityList = new ResponseEntityList<TransferDTO>();
                responseEntityList.Total = list.Count();
                responseEntityList.List = list.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<TransferDTO> GetById(long id)
        {
            return _mapper.Map<TransferDTO>(await _transferDAL.GetById(id));
        }

        public async Task<long> Update(TransferDTO entity)
        {
            return await _transferDAL.Update(_mapper.Map<Transfer>(entity));
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
