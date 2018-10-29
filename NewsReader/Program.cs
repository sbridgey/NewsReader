using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsReader.Data;
using NewsReader.Repositories;
using NewsReader.Repositories.Models;

namespace NewsReader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serviceProvider = new ServiceCollection()
            .AddLogging()
                .AddSingleton<INewsRepository, NewsTodayRepository>()
                .AddSingleton<INewsRepository, TechMediaRepository>()
                .AddSingleton<IDataRepository, DataRepository>()
                .AddDbContext<DataContext>(_ => _.UseInMemoryDatabase("TechTest"))
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            var newsDataRepositories = serviceProvider.GetServices<INewsRepository>();

            var bag = new ConcurrentBag<NewsData>();
            var tasks = newsDataRepositories.Select(async item =>
            {
                var response = await item.Get();
                foreach (var story in response)
                {
                    bag.Add(story);
                }
            });

            await Task.WhenAll(tasks);

            var dataRepository = serviceProvider.GetService<IDataRepository>();

            dataRepository.StoreData(bag.ToList());
        }
    }
}
