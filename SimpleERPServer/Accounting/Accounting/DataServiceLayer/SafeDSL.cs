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
using Shared.Classes;
using Shared.Enums;
using Shared.Entities.Credit;
using Clients.DataServiceLayer;
using Supplier.DataServiceLayer;

namespace Accouting.DataServiceLayer
{
    public class SafeDSL : ISafeDSL
    {
        bool _ISEDITMODE = false;
        ISafeDAL _safeDAL;
        IFarmAccountDSL _farmAccountDSL;
        IDriverAccountDSL _driverAccountDSL;
        ISelectorAccountDSL _selectorAccountDSL;
        IReaperAccountDSL _reaperAccountDSL;
        IStationAccountDSL _stationAccountDSL;
        private readonly IMapper _mapper;
        public SafeDSL(
            ISafeDAL safeDAL,
            IFarmAccountDSL farmAccountDSL,
            IDriverAccountDSL driverAccountDSL,
            ISelectorAccountDSL selectorAccountDSL,
            IReaperAccountDSL reaperAccountDSL,
            IStationAccountDSL stationAccountDSL,
            IMapper mapper)
        {
            _safeDAL = safeDAL;
            _farmAccountDSL = farmAccountDSL;
            _driverAccountDSL = driverAccountDSL;
            _reaperAccountDSL = reaperAccountDSL;
            _selectorAccountDSL = selectorAccountDSL;
            _stationAccountDSL = stationAccountDSL;
            _mapper = mapper;
        }
        public async Task<long> Save(SafeDTO entity)
        {
            try
            {
                if (entity.Id > 0)
                {
                    _ISEDITMODE = true;
                    DeleteFarmAccount(entity);
                    DeleteDriverAccount(entity);
                    DeleteReaperAccount(entity);
                    DeleteSelectorAccount(entity);
                    DeleteStationAccount(entity);
                }
                entity.Id = await _safeDAL.Save(_mapper.Map<Safe>(entity));
                switch (entity.AccountTreeType)
                {
                    case AccountTreeEnum.Suppliers:
                        await SaveFarmAccount(entity);
                        break;
                    case AccountTreeEnum.Clients:
                        await SaveStationAccount(entity);
                        break;
                    case AccountTreeEnum.Drivers:
                        await SaveDriverAccount(entity);
                        break;
                    case AccountTreeEnum.Reapers:
                        await SaveReaperAccount(entity);
                        break;
                    case AccountTreeEnum.Selectors:
                        await SaveSelectorAccount(entity);
                        break;
                }
                return entity.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private void DeleteFarmAccount(SafeDTO entity)
        {
            var farmAccount = GetFarmAccountBySafeId(entity.Id);
            if (farmAccount != null)
                _farmAccountDSL.Delete(farmAccount.Id);
        }
        private void DeleteDriverAccount(SafeDTO entity)
        {
            var driverAccount = GetDriverAccountBySafeId(entity.Id);
            if (driverAccount != null)
                _driverAccountDSL.Delete(driverAccount.Id);
        }
        private void DeleteReaperAccount(SafeDTO entity)
        {
            var reaperAccount = GetReaperAccountBySafeId(entity.Id);
            if (reaperAccount != null)
                _reaperAccountDSL.Delete(reaperAccount.Id);
        }
        private void DeleteSelectorAccount(SafeDTO entity)
        {
            var selectorAccount = GetSelectorAccountBySafeId(entity.Id);
            if (selectorAccount != null)
                _selectorAccountDSL.Delete(selectorAccount.Id);
        }
        private void DeleteStationAccount(SafeDTO entity)
        {
            var stationAccount = GetStationAccountBySafeId(entity.Id);
            if (stationAccount != null)
                _stationAccountDSL.Delete(stationAccount.Id);
        }

        private async Task<long> SaveFarmAccount(SafeDTO entity)
        {
            FarmAccountDTO farmAccount = new FarmAccountDTO()
            {
                SafeId = entity.Id,
                PaidDate = entity.Date,
                PaidUp = entity.Outcoming,
                RecieptNumber = entity.RecieptNumber,
                FarmId = entity.AccountId
            };
            return await _farmAccountDSL.Save(farmAccount);
        }
        private async Task<long> SaveDriverAccount(SafeDTO entity)
        {
            DriverAccountDTO driverAccount = new DriverAccountDTO()
            {
                SafeId = entity.Id,
                PaidDate = entity.Date,
                PaidUp = entity.Outcoming,
                RecieptNumber = entity.RecieptNumber,
                DriverId = entity.AccountId
            };
            return await _driverAccountDSL.Save(driverAccount);
        }
        private async Task<long> SaveSelectorAccount(SafeDTO entity)
        {
            SelectorAccountDTO selectorAccount = new SelectorAccountDTO()
            {
                SafeId = entity.Id,
                PaidDate = entity.Date,
                PaidUp = entity.Outcoming,
                RecieptNumber = entity.RecieptNumber,
                SelectorId = entity.AccountId
            };
            return await _selectorAccountDSL.Save(selectorAccount);
        }
        private async Task<long> SaveReaperAccount(SafeDTO entity)
        {
            ReaperAccountDTO reaperAccount = new ReaperAccountDTO()
            {
                SafeId = entity.Id,
                PaidDate = entity.Date,
                PaidUp = entity.Outcoming,
                RecieptNumber = entity.RecieptNumber,
                ReaperId = entity.AccountId
            };

            return await _reaperAccountDSL.Save(reaperAccount);

        }
        private async Task<long> SaveStationAccount(SafeDTO entity)
        {
            StationAccountDTO stationAccount = new StationAccountDTO()
            {
                SafeId = entity.Id,
                PaidDate = entity.Date,
                PaidUp = entity.Incoming,
                RecieptNumber = entity.RecieptNumber,
                StationId = entity.AccountId
            };

            return await _stationAccountDSL.Save(stationAccount);
        }
        public async Task<long> Delete(long id)
        {
            return await _safeDAL.Delete(id);
        }
        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<SafeDTO>>(await _safeDAL.GetAll()).AsQueryable();
            Response response = Helper.ToResult(list, dataSource);
            response.Entity = new SafeListDTO()
            {
                IncomingTotal = list.Sum(x => x.Incoming),
                OutcomingTotal = list.Sum(x => x.Outcoming),
            };
            return response;
        }
        public async Task<SafeDTO> GetById(long id)
        {
            return _mapper.Map<SafeDTO>(await _safeDAL.GetById(id));
        }
        public async Task<ResponseEntityList<SafeDTO>> GetAllLite()
        {
            return new ResponseEntityList<SafeDTO>()
            {
                List = _mapper.Map<IEnumerable<SafeDTO>>(await _safeDAL.GetAll()).ToList(),
            };
        }
        public FarmAccountDTO GetFarmAccountBySafeId(long safeId)
        {
            var farmAccount = _safeDAL.GetFarmAccountBySafeId(safeId);
            return farmAccount == null ? null : _mapper.Map<FarmAccountDTO>(farmAccount);
        }
        public StationAccountDTO GetStationAccountBySafeId(long safeId)
        {
            var stationAccount = _safeDAL.GetStationAccountBySafeId(safeId);
            return stationAccount == null ? null : _mapper.Map<StationAccountDTO>(stationAccount);
        }
        public DriverAccountDTO GetDriverAccountBySafeId(long safeId)
        {
            var driverAccount = _safeDAL.GetDriverAccountBySafeId(safeId);
            return driverAccount == null ? null : _mapper.Map<DriverAccountDTO>(driverAccount);
        }
        public SelectorAccountDTO GetSelectorAccountBySafeId(long safeId)
        {
            var selectorAccount = _safeDAL.GetSelectorAccountBySafeId(safeId);
            return selectorAccount == null ? null : _mapper.Map<SelectorAccountDTO>(selectorAccount);
        }
        public ReaperAccountDTO GetReaperAccountBySafeId(long safeId)
        {
            var reaperAccount = _safeDAL.GetReaperAccountBySafeId(safeId);
            return reaperAccount == null ? null : _mapper.Map<ReaperAccountDTO>(reaperAccount);
        }
    }
}
