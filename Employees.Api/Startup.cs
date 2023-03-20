using Employees.BusinessLogic;
using Employees.Core.Repositories;
using Employees.Core.Services;
using Employees.DataAccess.MSSQL;
using Employees.DataAccess.MSSQL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {

                    options.RequireHttpsMetadata = false;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["Authentification:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = Configuration["Authentification:Audience"],
                        ValidateLifetime = true,
                        IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8
                            .GetBytes(Configuration["Authentification:Key"])),
                        ValidateIssuerSigningKey = true
                    };
                });

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ApiMappingProfile>();
                cfg.AddProfile<DataAccessMappingProfile>();
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {         
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employees.Api", Version = "v1" });
                
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Enter 'Bearer' [space] and your token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

            });
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();
           
            services.AddScoped<IPositionInCompanyRepository, PositionInCompanyRepository>();
            services.AddScoped<IPositionInCompanyService, PositionInCompanyService>();
            
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddDbContext<EmployeesContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MSSQLConnectionString"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employees.Api v1"));
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<EmployeesContext>();
                context.Database.Migrate();
                if (!context.Employees.Any())
                {
                    DataGenerator dataGenerator = new DataGenerator(context);
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();
           
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
