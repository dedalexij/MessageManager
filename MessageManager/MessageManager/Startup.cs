using MessageManager.Filters;
using MessageManagerLib.Application;
using MessageManagerLib.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using MessageManagerLib.Infrastructure;
using MessageManagerLib.Domain.Exceptions;

namespace MessageManager
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      ConfigureLogging();
      services.AddMvc();

      var userRepository = new UserRepository();
      var userService = new UserService(userRepository);
      var smsRepository = new SMSRepository();
      var emailRepository = new EmailRepository();
      var messageService = new MessageService(emailRepository, smsRepository);

      services.AddSingleton<IUserService>(userService);
      services.AddSingleton<IMessageService>(messageService);
      services.AddSingleton<ExceptionFilter>(new ExceptionFilter());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();
    }

    public void ConfigureLogging()
    {
      Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Information()
             .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
             .Enrich.FromLogContext()
             .CreateLogger();
      Log.Information("Logging started");
    }
  }
}
