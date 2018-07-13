using System;
using System.Text;
using MessageManager.Filters;
using MessageManager.Security;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
      services.AddMvc(options =>
      {
        options.Filters.Add(new ActionFilter());
        options.Filters.Add(new ExceptionFilter());
      });

      var securityConfiguration = Configuration.GetSection("Security");
      var userRepository = new UserRepository();
      var userService = new UserService(userRepository);
      var smsRepository = new SMSRepository();
      var emailRepository = new EmailRepository();
      var messageService = new MessageService(emailRepository, smsRepository);

      services.AddSingleton<IUserService>(userService);
      services.AddSingleton<IMessageService>(messageService);
      services.AddSingleton<ExceptionFilter>(new ExceptionFilter());
      services.AddSingleton<ActionFilter>(new ActionFilter());

      var securitySettings = new SecuritySettings(securityConfiguration["EncryptionKey"],
        securityConfiguration["Issue"],
        securityConfiguration.GetValue<TimeSpan>("ExpirationPeriod"));

      var jwtIssuer = new JwtIssuer(securitySettings);

      services.AddSingleton<IJwtIssuer>(jwtIssuer);

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(securitySettings.EncryptionKey))
          };
        });
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
