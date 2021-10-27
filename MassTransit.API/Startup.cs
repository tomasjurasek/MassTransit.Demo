using MassTransit.API.CommandConsumers;
using MassTransit.API.CommandHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MassTransit.API
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

            services.AddControllers();
  
            services.AddMassTransit(x =>
            {
                x.AddConsumer<CommandConsumer>();
                #region memory
                //x.UsingInMemory((context, cfg) => {
                //    cfg.ReceiveEndpoint(nameof(CommandConsumer), cfg =>
                //    {
                //        cfg.ConcurrencyLimit = 1;
                //        cfg.ConfigureConsumer<CommandConsumer>(context);
                //    });
                //});
                #endregion
                #region rabbit
                //x.UsingRabbitMq((context, cfg) =>
                //{
                //    cfg.ReceiveEndpoint(nameof(CommandConsumer), cfg =>
                //    {
                //        cfg.PrefetchCount = 1;
                //        cfg.ConfigureConsumer<CommandConsumer>(context);
                //    });
                //});
                #endregion
            });

            services.AddMassTransitHostedService();

            #region mediator
            services.AddMediator(x =>
            {
                x.AddConsumer<CreateCommandHandler>();
                x.AddConsumer<UpdateCommandHandler>();
            });
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MassTransit.API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MassTransit.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
