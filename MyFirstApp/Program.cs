using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace MyFirstApp
{
    class Program
    {
        public static string DefaultConnectionString { get; } = @"Server=(localdb)\\mssqllocaldb;Database=SampleData-0B3B0919-C8B3-481C-9833-36C21776A565;Trusted_Connection=True;MultipleActiveResultSets=true";

        private static IReadOnlyDictionary<string, string> DefaultConfigurationStrings { get; } =
            new Dictionary<string, string>
            {
                ["Profile:UserName"] = Environment.UserName,
                ["AppConfiguration:ConnectionString"] = DefaultConnectionString,
                ["AppConfiguration:MainWindow:Width"] = "50",
                ["AppConfiguration:MainWindow:Height"] = "5",
                ["AppConfiguration:MainWindow:Top"] = "10",
                ["AppConfiguration:MainWindow:Left"] = "4"
            };
        public static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(DefaultConfigurationStrings);
            //configurationBuilder.AddJsonFile("appSettings.json", true, true);

            Configuration = configurationBuilder.Build();

            Console.SetWindowSize(Int32.Parse(Configuration["AppConfiguration:MainWindow:Width"]), 
                Int32.Parse(Configuration["AppConfiguration:MainWindow:Height"]));

            Console.WriteLine($"Hello {Configuration["Profile:UserName"]}");
            Console.WriteLine($"Top Setting is {Configuration["AppConfiguration:MainWindow:Top"]}");

            Console.ReadKey();
        }
    }
}
