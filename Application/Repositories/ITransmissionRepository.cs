using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface ITransmissionRepository : IAsyncRepository<Transmission, Guid>, IRepository<Transmission, Guid>
{
}
