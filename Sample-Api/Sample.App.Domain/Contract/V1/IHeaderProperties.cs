using Sample.App.Domain.Models.V1;

namespace Sample.App.Domain.Contract.V1
{
    public interface IHeaderProperties
    {
        public string UserLanguage { get; set; }
        public string AuthToken { get; set; }
        public string UserName { get; set; }
        public bool IsLoggedIn { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
