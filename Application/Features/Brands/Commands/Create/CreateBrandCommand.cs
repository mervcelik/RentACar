﻿using Application.Features.Brands.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Piplines.Caching;
using Core.Application.Piplines.Logging;
using Core.Application.Piplines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ITransactionalRequest, ICacheRemoverRequest,ILoggableRequest
{
    public string Name { get; set; }
    public string? CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetBrands";
}
public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly BrandBusinessRules _brandBusinessRules;
    public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _brandBusinessRules = brandBusinessRules;
    }
    public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);

        Brand brand = _mapper.Map<Brand>(request);
        brand.Id = Guid.NewGuid();

        await _brandRepository.AddAsync(brand);

        CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(brand);
        return createdBrandResponse;
    }
}
