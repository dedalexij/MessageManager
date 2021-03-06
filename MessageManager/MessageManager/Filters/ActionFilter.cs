﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace MessageManager.Filters
{
  public class ActionFilter : ActionFilterAttribute, IExceptionFilter
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      if (!context.ModelState.IsValid)
      {
        context.Result = new BadRequestObjectResult(context.ModelState);
        Log.Warning(context.ActionDescriptor.DisplayName + "model is not valid");
      }

      Log.Information("Received Arguments {@Arguments}", context.ActionArguments);
      Log.Information("request " + context.HttpContext.Request.Form.Files);
      Log.Information("route data " + context.RouteData.Values);
      Log.Information("http context" + context.HttpContext);
      var ip = context.HttpContext.Request.Host.Host;

      Log.Information("Request: {@Values} ip: {@IPAdress} ",
        context.ActionDescriptor.AttributeRouteInfo.Template, ip);
      base.OnActionExecuting(context);
    }

    public void OnException(ExceptionContext filterContext)
    {
      if (!filterContext.ExceptionHandled)
      {
        var msg = filterContext.Exception.Message;

        Log.Error(msg);
      }
    }


  }
}