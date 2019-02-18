using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

namespace FileService
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        private readonly AppSettings appSettings;

        public Startup(IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            Configuration = configuration;
             this.appSettings = appSettings.Value;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials(); }));
            services.AddSingleton<IFileProvider>( new PhysicalFileProvider(Configuration.GetSection("DirectoryPath").Value));
                services.AddMvc();
        var tet = Configuration.GetSection("DirectoryPath").ToString();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");

            app.UseMvc();
        }
    }
}
