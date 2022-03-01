using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
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
    public class TagsController : BaseController
    {
        private ITagRepository tagRepository;
        public TagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        #region CRUD Operations
        [HttpGet(APIRoutes.Tag.GetAll)]
        [EnableQuery]
        public async Task<IOperationResponse<IEnumerable<Tag>>> GetTags()
        {
            return await tagRepository.GetAllAsync();
        }

        [HttpGet(APIRoutes.Tag.Get)]
        public async Task<IOperationResponse<Tag>> GetTagById([FromRoute] Guid id)
        {
            return await tagRepository.GetByIdAsync(id);
        }

        [HttpPost(APIRoutes.Tag.Create)]
        public async Task<IOperationResponse<Tag>> AddTag([FromBody]Tag tag)
        {
            tag = SetCreatingBaseValues(tag);

            return await tagRepository.InsertAsync(tag);
        }

        [HttpPut(APIRoutes.Tag.Update)]
        public async Task<IOperationResponse<bool>> UpdateTag([FromRoute] Guid tagId, [FromBody] Tag tag)
        {
            try
            {
                if (tagId != tag.Id)
                {
                    return new OperationResponse<bool>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = false,
                        Message = "Bad Request: Id dosn't match"
                    };
                }

                if (!TagExists(tagId))
                {
                    return new OperationResponse<bool>()
                    {
                        Status = ResponseStatus.Fail,
                        Result = false,
                        Message = "Item not found!"
                    };
                }

                tag = SetUpdatingBaseValues(tag);

                return await tagRepository.UpdateAsync(tag);
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

        [HttpDelete(APIRoutes.Tag.Delete)]
        public async Task<IOperationResponse<bool>> DeleteTag([FromRoute] Guid tagId)
        {
            return await tagRepository.DeleteAsync(tagId);
        }
        #endregion

        #region Helpers 
        private bool TagExists(Guid id)
        {
            return GetTagById(id).Result != null;
        }
        private Tag SetCreatingBaseValues(Tag tag)
        {
            // set created on date and modified on date to now
            tag.CreatedOn = DateTime.Now;
            tag.ModifiedOn = DateTime.Now;

            // set user to admin
            // missssssssssssssssssssssssssssing

            return tag;
        }
        private Tag SetUpdatingBaseValues(Tag tag)
        {
            // set modified on date to now
            tag.ModifiedOn = DateTime.Now;
            
            return tag;
        }
        #endregion
    }
}