﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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