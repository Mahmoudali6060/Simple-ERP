using AutoMapper;
using Data.Entities;
using Data.Entities.Credit;
using Data.Entities.Debit;
using Data.Entities.Shared;
using Shared.Entities.Credit;
using Shared.Entities.Debit;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Farm, FarmDTO>();
            CreateMap<FarmDTO, Farm>();
            CreateMap<Income, IncomeDTO>();
            CreateMap<IncomeDTO, Income>();
            CreateMap<Station, StationDTO>();
            CreateMap<StationDTO, Station>();
            CreateMap<Outcome, OutcomeDTO>();
            CreateMap<OutcomeDTO, Outcome>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Driver, DriverDTO>();
            CreateMap<DriverDTO, Driver>();
            CreateMap<Reaper, ReaperDTO>();
            CreateMap<ReaperDTO, Reaper>();
            CreateMap<Transaction, TransactionDTO>();
            CreateMap<TransactionDTO, Transaction>();
            CreateMap<Transfer, TransferDTO>();
            CreateMap<TransferDTO, Transfer>();
            CreateMap<ReaperDetail, ReaperDetailDTO>();
            CreateMap<ReaperDetailDTO, ReaperDetail>();
            CreateMap<Selector, SelectorDTO>();
            CreateMap<SelectorDTO, Selector>();
        }
    }
}
