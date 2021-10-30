
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Api.Data;
using TodoList.Api.Extentions;

namespace TodoList.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDbContext<TodoListDbContext>((context, services) =>
            {
                var logger = services.GetService<ILogger<TodoListDbContextSeed>>();
                new TodoListDbContextSeed().SeedAsync(context, logger);
            });
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
