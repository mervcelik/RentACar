﻿using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Repositories;

public interface IOperationClaimRepository : IAsyncRepository<OperationClaim, int>, IRepository<OperationClaim, int> { }