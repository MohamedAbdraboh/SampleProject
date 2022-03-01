using Sample.App.BLL.Services.Contract.V1;
using Sample.App.DAL;
using Sample.App.Domain.Contract.V1;
using Sample.App.Domain.Enums.V1;
using Sample.App.Domain.Models.V1;
using Microsoft.EntityFrameworkCore;

namespace Sample.App.BLL.Services.Entities.V1
{
    public class SubStatusRepository : Repository<SubStatus>, ISubStatusRepository
    {
        private ApplicationDbContext _context = null;
        public SubStatusRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }


        public async Task<IOperationResponse<IEnumerable<SubStatus>>> GetAllWithStatusAsync()
        {
            IOperationResponse<IEnumerable<SubStatus>> response = new OperationResponse<IEnumerable<SubStatus>>()
            {
                Status = ResponseStatus.Success,
                Result = await _context.SubStatuses.Include("Status").ToListAsync(),
                Message = null
            };

            return response;
        }

        // Insert
        public IOperationResponse<SubStatus> InsertWithIncludes(SubStatus subStatus)
        {
            IOperationResponse<SubStatus> response;
            try
            {
                if (subStatus.Status != null)
                {
                    _context.Entry(subStatus.Status).State = EntityState.Unchanged;
                }

                var result = this._context.SubStatuses.Add(subStatus);
                int affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    response = new OperationResponse<SubStatus>()
                    {
                        Status = ResponseStatus.Success,
                        Result = result.Entity,
                        Message = null
                    };
                }
                else
                {
                    response = new OperationResponse<SubStatus>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = null,
                        Message = "Can't add item at context"
                    };
                }
            }
            catch (Exception ex)
            {
                response = new OperationResponse<SubStatus>()
                {
                    Status = ResponseStatus.Fail,
                    Result = null,
                    Message = ex.Message
                };
            }
            return response;
        }


        public string MiniMaxSum(int[] arr)
        {
            string res = "";

            int max = 0, min = 0;
            int sumMax = 0, sumMin = 0;
            min = arr[0];
            max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                }

                if (max<arr[i])
                {
                    max = arr[i];
                }
            }

            foreach (var item in arr)
            {
                if (item != max)
                {
                    sumMin += item;
                }

                if (item != min)
                {
                    sumMax += item;
                }
            }

            return "the min sumation of 4 = " + sumMin + ", and the max sumation of 4 = " + sumMax;
        }
        public async Task<IOperationResponse<SubStatus>> InsertAsync(SubStatus subStatus)
        {
            IOperationResponse<SubStatus> response;
            try
            {
                if (subStatus.Status != null)
                {
                    _context.Entry(subStatus.Status).State = EntityState.Unchanged ;
                }

                var result = await this._context.SubStatuses.AddAsync(subStatus);
                int affectedRows = await SaveAsync();

                if (affectedRows > 0)
                {
                    response = new OperationResponse<SubStatus>()
                    {
                        Status = ResponseStatus.Success,
                        Result = result.Entity,
                        Message = null
                    };
                }
                else
                {
                    response = new OperationResponse<SubStatus>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = null,
                        Message = "Can't add item to context"
                    };
                }
            }
            catch (Exception ex)
            {
                response = new OperationResponse<SubStatus>()
                {
                    Status = ResponseStatus.Fail,
                    Result = null,
                    Message = ex.Message
                };
            }
            return response;
        }

    }
}
