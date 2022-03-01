using Sample.App.Domain.Contract.V1;

namespace Sample.App.Domain.Models.V1
{
    public class UserContactCard : IContactCard
    {
        public Guid Id { get; set; }

        public string EmailAddress1 { get; set; }
        public string EmailAddress2 { get; set; }
        public string EmailAddress3 { get; set; }

        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        public string FacebookUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public string GithubUrl { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}