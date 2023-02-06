using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.DTO.DTOs;

namespace NTierArchitecture.API.Filter
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : class, new()
    {
        private readonly IBaseService<T> _baseService;

        public NotFoundFilter(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;

            var anyEntity = await _baseService.GetByIdAsync(id);

            if (anyEntity != null)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(CustomResponseDto<string>.Fail(404,$"{typeof(T).Name} not found"));
        }
    }
}
