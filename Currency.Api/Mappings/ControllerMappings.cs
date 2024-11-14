using AutoMapper;
using Currency.Api.Models;
using Currency.Api.Parameter;
using Currency.Service.Dtos.info;
using Currency.Service.Dtos.ResultModel;

namespace Currency.Api.Mappings
{
    public class ControllerMappings : Profile
    {
        public ControllerMappings()
        {
            // Parameter -> Info
            this.CreateMap<CardParameter, CardInfo>();
            this.CreateMap<CardSearchParameter, CardSearchInfo>();

            // ResultModel -> ViewModel
            this.CreateMap<CardResultModel, CardViewModel>();
        }
    }
}
