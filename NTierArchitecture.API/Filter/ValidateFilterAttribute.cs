using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NTierArchitecture.DTO.DTOs;

namespace NTierArchitecture.API.Filter
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(i => i.Errors).Select(i => i.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(CustomResponseDto<List<string>>.Fail(400, errors));
            }
        }
    }
}
