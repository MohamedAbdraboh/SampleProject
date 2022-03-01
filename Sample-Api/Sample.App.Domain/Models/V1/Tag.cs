using Sample.App.Domain.Contract.V1;

namespace Sample.App.Domain.Models.V1
{
    public class Tag : BaseEntity, ITag
    {
        public IEnumerable<ProjectTag> ProjectTags { get; set; }
    }
}
