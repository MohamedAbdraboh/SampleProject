using Sample.App.BLL.Services.Contract.V1;
using Sample.App.DAL;
using Sample.App.Domain.Contract.V1;
using Sample.App.Domain.Enums.V1;
using Sample.App.Domain.Models.V1;
using Microsoft.EntityFrameworkCore;

namespace Sample.App.BLL.Services.Entities.V1
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
           this.context = context;
        }
        public async Task<IOperationResponse<IEnumerable<User>>> SearchByName(string name)
        {
            IOperationResponse<IEnumerable<User>> response;

            try
            {
                IQueryable<User> userQuery = context.Users;

                if (!string.IsNullOrEmpty(name))
                {
                    userQuery = userQuery.Where(u => u.FirstName.ToLower().Contains(name.ToLower())
                    || u.LastName.ToLower().Contains(name.ToLower()));
                }

                response = new OperationResponse<IEnumerable<User>>
                {
                    Status = ResponseStatus.Fail,
                    Result = await userQuery.ToListAsync(),
                    Message = ""
                };

            }
            catch (Exception ex)
            {
                response = new OperationResponse<IEnumerable<User>>
                {
                    Status = ResponseStatus.Fail,
                    Result = null,
                    Message = ex.Message
                };
            }

            return response;
        }

        public async Task<IOperationResponse<User>> SearchByEmail(string email)
        {
            IOperationResponse<User> response;

            try
            {
                IQueryable<User> userQuery = context.Users;

                if (!string.IsNullOrEmpty(email))
                {
                    userQuery = userQuery.Where(u =>
                       u.UserContact.EmailAddress1.ToLower().Contains(email.ToLower())
                    || u.UserContact.EmailAddress2.ToLower().Contains(email.ToLower())
                    || u.UserContact.EmailAddress3.ToLower().Contains(email.ToLower()));
                }

                response = new OperationResponse<User>
                {
                    Status = ResponseStatus.Fail,
                    Result = await userQuery.FirstOrDefaultAsync(),
                    Message = ""
                };

            }
            catch (Exception ex)
            {
                response = new OperationResponse<User>
                {
                    Status = ResponseStatus.Fail,
                    Result = null,
                    Message = ex.Message
                };
            }

            return response;
        }
    }
}
