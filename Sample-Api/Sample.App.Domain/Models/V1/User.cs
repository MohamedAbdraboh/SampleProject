using Sample.App.Domain.Contract.V1;

namespace Sample.App.Domain.Models.V1
{
    public class User : BasicEntity, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                int age = 0;
                age = DateTime.Now.Year - DateOfBirth.Year;
                if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
                    age = age - 1;

                return age;
            }
        }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public Guid UserContactId { get; set; }
        public UserContactCard UserContact { get; set; }

        public Guid StatusId { get; set; }
        public Status Status { get; set; }

        public Guid SubStatusId { get; set; }
        public SubStatus SubStatus { get; set; }

        public IEnumerable<Project> CreatedByProjects { get; set; }
        public IEnumerable<Project> ModifiedByProjects { get; set; }
        public IEnumerable<ProjectType> CreatedByProjectTypes { get; set; }
        public IEnumerable<ProjectType> ModifiedByProjectTypes { get; set; }
        public IEnumerable<Tag> CreatedByTags { get; set; }
        public IEnumerable<Tag> ModifiedByTags { get; set; }
    }
}