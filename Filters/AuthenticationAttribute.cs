using IdentityGama.Authentication;
using IdentityGama.Interface.Authentication;
using IdentityGama.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IdentityGama.Filters
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        private readonly IAuthenticationService _authorizationService = new AuthenticationService();

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string? authorizationHeader = context.HttpContext.Request.Headers["Authorization"];

            if (await _authorizationService.IsAuthenticatedAsync(authorizationHeader))
            {
                await next(); // Continue with the execution of the next filter or action
                return;
            }

            var result = new ObjectResult(new ApiError
            {
                Message = "Acesso negado, você não tem permissão pra efetuar essa ação",
                StatusCode = 401,
            })
            {
                StatusCode = 401
            };

            context.Result = result;
        }


    }
}
