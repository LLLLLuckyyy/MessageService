using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AutoMapper;
using MessageService.Resources.Api.Models;
using MessageService.Send.Api.Repository;
using MessageService.Send.Api.Mapping;
using MessageService.Common.SwaggerFilters;

namespace MessageService.Send.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISendRepo, SqlSendRepo>();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MessageContext>(options => options.UseSqlServer(connection));

            services.AddControllers();

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile<MappingProfile>());
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.DocumentFilter<SwaggerFilterForSendingMessage>();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers()
            );
        }
    }
}
