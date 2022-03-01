using Sample.App.Domain.Models.V1;
using Sample.App.Domain.Contract.V1;

namespace Sample.App.BLL.Services.Contract.V1
{
    public interface ISubStatusRepository : IRepository<SubStatus>
    {
        public Task<IOperationResponse<IEnumerable<SubStatus>>> GetAllWithStatusAsync();
    }
}
