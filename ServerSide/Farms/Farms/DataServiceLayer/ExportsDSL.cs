using AutoMapper;
using Data.Entities;
using Farms.DataAccessLayer;
using Farms.Models;
using Farms.RepositoryLayer;
using Microsoft.AspNetCore.Identity;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farms.DataServiceLayer
{
    public class ExportDSL : IExportDSL
    {
        IExportDAL _exportDAL;
        private readonly IMapper _mapper;
        public ExportDSL(IExportDAL exportDAL, IMapper mapper)
        {
            this._exportDAL = exportDAL;
            _mapper = mapper;
        }

        public async Task<long> Add(ExportDTO entity)
        {
            return await _exportDAL.Add(_mapper.Map<Export>(entity));
        }

        public async Task<long> Delete(long id)
        {
            return await _exportDAL.Delete(id);
        }

        public async Task<ResponseEntityList<ExportDTO>> GetAll(ExportDTO entity)
        {
            try
            {
                int take = entity.Page * entity.RecordPerPage;
                int skip = (entity.Page - 1) * entity.RecordPerPage;

                var list = _mapper.Map<IEnumerable<ExportDTO>>(await _exportDAL.GetAll());

                var filteredList = list.Where(a =>
                      //(String.IsNullOrEmpty(entity.Date.ToString()) ? true : a.Date.ToString().Contains(entity.Date.ToString()))
                      (String.IsNullOrEmpty(entity.CarPlate) ? true : a.CarPlate.Contains(entity.CarPlate))
                     && (String.IsNullOrEmpty(entity.Weight.ToString()) ? true : a.Weight.ToString().Contains(entity.Weight.ToString()))
                     && (String.IsNullOrEmpty(entity.Pardon.ToString()) ? true : a.Pardon.ToString().Contains(entity.Pardon.ToString()))
                     && (String.IsNullOrEmpty(entity.WeightAfterPardon.ToString()) ? true : a.WeightAfterPardon.ToString().Contains(entity.WeightAfterPardon.ToString()))
                     && (String.IsNullOrEmpty(entity.Price.ToString()) ? true : a.Price.ToString().Contains(entity.Price.ToString()))
                     && (String.IsNullOrEmpty(entity.Debit.ToString()) ? true : a.Debit.ToString().Contains(entity.Debit.ToString()))
                     && (String.IsNullOrEmpty(entity.Credit.ToString()) ? true : a.Credit.ToString().Contains(entity.Credit.ToString()))
                     && (String.IsNullOrEmpty(entity.Total.ToString()) ? true : a.Total.ToString().Contains(entity.Total.ToString()))
                     && (String.IsNullOrEmpty(entity.Notes) ? true : a.Notes.Contains(entity.Notes))
                     );

                ResponseEntityList<ExportDTO> responseEntityList = new ResponseEntityList<ExportDTO>();
                responseEntityList.Total = filteredList.Count();
                responseEntityList.List = filteredList.Take(take).Skip(skip).ToList();

                return responseEntityList;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<ExportDTO> GetById(long id)
        {
            return _mapper.Map<ExportDTO>(await _exportDAL.GetById(id));
        }

        public async Task<long> Update(ExportDTO entity)
        {
            return await _exportDAL.Update(_mapper.Map<Export>(entity));
        }

        public async Task<ResponseEntityList<ExportDTO>> GetAllLite()
        {
            return new ResponseEntityList<ExportDTO>()
            {
                List = _mapper.Map<IEnumerable<ExportDTO>>(await _exportDAL.GetAll()).ToList(),
            };
        }

        public async Task<ResponseEntityList<ExportDTO>> GetExportsByFarmId(long farmId)
        {
            return new ResponseEntityList<ExportDTO>()
            {
                List = _mapper.Map<IEnumerable<ExportDTO>>(await _exportDAL.GetExportsByFarmId(farmId)).ToList(),
            };
        }

    }
}
