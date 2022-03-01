using Sample.App.Domain.Models.V1;

namespace Sample.App.Domain.Contract.V1
{
    interface IProjectType : IBaseEntity
    {
        public List<Project> Projects { get; set; }
    }
}
