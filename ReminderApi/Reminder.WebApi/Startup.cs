using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reminder.Data.Core;
using Reminder.Data.EF;
using Reminder.Data.Models;
using Reminder.Data.Repositories;
using Reminder.Helpers;

namespace Reminder.WebApi
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

            string connectionString;
#if DEBUG
            connectionString = Configuration.GetConnectionString(ConstantsHelper.DefaultConnection);
#else
            connectionString = Configuration.GetConnectionString(ConstantsHelper.ReleaseVersionConnection);
#endif
            var options = new DbContextOptionsBuilder().UseSqlServer(connectionString);
            services.AddTransient(s => new AppIdentityDbContext(options.Options, ConstantsHelper.ContextSchemaName));
            services.AddTransient<IRepository<Note>, Repository<AppIdentityDbContext, Note>>();
            services.AddCors();

            services.AddIdentity<UserModel, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                })
                .AddGoogle(opt =>
                {
                    opt.ClientId = "316039972239-btpdsa4bhfuofcr4iqd8l1au06cpoerd.apps.googleusercontent.com";
                    opt.ClientSecret = "9e3ikQOA1KwIt7wc2PgGyVcm";
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
