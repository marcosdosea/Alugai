using AutoMapper;
using Core;
using AlugaiWEB.Models;

namespace AlugaiWEB.Mappers
{
    public class AnuncioProfile : Profile
    {
        public AnuncioProfile()
        {
            CreateMap<AnuncioModel, Anuncio>().ReverseMap();
        }
    }
}
