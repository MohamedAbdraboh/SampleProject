using Sample.App.Domain.Contract.V1;

namespace Sample.App.Domain.Models.V1
{
    public class OperationResponse<T> : IOperationResponse<T>
    {
        public T Result { get; set; }
        public Enums.V1.ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public string InternalMessage { get; set; }
    }
}