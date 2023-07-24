using IdentityGama.Authorization;
using IdentityGama.Interface.Authorization;
using IdentityGama.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace IdentityGama.Filters
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public string? Role { get; set; }
        private readonly IAuthorizationService _authorizationService = new AuthorizationService();

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string? authorizationHeader = context.HttpContext.Request.Headers["Authorization"];

            if (await _authorizationService.IsAuthorizedAsync(authorizationHeader, Role))
            {
                await next(); // Continue with the execution of the next filter or action
                return;
            }

            var result = new ObjectResult(new ApiError
            {
                Message = "Acesso negado, você não tem permissão pra efetuar essa ação",
                StatusCode = 403,
            })
            {
                StatusCode = 403
            };

            context.Result = result;
        }


    }
}
