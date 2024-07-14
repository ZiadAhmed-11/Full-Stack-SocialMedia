using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace SocialMediaApi.Filters.ActionFilters
{
    public class UserPostsListActionFilter : IActionFilter
    {
        private readonly ILogger<UserPostsListActionFilter> _logger;

        public UserPostsListActionFilter(ILogger<UserPostsListActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Logic after action execution
            _logger.LogInformation("{FilterName}.{MethodName} method executed", nameof(UserPostsListActionFilter), nameof(OnActionExecuted));
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Logic before action execution
            _logger.LogInformation("UserPostsListActionFilter.OnActionExecuting method executing");
        }
    }
}
