using Sample.App.Domain.Models.V1;

namespace Sample.App.Domain.Contract.V1
{
    interface ISubStatus: IBasicEntity
    {
        public Guid StatusId { get; set; }
        public Status Status { get; set; }
    }
}
