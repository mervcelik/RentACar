using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface IModelRepository:IAsyncRepository<Model,Guid>,IRepository<Model,Guid>
{
}
