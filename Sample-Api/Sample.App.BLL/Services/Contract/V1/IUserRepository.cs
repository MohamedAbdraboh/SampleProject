using Sample.App.Domain.Contract.V1;
using Sample.App.Domain.Models.V1;

namespace Sample.App.BLL.Services.Contract.V1
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<IOperationResponse<User>> SearchByEmail(string email);
        public Task<IOperationResponse<IEnumerable<User>>> SearchByName(string name);
    }
}
