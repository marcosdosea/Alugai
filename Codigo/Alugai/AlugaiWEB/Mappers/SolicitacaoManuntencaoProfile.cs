using AlugaiWEB.Models;
using AutoMapper;
using Core;

namespace AlugaiWEB.Mappers
{
    public class SolicitacaoManuntencaoProfile : Profile
    {
        public SolicitacaoManuntencaoProfile()
        {
            CreateMap<SolicitacaoManuntecaoModel, Manuntencao>().ReverseMap();
        }
    }
}
