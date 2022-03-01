using Sample.App.Domain.Contract.V1;

namespace Sample.App.Domain.Models.V1
{
    public class ProjectTag : IProjectTag
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
