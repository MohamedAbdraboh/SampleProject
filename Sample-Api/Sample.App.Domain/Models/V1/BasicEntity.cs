using Sample.App.Domain.Contract.V1;

namespace Sample.App.Domain.Models.V1
{
    public class BasicEntity : IBasicEntity
    {
        public Guid Id { get; set; }

        public string EnglishName { get; set; }
        public string ArabicName { get; set; }

        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
