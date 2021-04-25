using ISISNotesBackend.Core;
using ISISNotesBackend.Core.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ISISNotesBackend.DataBase.NpgsqlContext;
using ISISNotesBackend.DataBase.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ISISNotesBackend.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ISISNotesContext>(options => 
                options.UseNpgsql(connection));
            
            services.AddSingleton<INoteRepository, NoteRepository>();
            services.AddSingleton<IRightsRepository, RightsRepository>();
            services.AddSingleton<IFacade, Facade>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("ISIS NOTES");
                });
            });
        }
    }
}
