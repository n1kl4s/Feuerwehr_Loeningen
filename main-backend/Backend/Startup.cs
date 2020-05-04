using Backend.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                                     .AddJsonOptions(o => {
                                         o.JsonSerializerOptions.WriteIndented = true;
                                     });
            services.AddDbContext<FireContext>(optionsBuilder => optionsBuilder.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Feuerwehr Löningen API", Version = "v1.0.0" });
            });


            //// configure jwt authentication
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateAudience = true,
            //        ValidAudience = Configuration["Jwt:Issuer"],
            //        ValidateIssuer = true,
            //        ValidIssuer = Configuration["Jwt:Issuer"],
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.Zero //the default for this setting is 5 minutes
            //    };
            //    x.Events = new JwtBearerEvents
            //    {
            //        OnAuthenticationFailed = context =>
            //        {
            //            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //            context.Response.ContentType = "application/json";
            //            var err = Env.IsDevelopment() ? context.Exception.ToString() : "An error occurred processing your authentication.";
            //            var result = JsonConvert.SerializeObject(new { err });
            //            return context.Response.WriteAsync(result);
            //        }
            //    };
            //});

        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Shows UseCors with CorsPolicyBuilder.
                app.UseCors(builder =>
                {
                    builder.WithOrigins("*");
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseExceptionHandler("/api/Error");

                // Shows UseCors with CorsPolicyBuilder.
                app.UseCors(builder =>
                {
                    builder.WithOrigins("https://*.feuerwehr-loeningen.de",
                                        "https://feuerwehr-loeningen.de")
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .WithMethods("GET", "POST", "PUT", "DELETE");
                });
            }

            logger.LogInformation("App:\t" + env.ApplicationName);
            logger.LogInformation("Umgebung:\t" + env.EnvironmentName);
            logger.LogInformation("CRP:\t" + env.ContentRootPath);
            logger.LogInformation("WRP:\t " + env.WebRootPath);

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Feuerwehr API");
                c.RoutePrefix = "api";
            });



            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
