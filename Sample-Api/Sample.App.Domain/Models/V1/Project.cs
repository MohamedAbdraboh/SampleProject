using Sample.App.Domain.Contract.V1;

namespace Sample.App.Domain.Models.V1
{
    public class Project : BaseEntity, IProject
    {
        public Guid ProjectTypeId { get; set; }
        public ProjectType ProjectType { get; set; }

        public IEnumerable<ProjectTag> ProjectTags { get; set; }
    }
}
