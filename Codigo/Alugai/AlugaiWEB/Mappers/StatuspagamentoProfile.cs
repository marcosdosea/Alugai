using AlugaiWEB.Models;
using AutoMapper;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlugaiWEB.Mappers
{
    public class StatuspagamentoProfile : Profile
    {
        public StatuspagamentoProfile()
        {
            CreateMap<StatuspagamentoModel, Statuspagamento>().ReverseMap();
        }
    }
}
