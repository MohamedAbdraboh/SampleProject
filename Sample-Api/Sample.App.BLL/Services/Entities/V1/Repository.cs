using Sample.App.BLL.Services.Contract.V1;
using Sample.App.DAL;
using Sample.App.Domain.Contract.V1;
using Sample.App.Domain.Enums.V1;
using Sample.App.Domain.Models.V1;
using Microsoft.EntityFrameworkCore;

namespace Sample.App.BLL.Services.Entities.V1
{
    public class Repository<T> : IRepository<T> where T : BasicEntity
    {
        private ApplicationDbContext _context = null;
        private DbSet<T> table = null;

        public Repository(ApplicationDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        // Get all
        public virtual IOperationResponse<IEnumerable<T>> GetAll()
        {
            IOperationResponse<IEnumerable<T>> response = new OperationResponse<IEnumerable<T>>();

            try
            {
                response = new OperationResponse<IEnumerable<T>>()
                {
                    Status = ResponseStatus.Success,
                    Result = table.ToList(),
                    Message = null
                };
            }
            catch (Exception ex)
            {
                response = new OperationResponse<IEnumerable<T>>()
                {
                    Status = ResponseStatus.Fail,
                    Result = null,
                    Message = ex.Message
                };
            }

            return response;
        }
        public virtual async Task<IOperationResponse<IEnumerable<T>>> GetAllAsync()
        {
            IOperationResponse<IEnumerable<T>> response = new OperationResponse<IEnumerable<T>>();
            try
            {
                response = new OperationResponse<IEnumerable<T>>()
                {
                    Status = ResponseStatus.Success,
                    Result = await table.ToListAsync(),
                    Message = null
                };
            }
            catch (Exception ex)
            {
                response = new OperationResponse<IEnumerable<T>>()
                {
                    Status = ResponseStatus.Fail,
                    Result = null,
                    Message = ex.Message
                };
            }
            
            return response;
        }

        // Get by id
        public virtual IOperationResponse<T> GetById(Guid id)
        {
            IOperationResponse<T> response;

            try
            {
                var item = table.Find(id);

                if (item != null)
                {
                    response = new OperationResponse<T>()
                    {
                        Status = ResponseStatus.Success,
                        Result = item,
                        Message = null
                    };
                }
                else
                {
                    response = new OperationResponse<T>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = null,
                        Message = "The item Can't be found"
                    };
                }
            }
            catch (Exception ex)
            {
                response = new OperationResponse<T>()
                {
                    Status = ResponseStatus.Fail,
                    Result = null,
                    Message = ex.Message
                };
            }

            return response;
        }
        public virtual async Task<IOperationResponse<T>> GetByIdAsync(Guid id)
        {
            IOperationResponse<T> response;

            try
            {
                var item = await table.FindAsync(id);

                if (item != null)
                {
                    response = new OperationResponse<T>()
                    {
                        Status = ResponseStatus.Success,
                        Result = item,
                        Message = null
                    };
                }
                else
                {
                    response = new OperationResponse<T>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = null,
                        Message = "The item Can't be found"
                    };
                }
            }
            catch (Exception ex)
            {
                response = new OperationResponse<T>()
                {
                    Status = ResponseStatus.Fail,
                    Result = null,
                    Message = ex.Message
                };
            }

            return response;
        }

