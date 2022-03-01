using Microsoft.AspNetCore.Mvc;
using Sample.App.Api.Common;
using Sample.App.Api.Routes.V1;
using Sample.App.BLL.Services.Contract.V1;
using Sample.App.Domain.Contract.V1;
using Sample.App.Domain.Enums.V1;
using Sample.App.Domain.Models.V1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeSnippet.App.Api.Controllers.V1
{
    //[ApiController]
    public class SubStatusController : BaseController
    {
        private ISubStatusRepository subStatusRepository;
        public SubStatusController(ISubStatusRepository subStatusRepository)
        {
            this.subStatusRepository = subStatusRepository;
        }

        #region CRUD Operations
        [HttpGet(APIRoutes.SubStatus.GetAll)]
        public async Task<IOperationResponse<IEnumerable<SubStatus>>> GetSubStatuses()
        {
            return await subStatusRepository.GetAllWithStatusAsync();
        }

        [HttpGet(APIRoutes.SubStatus.GetStatusSubstatues)]
        public async Task<IOperationResponse<IEnumerable<SubStatus>>> GetSubStatuses([FromRoute] Guid statusId)
        {
            return await subStatusRepository.GetAllWithStatusAsync();
        }

        [HttpGet(APIRoutes.SubStatus.Get)]
        public async Task<IOperationResponse<SubStatus>> GetSubStatusById([FromRoute] Guid id)
        {
            return await subStatusRepository.GetByIdAsync(id);
        }

        [HttpPost(APIRoutes.SubStatus.Create)]
        public async Task<IOperationResponse<SubStatus>> AddSubStatus([FromBody] SubStatus subStatus)
        {
            subStatus = SetCreatingBaseValues(subStatus);

            return await subStatusRepository.InsertAsync(subStatus);
        }

        [HttpPut(APIRoutes.SubStatus.Update)]
        public async Task<IOperationResponse<bool>> UpdateSubStatus([FromRoute] Guid id, [FromBody] SubStatus subStatus)
        {
            try
            {
                if (id != subStatus.Id)
                {
                    return new OperationResponse<bool>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = false,
                        Message = "Bad Request: Id dosn't match"
                    };
                }

                if (!SubStatusExists(id))
                {
                    return new OperationResponse<bool>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = false,
                        Message = "Item not found!"
                    };
                }

                subStatus = SetUpdatingBaseValues(subStatus);

                return await subStatusRepository.UpdateAsync(subStatus);
            }
            catch (Exception ex)
            {
                return new OperationResponse<bool>()
                {
                    Status = ResponseStatus.Fail,
                    Result = false,
                    Message = ex.Message
                };
            }
        }

        [HttpDelete(APIRoutes.SubStatus.Delete)]
        public async Task<IOperationResponse<bool>> DeleteSubStatus([FromRoute] Guid id)
        {
            return await subStatusRepository.DeleteAsync(id);
        }
        #endregion

        #region Helpers 
        private bool SubStatusExists(Guid id)
        {
            return GetSubStatusById(id).Result != null;
        }

        private SubStatus SetCreatingBaseValues(SubStatus subStatus)
        {
            // set created on date and modified on date to now
            subStatus.CreatedOn = DateTime.Now;
            subStatus.ModifiedOn = DateTime.Now;

            if (subStatus.EnglishDescription == null)
            {
                subStatus.EnglishDescription = "";
            }
            if (subStatus.ArabicDescription == null)
            {
                subStatus.ArabicDescription = "";
            }

            return subStatus;
        }
        private SubStatus SetUpdatingBaseValues(SubStatus subStatus)
        {
            // set modified on date to now
            subStatus.ModifiedOn = DateTime.Now;
            return subStatus;
        }
        #endregion
    }
}