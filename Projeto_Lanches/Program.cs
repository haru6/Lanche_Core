using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Projeto_Lanches.Data;
using Projeto_Lanches.Extensao;
using System;
namespace Projeto_Lanches
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                 .Build()
                 .CreateAAdminRole()
                 .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
