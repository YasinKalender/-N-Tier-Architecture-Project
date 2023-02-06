using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NTierArchitecture.Business.Interfaces;

namespace NTierArchitecture.Web.Filters
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
            var errorNewModel = new NTierArchitecture.DTO.DTOs.ErrorViewModels.ErrorViewModel();
            errorNewModel.Error.Add($"{typeof(T).Name}(id) not found");

            context.Result = new RedirectToActionResult("Error", "Home", errorNewModel);
        }
    }
}
