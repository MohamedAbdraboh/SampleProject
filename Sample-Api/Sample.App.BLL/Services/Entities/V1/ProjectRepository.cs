using Sample.App.BLL.Services.Contract.V1;
using Sample.App.DAL;
using Sample.App.Domain.Models.V1;

namespace Sample.App.BLL.Services.Entities.V1
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}