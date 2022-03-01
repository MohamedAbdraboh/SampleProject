using Sample.App.Domain.Models.V1;

namespace Sample.App.Domain.Contract.V1
{
    public interface IProject : IBaseEntity
    {
        public Guid ProjectTypeId { get; set; }
        public ProjectType ProjectType { get; set; }

        public IEnumerable<ProjectTag> ProjectTags { get; set; }
    }
}
