using Sample.App.BLL.Services.Contract.V1;
using Sample.App.DAL;
using Sample.App.Domain.Models.V1;

namespace Sample.App.BLL.Services.Entities.V1
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}