        // Insert
        public virtual IOperationResponse<T> Insert(T item)
        {
            IOperationResponse<T> response;
            try
            {
                var result = table.Add(item);
                int affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    response = new OperationResponse<T>()
                    {
                        Status = ResponseStatus.Success,
                        Result = result.Entity,
                        Message = null
                    };
                }
                else
                {
                    response = new OperationResponse<T>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = null,
                        Message = "Can't add item at context"
                    };
                }
            }
            catch (Exception ex)
            {
                response = new OperationResponse<T>()
                {
                    Status = ResponseStatus.Fail,
                    Result = null,
                    Message = ex.Message
                };
            }
            return response;
        }
        public virtual async Task<IOperationResponse<T>> InsertAsync(T item)
        {
            IOperationResponse<T> response;
            try
            {
                var resalut = await table.AddAsync(item);
                int affectedRows = await SaveAsync();

                if (affectedRows > 0)
                {
                    response = new OperationResponse<T>()
                    {
                        Status = ResponseStatus.Success,
                        Result = resalut.Entity,
                        Message = null
                    };
                }
                else
                {
                    response = new OperationResponse<T>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = null,
                        Message = "Can't add item to context"
                    };
                }
            }
            catch (Exception ex)
            {
                response = new OperationResponse<T>()
                {
                    Status = ResponseStatus.Fail,
                    Result = null,
                    Message = ex.Message
                };
            }
            return response;
        }

        // Update
        public virtual IOperationResponse<bool> Update(T item)
        {
            IOperationResponse<bool> response;
            try
            {
                var entity = table.FirstOrDefault(i => i.Id == item.Id);

                if (entity != null)
                {
                    entity.EnglishName = item.EnglishName;
                    entity.ArabicName = item.ArabicName;

                    entity.EnglishDescription = item.EnglishDescription;
                    entity.ArabicDescription = item.ArabicDescription;

                    entity.CreatedOn = item.CreatedOn;
                    entity.ModifiedOn = item.ModifiedOn;

                    table.Update(entity);
                    int affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        response = new OperationResponse<bool>()
                        {
                            Status = ResponseStatus.Success,
                            Result = true,
                            Message = null
                        };
                    }
                    else
                    {
                        response = new OperationResponse<bool>()
                        {
                            Status = ResponseStatus.Fail,
                            Result = false,
                            Message = "Can't update item at context"
                        };
                    }
                }
                else
                {
                    response = new OperationResponse<bool>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = false,
                        Message = "Can't Find item at context"
                    };
                }
            }
            catch (Exception ex)
            {
                response = new OperationResponse<bool>()
                {
                    Status = ResponseStatus.Fail,
                    Result = false,
                    Message = ex.Message
                };
            }

            return response;
        }
        public virtual async Task<IOperationResponse<bool>> UpdateAsync(T item)
        {
            IOperationResponse<bool> response;
            try
            {
                var entity = await table.FirstOrDefaultAsync(i => i.Id == item.Id);

                if (entity != null)
                {
                    entity.EnglishName = item.EnglishName;
                    entity.ArabicName = item.ArabicName;

                    entity.EnglishDescription = item.EnglishDescription;
                    entity.ArabicDescription = item.ArabicDescription;

                    entity.CreatedOn = item.CreatedOn;
                    entity.ModifiedOn = item.ModifiedOn;

                    table.Update(entity);
                    int affectedRows = await _context.SaveChangesAsync();

                    if (affectedRows > 0)
                    {
                        response = new OperationResponse<bool>()
                        {
                            Status = ResponseStatus.Success,
                            Result = true,
                            Message = null
                        };
                    }
                    else
                    {
                        response = new OperationResponse<bool>()
                        {
                            Status = ResponseStatus.Fail,
                            Result = false,
                            Message = "Can't update item at context"
                        };
                    }
                }
                else
                {
                    response = new OperationResponse<bool>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = false,
                        Message = "Can't Find item at context"
                    };
                }
            }
            catch (Exception ex)
            {
                response = new OperationResponse<bool>()
                {
                    Status = ResponseStatus.Fail,
                    Result = false,
                    Message = ex.Message
                };
            }

            return response;
        }

        // Delete
        public virtual IOperationResponse<bool> Delete(Guid id)
        {
            IOperationResponse<bool> response;
            try
            {
                var item = table.Find(id);
                if (item != null)
                {
                    table.Remove(item);

                    int affectedRows = _context.SaveChanges();
                    if (affectedRows > 0)
                    {
                        response = new OperationResponse<bool>()
                        {
                            Status = ResponseStatus.Success,
                            Result = true,
                            Message = null
                        };
                    }
                    else
                    {
                        response = new OperationResponse<bool>()
                        {
                            Status = ResponseStatus.Fail,
                            Result = false,
                            Message = "Can't remove item from context"
                        };
                    }
                }
                else
                {
                    response = new OperationResponse<bool>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = false,
                        Message = "The item Can't be found"
                    };
                }
            }
            catch (Exception ex)
            {
                response = new OperationResponse<bool>()
                {
                    Status = ResponseStatus.Fail,
                    Result = false,
                    Message = ex.Message
                };
            }

            return response;
        }
        public virtual async Task<IOperationResponse<bool>> DeleteAsync(Guid id)
        {
            IOperationResponse<bool> response;
            try
            {
                var item = await table.FindAsync(id);
                if (item != null)
                {
                    table.Remove(item);

                    int affectedRows = await _context.SaveChangesAsync();
                    if (affectedRows > 0)
                    {
                        response = new OperationResponse<bool>()
                        {
                            Status = ResponseStatus.Success,
                            Result = true,
                            Message = null
                        };
                    }
                    else
                    {
                        response = new OperationResponse<bool>()
                        {
                            Status = ResponseStatus.Fail,
                            Result = false,
                            Message = "Can't remove item from context"
                        };
                    }
                }
                else
                {
                    response = new OperationResponse<bool>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = false,
                        Message = "The item Can't be found"
                    };
                }
            }
            catch (Exception ex)
            {
                response = new OperationResponse<bool>()
                {
                    Status = ResponseStatus.Fail,
                    Result = false,
                    Message = ex.Message
                };
            }

            return response;
        }

        // Save
        public int Save()
        {
            return _context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}