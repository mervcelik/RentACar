﻿using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class BrandRepository : EfRepositoryBase<Brand, Guid, BaseDbContext>, IBrandRepository
{
    public BrandRepository(BaseDbContext baseDbContext) : base(baseDbContext)
    {

    }
}
