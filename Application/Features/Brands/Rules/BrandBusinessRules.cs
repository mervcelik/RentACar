using Application.Features.Brands.Constans;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules :BaseBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
    {
        var result = await _brandRepository.GetAsync(b => b.Name.ToLower() == name.ToLower());
        if (result != null) throw new BusinessException(BrandsMessages.BrandNameExists);
    }
}
