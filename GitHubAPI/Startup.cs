using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHubData.Repository;
using GitHubDomain;
using GitHubService;
using GitHubService.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GitHubAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IFollowerService>(s => new FollowerService(new FollowerRepository(new GitHubConfig()
            {
                AccessToken = this.Configuration.GetSection("GitHubApi:access_token").Value,
                BaseURL = this.Configuration.GetSection("GitHubApi:Base_API_URL").Value,
                ClientSecret = this.Configuration.GetSection("GitHubApi:client_secret").Value,
                ClientId = this.Configuration.GetSection("GitHubApi:client_id").Value
            })));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
