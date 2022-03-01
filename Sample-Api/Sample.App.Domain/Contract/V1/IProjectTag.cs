using Sample.App.Domain.Models.V1;

namespace Sample.App.Domain.Contract.V1
{
    public interface IProjectTag
    {
        Guid ProjectId { get; set; }
        Project Project { get; set; }

        Guid TagId { get; set; }
        Tag Tag { get; set; }
    }
}
