using AutoMapper;
using Core;
using AlugaiWEB.Models;

namespace AlugaiWEB.Mappers
{
    public class AluguelProfile: Profile
    {
        public AluguelProfile()
        {
            CreateMap<AluguelModel, Aluguel>().ReverseMap();
        }
    }
}
