using AutoMapper;
using Case.DTOs;
using Data.Models;
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
            CreateMap<Cases, CasesDTO>();
            CreateMap<CasesDTO, Cases>();
        }
    }
}
