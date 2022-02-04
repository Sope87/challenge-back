using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DataAccessLayer.Repository.Interfaces;
using DataAccessLayer.Repository;
using BusinessLogicLayer.Service.Interfaces;
using BusinessLogicLayer.Service;
using FluentValidation.AspNetCore;
using AntChallenge.Validations;
using System.Reflection;

namespace AntChallenge
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AntChallenge", Version = "v1" });
            });
            //services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDbContext<SystemAntorcha_DBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AntorchaDB")));

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddTransient<IRepository<Professor>, ProfessorRepository>();
            services.AddTransient<IRepository<Student>, StudentRepository>();

            services.AddTransient<IGenericService<Professor>, ProfessorService>();
            services.AddTransient<IGenericService<Student>, StudentService>();

            services.AddControllers()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProfessorViewModelValidator>());
            services.AddControllers()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StudentViewModelValidator>());


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AntChallenge v1"));
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
