using GreatSchool.Application;
using GreatSchool.Application.Interfaces.Aluno;
using GreatSchool.Application.Services;
using GreatSchool.Domain.Entities;
using GreatSchool.Domain.Interfaces;
using GreatSchool.Infrastructure.Data;
using GreatSchool.Infrastructure.Repositories;
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

            //adiciona o contexto do banco de dados no servico
            services.AddDbContext<GreatSchoolDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GreatSchoolDB")));

            //adiciona automapper
            services.AddAutoMapper(cfg => { }, typeof(MappingProfile));

            //adiciona repositorios
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IRepository<Aluno>, Repository<Aluno>>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //adiciona services
            services.AddScoped<IAlunoService, AlunoService>();

            //adiciona controllers
            services.AddControllers();
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
