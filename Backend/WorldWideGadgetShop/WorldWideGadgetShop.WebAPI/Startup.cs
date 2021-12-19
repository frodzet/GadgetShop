
using System;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WorldWideGadgetShop.Core.IServices;
using WorldWideGadgetShop.Core.Models;
using WorldWideGadgetShop.Domain.IRepositories;
using WorldWideGadgetShop.Domain.Services;
using WorldWideGadgetShop.SQL;
using WorldWideGadgetShop.SQL.Repositories;
using DBContext = WorldWideGadgetShop.SQL.DBContext;

namespace WorldWideGadgetShop.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            // Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApplication", Version = "v1"});
            });
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
            
            services.AddSingleton<IAuthenticationService>(new AuthenticationService(secretBytes));
            services.AddCors();
            services.AddDbContext<DBContext>(opt =>
            {
                opt
                    .UseSqlite("Data Source=ProductDatabase.db");
            }, ServiceLifetime.Transient);
            services.AddControllers()
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var ctx = scope.ServiceProvider.GetService<DBContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                var dbInitializer = services.GetService<IDatabaseInitializer>();
                dbInitializer.SeedDatabase(ctx);
            }
        }
    }
}