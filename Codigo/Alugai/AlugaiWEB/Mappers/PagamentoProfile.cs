using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using AlugaiWEB.Models;

namespace AlugaiWEB.Mappers
{
    public class PagamentoProfile : Profile
    {
        public PagamentoProfile()
        {
            CreateMap<PagamentoModelcs, Pagamento>().ReverseMap();
        }
    }
}
