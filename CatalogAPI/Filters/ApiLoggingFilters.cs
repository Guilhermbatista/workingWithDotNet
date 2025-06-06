﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace CatalogAPI.Filters
{
    public class ApiLoggingFilters : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilters> _logger;

        public ApiLoggingFilters(ILogger<ApiLoggingFilters> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("### Executando -> OnActionExecuted");
            _logger.LogInformation("########################################################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"Status Code : {context.HttpContext.Response.StatusCode}");
            _logger.LogInformation("########################################################################");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("### Executando -> OnActionExecuting");
            _logger.LogInformation("########################################################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"ModelState : {context.ModelState.IsValid}");
            _logger.LogInformation("########################################################################");



        }
    }
}
