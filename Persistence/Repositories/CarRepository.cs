using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CarRepository : EfRepositoryBase<Car, Guid, BaseDbContext>, ICarRepository
{
    public CarRepository(BaseDbContext baseDbContext) : base(baseDbContext)
    {

    }
}
