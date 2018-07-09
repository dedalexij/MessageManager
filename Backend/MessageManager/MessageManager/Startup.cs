using MessageManagerLib.Application;
using MessageManagerLib.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using MessageManagerLib.Infrastructure;

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

      services.AddSingleton<IUserService>(userService);

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
             .WriteTo.RollingFile("log-{Date}.log")
             .CreateLogger();
      Log.Information("Logging started");
    }
  }
}
