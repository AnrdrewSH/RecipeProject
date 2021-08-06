using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Recipe_Api.Data;
using Recipe_Api.Data.Interfaces;
using Recipe_Api.Data.Repository;
using Recipe_Api.Dblnfrastructure;

namespace Recipe_Api
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
            services.AddScoped<IStepRepository, StepRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IIngredientItemRepository, IngredientItemRepository>();
            const string connectionString = @"Data Source=LAPTOP-0NI53OGU\SQLEXPRESS;Initial Catalog=MySecondDB;Pooling=true;Integrated Security=SSPI";
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork>(sp => sp.GetService<AppDbContext>());

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "CulinaryRecipes/dist";
            });

            //services.AddTransient<IRecipeOutputData, RecipeRepository>();
            //services.AddTransient<ITag, TagRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "CulinaryRecipes";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}