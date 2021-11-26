using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SetupApi.Models;
using System.Linq;

namespace SetupApi.Filters
{
    public class ValidateModelStateCustom : ActionFilterAttribute    
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           if (!context.ModelState.IsValid)
            {
                var validateViewModelOutput = new ValidateViewModelOutput(context.ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage));
                context.Result = new BadRequestObjectResult(validateViewModelOutput);
            }
        }
    }
}
