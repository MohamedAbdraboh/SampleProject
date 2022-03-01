using Sample.App.Domain.Models.V1;

namespace Sample.App.Domain.Contract.V1
{
    interface ITag : IBaseEntity
    {
        public IEnumerable<ProjectTag> ProjectTags { get; set; }
    }
}
