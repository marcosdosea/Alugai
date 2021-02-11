using AlugaiWEB.Models;
using AutoMapper;
using Core;

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
