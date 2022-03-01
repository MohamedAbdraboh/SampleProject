using Sample.App.Domain.Contract.V1;

namespace Sample.App.BLL.Services.Contract.V1
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        public IOperationResponse<IEnumerable<T>> GetAll();
        public Task<IOperationResponse<IEnumerable<T>>> GetAllAsync();

        public IOperationResponse<T> GetById(Guid id);
        public Task<IOperationResponse<T>> GetByIdAsync(Guid id);

        public IOperationResponse<T> Insert(T item);
        public Task<IOperationResponse<T>> InsertAsync(T item);

        public IOperationResponse<bool> Update(T item);
        public Task<IOperationResponse<bool>> UpdateAsync(T item);

        public IOperationResponse<bool> Delete(Guid id);
        public Task<IOperationResponse<bool>> DeleteAsync(Guid id);

        public int Save();
        public Task<int> SaveAsync();
    }
}
