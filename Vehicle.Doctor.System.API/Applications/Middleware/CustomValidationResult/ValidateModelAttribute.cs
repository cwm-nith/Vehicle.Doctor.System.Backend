using Microsoft.AspNetCore.Mvc.Filters;

namespace Vehicle.Doctor.System.API.Applications.Middleware.CustomValidationResult;

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new ValidationFailedResult(context.ModelState);
        }
    }
}