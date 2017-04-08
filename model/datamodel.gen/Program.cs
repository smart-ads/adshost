using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace datamodel.gen
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add base services for scaffolding
            var serviceCollection = new ServiceCollection()
                .AddScaffolding()
                .AddLogging();

            // Add database provider services
            var provider = new SqlServerDesignTimeServices();
            provider.ConfigureDesignTimeServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var generator = serviceProvider.GetService<ReverseEngineeringGenerator>();
            var options = new ReverseEngineeringConfiguration
            {
                ConnectionString = @"data source=LENOVO-PC;initial catalog=adsdb;persist security info=True;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;App=adshost",
                ProjectPath = @"..\datamodel.core\Data",
                ProjectRootNamespace = "Data",
                
            };

            generator.GenerateAsync(options).Wait();
        }
    }
}