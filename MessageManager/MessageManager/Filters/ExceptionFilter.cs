using MessageManagerLib.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;


namespace MessageManager.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                var msg = context.Exception.Message;
                Log.Error(msg);
            }

            switch (context.Exception)
            {
                case UserAlreadyExistsException exception:
                    context.Result = new BadRequestResult();
                    break;
            }
        }
    }
}