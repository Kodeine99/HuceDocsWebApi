using AspNet.Security.OAuth.Validation;
using FluentValidation.AspNetCore;
using HuceDocs.Data.DbContext;
using HuceDocs.Data.Models;
using HuceDocs.Notification.Client;
using HuceDocs.Notification.Email;
using HuceDocs.Security.Common;
using HuceDocs.Security.Extension;
using HuceDocs.Services;
using HuceDocs.Services.Services;
using HuceDocs.Services.Services.ChungTu;
using HuceDocs.Services.ViewModel;
using HuceDocsWebApi.Attributes;
using HuceDocsWebApi.JWT.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuceDocs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            configuration = builder.Build();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HuceDocsContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("HDTest"))
               );
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;

                //
            })
                .AddEntityFrameworkStores<HuceDocsContext>()
                .AddDefaultTokenProviders();

            services.AddCors();

            services.AddSingleton<IAuthorizationHandler, CustomAuthorizationHandle>();
            services.AddSingleton<IAuthorizationRequirement, CustomAuthoRequire>();
            //services.AddSingleton<IConfiguration>(Configuration);

            services.AddSingleton<IMessageHub, MessageHub>();
            //services.AddSingleton<IHubContext, Hub> ();


            services.AddTransient<SignInManager<User>, SignInManager<User>>();
            services.AddTransient<RoleManager<Role>, RoleManager<Role>>();
            services.AddTransient<IEmailProvider, EmailProvider>();
            services.AddTransient<INotifyService, NotifyService>();


            services.AddTransient<IUserService, UserService>();

            //services.AddTransient<IFileManagerService, FileManagerService>();
            services.AddTransient<IFileManagerIO, FileManagerIOFileSystem>();
            services.AddTransient<IHFileService, HFileService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IDanhMucService, DanhMucService>();
            services.AddTransient<IOCR_RequestService, OCR_RequestService>();
            services.AddTransient<IBangDiemTiengAnhService, BangDiemTiengAnhServices>();
            services.AddTransient<IGiayXacNhanToeicService, GiayXacNhanToeicServices>();
            services.AddTransient<IGiayCamKetTraNoService, GiayCamKetTraNoServices>();



            services.AddTransient<IEmailService, EmailService>();



            var userRoleTypes = Enum.GetValues(typeof(UserTypeEnum)).Cast<UserTypeEnum>().ToList();

            for (int i = 1; i <= userRoleTypes.Count(); i++)
            {
                foreach (var policyNames in userRoleTypes.Combinate(i))
                {
                    ///Administrator,Customer
                    var policyConcat = string.Join(",", policyNames);
                    var result = policyNames.GroupBy(c => c).Where(c => c.Count() > 1).Select(c => new { charName = c.Key, charCount = c.Count() });
                    if (result.Count() <= 0)
                    {
                        services.AddAuthorization(options =>
                        {
                            options.AddPolicy(policyConcat, policy => policy.Requirements.Add(new CustomAuthoRequire(policyConcat)));
                        });
                    }
                }
            }

            services.AddTransient<IAuthozirationUtility, AuthozirationUtility>();
            services.AddAuthentication(OAuthValidationDefaults.AuthenticationScheme).AddOAuthValidation();


            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterRequestValidator>());

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "HuceDocs Info Services API",
                    Version = "v1",
                    Description = "HuceDocs Infor Services API",
                });
            });   
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options =>
                options.WithOrigins(
                    "http://localhost:3000",
                    "http://localhost:3001"
                )
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger HDTest V1");
            //    c.DocumentTitle = "HDTest WEB API";
            //    c.RoutePrefix = string.Empty;
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapHub<MessageHub>("/messagehub");
            });
            app.UseSwagger();
            {
                app.UseSwaggerUI(
                    options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "HuceDocs Info Services"));
            }
        }
    }
}
