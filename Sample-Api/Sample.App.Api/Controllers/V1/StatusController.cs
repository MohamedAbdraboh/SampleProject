using Sample.App.Api.Common;
using Sample.App.Api.Routes.V1;
using Sample.App.BLL.Services.Contract.V1;
using Sample.App.Domain.Contract.V1;
using Sample.App.Domain.Enums.V1;
using Sample.App.Domain.Models.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.App.Api.Controllers.V1
{
    public class StatusController : BaseController
    {
        private IStatusRepository statusRepository;
        public StatusController(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }

        #region CRUD Operations
        [HttpGet(APIRoutes.Status.GetAll)]
        [EnableQuery]
        public async Task<IOperationResponse<IEnumerable<Status>>> GetStatuses()
        {
            return await statusRepository.GetAllAsync();
        }

        [HttpGet(APIRoutes.Status.Get)]
        public async Task<IOperationResponse<Status>> GetStatusById([FromRoute] Guid id)
        {
            return await statusRepository.GetByIdAsync(id);
        }

        [HttpPost(APIRoutes.Status.Create)]
        public async Task<IOperationResponse<Status>> AddStatus([FromBody] Status status)
        {
            status = SetCreatingBaseValues(status);

            return await statusRepository.InsertAsync(status);
        }

        [HttpPut(APIRoutes.Status.Update)]
        public async Task<IOperationResponse<bool>> UpdateStatus([FromRoute] Guid id, [FromBody] Status status)
        {
            try
            {
                if (id != status.Id)
                {
                    return new OperationResponse<bool>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = false,
                        Message = "Bad Request: Id dosn't match"
                    };
                }

                if (!StatusExists(id))
                {
                    return new OperationResponse<bool>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = false,
                        Message = "Item not found!"
                    };
                }

                status = SetUpdatingBaseValues(status);

                return await statusRepository.UpdateAsync(status);
            }
            catch(Exception ex)
            {
                return new OperationResponse<bool>()
                {
                    Status = ResponseStatus.Fail,
                    Result = false,
                    Message = ex.Message
                };
            }
        }

        [HttpDelete(APIRoutes.Status.Delete)]
        public async Task<IOperationResponse<bool>> DeleteStatus([FromRoute] Guid id)
        {
            return await statusRepository.DeleteAsync(id);
        }
        #endregion

        #region Helpers 
        private bool StatusExists(Guid id)
        {
            return GetStatusById(id).Result != null;
        }

        private Status SetCreatingBaseValues(Status status)
        {
            // set created on date and modified on date to now
            status.CreatedOn = DateTime.Now;
            status.ModifiedOn = DateTime.Now;
            if (status.EnglishDescription == null)
            {
                status.EnglishDescription = "";
            }
            if (status.ArabicDescription == null)
            {
                status.ArabicDescription = "";
            }

            return status;
        }
        private Status SetUpdatingBaseValues(Status status)
        {
            // set modified on date to now
            status.ModifiedOn = DateTime.Now;
            return status;
        }
        #endregion
    }
}