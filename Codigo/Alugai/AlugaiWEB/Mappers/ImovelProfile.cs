using AutoMapper;
using Core;
using AlugaiWEB.Models;

namespace AlugaiWEB.Mappers
{
    public class ImovelProfile : Profile
    {
        public ImovelProfile()
        {
            CreateMap<ImovelModel, Imovel>().ReverseMap();
        }
    }
}
