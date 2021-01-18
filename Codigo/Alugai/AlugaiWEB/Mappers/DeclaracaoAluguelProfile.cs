using AlugaiWEB.Models;
using AutoMapper;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlugaiWEB.Mappers
{
    public class DeclaracaoAluguelProfile : Profile
    {
        public DeclaracaoAluguelProfile()
        {
            CreateMap<DeclaracaoAluguelModel, Aluguel>().ReverseMap();
        }
    }
}
