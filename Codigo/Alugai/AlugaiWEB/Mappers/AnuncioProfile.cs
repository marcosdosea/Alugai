using AutoMapper;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
