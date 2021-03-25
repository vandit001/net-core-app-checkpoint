using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace HelloWorld
{
    class Program
    {
        static public string DefaultConnectionString { get; } = @"Server=(localdb)\\mssqllocaldb;Database=SampleData-0B3B0919-C8B3-481C-9833-36C21776A565;Trusted_Connection=True;MultipleActiveResultSets=true";
        static IReadOnlyDictionary<string, string> DefaultConfigurationStrings { get; } = new Dictionary<string, string>()
        {
            ["Profile:UserName"] = Environment.UserName,
            [$"AppConfiguration:ConnectionString"] = DefaultConnectionString,
            [$"AppConfiguration:AltWindow:Width"] ="10",
            [$"AppConfiguration:AltWindow:Height"] = "20",
        };
        static public IConfiguration Configuration { get; set; }
        static void Main(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.AddInMemoryCollection(DefaultConfigurationStrings);
            configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = configurationBuilder.Build();

            Console.SetWindowSize(Int32.Parse(Configuration["AppConfiguration:AltWindow:Width"]), (Int32.Parse(Configuration["AppConfiguration:AltWindow:Height"])));
            Console.WriteLine($"Hello {Configuration["Profile:UserName"]}");

            Console.WriteLine($"{Configuration["message"]}");
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}
