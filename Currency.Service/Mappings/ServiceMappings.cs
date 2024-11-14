using AutoMapper;
using Currency.Model.Dtos.Condition;
using Currency.Model.Dtos.DataModel;
using Currency.Service.Dtos.info;
using Currency.Service.Dtos.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Currency.Service.Mappings
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            // Info -> Condition
            this.CreateMap<CardInfo, CardCondition>();
            this.CreateMap<CardSearchInfo, CardSearchCondition>();

            // DataModel -> ResultModel
            this.CreateMap<CardDataModel, CardResultModel>();
        }
    }
}
