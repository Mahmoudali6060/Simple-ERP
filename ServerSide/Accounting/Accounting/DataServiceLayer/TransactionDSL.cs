using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entities.Shared;
using Data.Entities.Shared;
using Accouting.DataAccessLayer;
using Shared.Entities.Credit;
using Supplier.DataServiceLayer;
using Clients.DataServiceLayer;
using Data.Entities.Debit;
using Shared.Entities.Debit;
using Data.Contexts;

using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Utilities;
using Shared.Classes;

namespace Accouting.DataServiceLayer
{
    public class TransactionDSL : ITransactionDSL
    {
        bool _ISEDITMODE = false;
        ITransactionDAL _transactionDAL;
        IIncomeDSL _incomeDSL;
        ITransferDSL _transferDSL;
        ISelectorDetailDSL _selectorDSL;
        IReaperDetailDSL _reaperDetailDSL;
        IOutcomeDSL _outcomeDSL;
        AppDbContext _context;
        private readonly IMapper _mapper;
        public TransactionDSL(ITransactionDAL transactionDAL, IIncomeDSL incomeDSL, ITransferDSL transferDSL, ISelectorDetailDSL selectorDSL, IReaperDetailDSL reaperDetailDSL, IOutcomeDSL outcomeDSL, AppDbContext context, IMapper mapper)
        {
            _transactionDAL = transactionDAL;
            _incomeDSL = incomeDSL;
            _transferDSL = transferDSL;
            _selectorDSL = selectorDSL;
            _reaperDetailDSL = reaperDetailDSL;
            _outcomeDSL = outcomeDSL;
            _mapper = mapper;
            _context = context;
        }

        public async Task<long> Save(TransactionDTO entity)
        {

            //using (DbTransaction transaction = _context.Database.BeginTransaction())
            //{

            try
            {
                if (entity.Id > 0)
                {
                    _ISEDITMODE = true;
                }
                long transactionId = await _transactionDAL.Save(_mapper.Map<Transaction>(entity));
                entity.Id = transactionId;
                long incomeId = await SaveIncome(entity);
                long transferId = await SaveTransfer(entity);
                long selectorId = await SaveSelector(entity);
                long reaperId = await SaveReaper(entity);
                long outcomeId = await SaveOutcome(entity);
                //transaction.Commit();
            }
            catch (Exception ex)
            {
                //transaction.Rollback();
                Console.WriteLine("Error occurred.");
            }
            // }
            return 1;
        }
        #region Transaction related tables
        private async Task<long> SaveIncome(TransactionDTO entity)
        {
            IncomeDTO income = new IncomeDTO()
            {
                Date = entity.Date,
                CartNumber = entity.CartNumber,
                CategoryId = entity.CategoryId,
                DriverId = entity.DriverId,
                FarmId = entity.FarmId,
                Quantity = entity.SupplierQuantity,
                KiloDiscount = entity.Pardon,
                KiloPrice = entity.SupplierPrice,
                StationId = entity.StationId,
                TransactionId = entity.Id
            };

            if (_ISEDITMODE)//Edit Mode
            {
                var oldIncome = await GetIncomeByTransactionId(entity.Id);
                income.Id = oldIncome.Id;
            }
            return await _incomeDSL.Save(income);
        }
        private async Task<long> SaveTransfer(TransactionDTO entity)
        {

            TransferDTO transfer = new TransferDTO()
            {
                Date = entity.Date,
                FarmId = entity.FarmId,
                StationId = entity.StationId,
                Nolon = entity.Nolon,
                DriverId = entity.DriverId,
                TransactionId = entity.Id
            };
            if (_ISEDITMODE)//Edit Mode
            {
                var oldTransfer = await GetTransferByTransactionId(entity.Id);
                transfer.Id = oldTransfer.Id;
            }

            return await _transferDSL.Save(transfer);
        }
        private async Task<long> SaveSelector(TransactionDTO entity)
        {
            SelectorDetailDTO selectorDetail = new SelectorDetailDTO()
            {
                PayDate = entity.Date,
                Pay = entity.SelectorsPay,
                TransactionId = entity.Id,
                SelectorId = entity.SelectorId
            };
            if (_ISEDITMODE)//Edit Mode
            {
                var oldSelector = await GetSelectorDetailByTransactionId(entity.Id);
                selectorDetail.Id = oldSelector.Id;
            }
            return await _selectorDSL.Save(selectorDetail);
        }
        private async Task<long> SaveReaper(TransactionDTO entity)
        {
            ReaperDetailDTO reaperDetail = new ReaperDetailDTO()
            {
                Date = entity.Date,
                Weight = entity.ClientQuantity,
                TonPrice = entity.ReapersPay,
                ReaperId = entity.ReaperId,
                TransactionId = entity.Id
            };
            if (_ISEDITMODE)//Edit Mode
            {
                var oldReaperDetail = await GetReaperDetailByTransactionId(entity.Id);
                reaperDetail.Id = oldReaperDetail.Id;
            }
            return await _reaperDetailDSL.Save(reaperDetail);
        }
        private async Task<long> SaveOutcome(TransactionDTO entity)
        {
            OutcomeDTO outcome = new OutcomeDTO()
            {
                Date = entity.Date,
                CartNumber = entity.CartNumber,
                CategoryId = entity.CategoryId,
                DriverId = entity.DriverId,
                FarmId = entity.FarmId,
                Quantity = entity.ClientQuantity,
                KiloDiscount = entity.ClientDiscount,
                Total = entity.ClientTotal,
                KiloPrice = entity.ClientPrice,
                StationId = entity.StationId,
                TransactionId = entity.Id
            };
            if (_ISEDITMODE)//Edit Mode
            {
                var oldOutcome = await GetOutcomtByTransactionId(entity.Id);
                outcome.Id = oldOutcome.Id;
            }
            return await _outcomeDSL.Save(outcome);
        }
        #endregion

