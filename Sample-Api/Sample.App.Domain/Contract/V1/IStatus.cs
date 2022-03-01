using Sample.App.Domain.Models.V1;

namespace Sample.App.Domain.Contract.V1
{
    interface IStatus: IBasicEntity
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<ProjectType> ProjectTypes { get; set; }
        public IEnumerable<SubStatus> SubStatuses { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}