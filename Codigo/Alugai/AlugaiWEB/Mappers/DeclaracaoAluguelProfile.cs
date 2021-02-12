using AlugaiWEB.Models;
using AutoMapper;
using Core;

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
