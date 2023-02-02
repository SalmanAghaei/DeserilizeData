using Data;
using MediatR;
using Toolkit;
using OvetimePolicies;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api;

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

        services.AddCalculators();
        services.AddControllers();
        services.AddSerializers();
        services.AddRepositories();
        services.AddDbContext(Configuration);
        services.AddHttpContextAccessor();
        AddMediatR(services);
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Entekhab Task", Version = "v1" });
        });
    }


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
        }

        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }


    private static void AddMediatR(IServiceCollection services)
    {
        var mediatRAssemblies = new Assembly[]
            {
            Assembly.Load("Application"),
            Assembly.Load("Contract"),
             };
        services.AddMediatR(mediatRAssemblies);
    }
}