        public async Task<long> Delete(long id)
        {
            return await _transactionDAL.Delete(id);
        }
        public async Task<Response> GetAll(DataSource dataSource)
        {
            var list = _mapper.Map<IEnumerable<TransactionDTO>>(await _transactionDAL.GetAll()).AsQueryable();
            return Helper.ToResult(list, dataSource);
        }
        public async Task<TransactionDTO> GetById(long id)
        {
            return _mapper.Map<TransactionDTO>(await _transactionDAL.GetById(id));
        }
        public async Task<ResponseEntityList<TransactionDTO>> GetAllLite()
        {
            return new ResponseEntityList<TransactionDTO>()
            {
                List = _mapper.Map<IEnumerable<TransactionDTO>>(await _transactionDAL.GetAll()).ToList(),
            };
        }

        public async Task<IncomeDTO> GetIncomeByTransactionId(long transactioId)
        {
            return _mapper.Map<IncomeDTO>(await _transactionDAL.GetIncomeByTransactionId(transactioId));
        }

        public async Task<OutcomeDTO> GetOutcomtByTransactionId(long transactioId)
        {
            return _mapper.Map<OutcomeDTO>(await _transactionDAL.GetOutcomtByTransactionId(transactioId));
        }

        public async Task<TransferDTO> GetTransferByTransactionId(long transactioId)
        {
            return _mapper.Map<TransferDTO>(await _transactionDAL.GetTransferByTransactionId(transactioId));
        }

        public async Task<SelectorDetailDTO> GetSelectorDetailByTransactionId(long transactioId)
        {
            return _mapper.Map<SelectorDetailDTO>(await _transactionDAL.GetSelectorDetailByTransactionId(transactioId));
        }

        public async Task<ReaperDetailDTO> GetReaperDetailByTransactionId(long transactioId)
        {
            return _mapper.Map<ReaperDetailDTO>(await _transactionDAL.GetReaperDetailByTransactionId(transactioId));
        }
    }
}
