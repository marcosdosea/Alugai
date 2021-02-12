using AutoMapper;
using Core;
using AlugaiWEB.Models;

namespace AlugaiWEB.Mappers
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaModel, Pessoa>().ReverseMap();
        }
    }
}
