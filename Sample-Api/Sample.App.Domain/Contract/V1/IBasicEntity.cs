namespace Sample.App.Domain.Contract.V1
{
    public interface IBasicEntity
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
