using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetlistByDynamic;
using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //BrandName olarak yazıldığında automapper formembers işlemi yapılmasada map işlemini yapar. ama isim daha farklı oldupunda (bname gibi) durumu varsa property neyin denk geldiğini bu şekilde belirtebiliriz.
        CreateMap<Model, GetListModelListItemDto>().ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name))
                                        .ForMember(c => c.FuelName, opt => opt.MapFrom(c => c.Fuel.Name))
                                        .ForMember(c => c.TransmissionName, opt => opt.MapFrom(c => c.Transmission.Name))
                                        .ReverseMap();
        CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();

        CreateMap<Model, GetListByDynamicModelListItemDto>().ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name))
                                        .ForMember(c => c.FuelName, opt => opt.MapFrom(c => c.Fuel.Name))
                                        .ForMember(c => c.TransmissionName, opt => opt.MapFrom(c => c.Transmission.Name))
                                        .ReverseMap();
        CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicModelListItemDto>>().ReverseMap();
    }
}
