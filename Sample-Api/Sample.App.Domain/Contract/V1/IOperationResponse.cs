using Sample.App.Domain.Enums.V1;

namespace Sample.App.Domain.Contract.V1
{
    public interface IOperationResponse<T>
    {
        T Result { get; set; }
        ResponseStatus Status { get; set; }
        string Message { get; set; }
        string InternalMessage { get; set; }
    }
}
