using GreatSchool.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GreatSchool.API
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
            //habilita o cors, para comunicação entre o front-end e o back-end
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    policy => {
                        policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials();
                    });
            });

            services.AddControllers();

            //adiciona o contexto do banco de dados no servico
            services.AddDbContext<GreatSchoolDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GreatSchoolDB")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //configura cors https://www.macoratti.net/20/08/ang9_crudapi1.htm
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
