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
        ITransactionDAL _transactionDAL;
        IIncomeDSL _incomeDSL;
        ITransferDSL _transferDSL;
        ISelectorDSL _selectorDSL;
        IReaperDetailDSL _reaperDetailDSL;
        IOutcomeDSL _outcomeDSL;
        AppDbContext _context;
        private readonly IMapper _mapper;
        public TransactionDSL(ITransactionDAL transactionDAL, IIncomeDSL incomeDSL, ITransferDSL transferDSL, ISelectorDSL selectorDSL, IReaperDetailDSL reaperDetailDSL, IOutcomeDSL outcomeDSL, AppDbContext context, IMapper mapper)
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

        public async Task<long> Add(TransactionDTO entity)
        {

            //using (DbTransaction transaction = _context.Database.BeginTransaction())
            //{

            try
            {
                long transactionId = await _transactionDAL.Add(_mapper.Map<Transaction>(entity));
                long incomeId = await AddIncome(entity);
                long transferId = await AddTransfer(entity);
                long selectorId = await AddSelector(entity);
                long reaperId = await AddReaper(entity);
                long outcomeId = await AddOutcome(entity);
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
        private async Task<long> AddIncome(TransactionDTO entity)
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
                StationId = entity.StationId
            };
            return await _incomeDSL.Add(income);
        }
        private async Task<long> AddTransfer(TransactionDTO entity)
        {
            TransferDTO transfer = new TransferDTO()
            {
                Date = entity.Date,
                FarmId = entity.FarmId,
                StationId = entity.StationId,
                Nolon = entity.Nolon,
                DriverId = entity.DriverId
            };
            return await _transferDSL.Add(transfer);
        }
        private async Task<long> AddSelector(TransactionDTO entity)
        {
            SelectorDTO selector = new SelectorDTO()
            {
                PayDate = entity.Date,
                Pay = entity.SelectorsPay
            };
            return await _selectorDSL.Add(selector);
        }
        private async Task<long> AddReaper(TransactionDTO entity)
        {
            ReaperDetailDTO reaperDetail = new ReaperDetailDTO()
            {
                Date = entity.Date,
                Weight = entity.ClientQuantity,
                TonPrice = entity.ReapersPay,
                ReaperId = entity.ReaperId
            };
            return await _reaperDetailDSL.Add(reaperDetail);
        }
        private async Task<long> AddOutcome(TransactionDTO entity)
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
                StationId = entity.StationId
            };
            return await _outcomeDSL.Add(outcome);
        }
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
        public async Task<long> Update(TransactionDTO entity)
        {
            return await _transactionDAL.Update(_mapper.Map<Transaction>(entity));
        }
        public async Task<ResponseEntityList<TransactionDTO>> GetAllLite()
        {
            return new ResponseEntityList<TransactionDTO>()
            {
                List = _mapper.Map<IEnumerable<TransactionDTO>>(await _transactionDAL.GetAll()).ToList(),
            };
        }
    }
}
