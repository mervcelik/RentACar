using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FuelRepository : EfRepositoryBase<Fuel, Guid, BaseDbContext>, IFuelRepository
{
    public FuelRepository(BaseDbContext baseDbContext) : base(baseDbContext)
    {

    }
}
