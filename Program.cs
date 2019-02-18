﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FileService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).CaptureStartupErrors(true).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)/* .UseKestrel().UseIISIntegration()*/
                .UseStartup<Startup>();
    }
}
