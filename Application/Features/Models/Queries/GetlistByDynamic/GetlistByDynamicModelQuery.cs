using Application.Features.Models.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetlistByDynamic;


public class GetlistByDynamicModelQuery : IRequest<GetListResponse<GetListByDynamicModelListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
}
class GetlistByDynamicModelQueryHandler : IRequestHandler<GetlistByDynamicModelQuery, GetListResponse<GetListByDynamicModelListItemDto>>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetlistByDynamicModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByDynamicModelListItemDto>> Handle(GetlistByDynamicModelQuery request, CancellationToken cancellationToken)
    {
        Paginate<Model> models = await _modelRepository.GetListByDynamicAsync(
            request.DynamicQuery,
              include: m => m.Include(x => x.Brand).Include(x => x.Fuel).Include(x => x.Transmission),
              index: request.PageRequest.PageIndex,
              size: request.PageRequest.PageSize
              );

        var response = _mapper.Map<GetListResponse<GetListByDynamicModelListItemDto>>(models);
        return response;
    }
}