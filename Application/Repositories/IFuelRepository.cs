using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface IFuelRepository:IAsyncRepository<Fuel,Guid>,IRepository<Fuel,Guid>
{
}
