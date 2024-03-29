using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading.Tasks;
using Translator.API.Controllers;
using Translator.API.JwtFeatures;
using Translator.Domain.Models;
using Translator.Domain.Models.SkillTests;
using Translator.Domain.SkillTests;
using Translator.EntityFramework;
using Translator.EntityFramework.Services;

namespace Translator.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<TranslatorDbContext>(opts =>opts.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Database=TranslatorDB;Trusted_Connection=True;"));
            services.AddMvc(options =>
            {
                options.InputFormatters.Insert(0, new RawJsonBodyInputFormatter());
            });

            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 7;
                opt.Password.RequireDigit = false;
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<TranslatorDbContext>();

            var jwtSettings = Configuration.GetSection("JwtSettings");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
                };
            });
            
            var dbContextFactory = new TranslatorDbContextFactory();
            var dbServiceFactory = new DbServiceFactory(dbContextFactory);

            var wordService = dbServiceFactory.Create<Word>();
            var collocationService = dbServiceFactory.Create<Collocation>();
            var sentenceService = dbServiceFactory.Create<Sentence>();
            var logMessageService = dbServiceFactory.Create<LogMessage>();
            var testTreeService = dbServiceFactory.Create<TestTree>();
            
            services.Add(new ServiceDescriptor(typeof(IDbGenericService<Word>), wordService));
            services.Add(new ServiceDescriptor(typeof(IDbGenericService<Collocation>), collocationService));
            services.Add(new ServiceDescriptor(typeof(IDbGenericService<Sentence>), sentenceService));
            services.Add(new ServiceDescriptor(typeof(IDbGenericService<LogMessage>), logMessageService));
            services.Add(new ServiceDescriptor(typeof(IDbGenericService<TestTree>), testTreeService));

            services.AddScoped<JwtHandler>();
            services.AddControllers();

            PopulateTree(testTreeService);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void PopulateTree(IDbGenericService<TestTree> testTreeService)
        {
            var test11 = new SingleChoiseQuestion(2, "Question 1 bla bla bla bla bla?",
                new List<string>() { "sdf", "sdfadsfasfsd", "right answer" }, 2, 0);
            var test12 = new SingleChoiseQuestion(2, "Question 2 bla bla?",
                new List<string>() { "sdasdfasdff", "sdfsd", "right answer" }, 2, 0);
            var test3 = new TextAnswerQuestion(2, "Question 3 bla bla bla bla?", "1234", "");
            var test4 = new TextAnswerQuestion(2, "Question 4 bla bla bla bla blaasdfasd?", "1234", "");
            var test1 = new GroupTestNode(new List<TestNode>() { test11, test12 });
            var testTreeRoot = new GroupTestNode(new List<TestNode>( ) { test1, test3, test4 });
            string json = JsonConvert.SerializeObject(testTreeRoot, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });
            testTreeService.Create(new TestTree(json));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
