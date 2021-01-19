using AlugaiWEB.Models;
using AutoMapper;
using Core;

namespace AlugaiWEB.Mappers
{
    public class DespesasProfile : Profile
    {
        public DespesasProfile()
        {
            CreateMap<DespesasModel, Despesas>().ReverseMap();
        }
    }
}
