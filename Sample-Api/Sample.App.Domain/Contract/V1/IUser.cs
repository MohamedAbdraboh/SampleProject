using Sample.App.Domain.Models.V1;

namespace Sample.App.Domain.Contract.V1
{
    interface IUser : IBasicEntity
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

        public Guid UserContactId { get; set; }
        public UserContactCard UserContact { get; set; }

        public Guid StatusId { get; set; }
        public Status Status { get; set; }

        public Guid SubStatusId { get; set; }
        public SubStatus SubStatus { get; set; }
    }
}
