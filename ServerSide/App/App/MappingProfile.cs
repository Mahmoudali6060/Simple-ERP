using AutoMapper;
using Data.Entities;
using Farms.Models;
using Stations.Models;
//using Case.DTOs;
//using Data.Models;
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
            CreateMap<Export, ExportDTO>();
            CreateMap<ExportDTO, Export>();
            CreateMap<Station, StationDTO>();
            CreateMap<StationDTO, Station>();
            CreateMap<Income, IncomeDTO>();
            CreateMap<IncomeDTO, Income>();
        }
    }
}
