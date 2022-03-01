using Sample.App.Domain.Contract.V1;

namespace Sample.App.Domain.Models.V1
{
    public class ProjectType :  BaseEntity, IProjectType
    {
        public List<Project> Projects { get; set; }
    }
}
