using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using MessageService.Data;

namespace MessageService
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
            services.AddScoped<IGetSentServiceRepo, SqlGetSentServiceRepo>();
            services.AddScoped<ISendServiceRepo, SqlSendServiceRepo>();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SMSContext>(options => options.UseSqlServer(connection));

            services.AddMvc().AddMvcOptions(opts =>
            {
                opts.FormatterMappings.SetMediaTypeMappingForFormat("xml", new MediaTypeHeaderValue("application/xml"));
            });

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddXmlSerializerFormatters();

            services.AddSwaggerGen(c =>
            c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "My API", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            }
            );

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers()
            );
        }
    }
}
