using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoverManagement.Entity.Exceptions;
using RoverManagement.Interfaces;
using System;

namespace RoverManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using var host = CreateHostBuilder(args).Build();
            
            RoverApllication(host.Services);

            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<IRover, Rover>()
                            .AddTransient<IPlateau, Plateau>());
        }

        public static void RoverApllication(IServiceProvider services)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var plateau = provider.GetRequiredService<IPlateau>();


            while (!plateau.IsValid())
            {
                Console.WriteLine("Enter Plateau Max Limits");
                var plateauGridSizeInput = Console.ReadLine();
                plateau.Initialize(plateauGridSizeInput);
            }

            var addNewRover = true;

            while (addNewRover)
            {
                Console.WriteLine("Enter Initial Position For Rover:");
                var roverPositionInput = Console.ReadLine();
                Console.WriteLine("Enter Movement Command:");
                var roverCommandInput = Console.ReadLine();

                var rover = provider.GetService<IRover>();
                if (rover.Initialize(roverPositionInput))
                {
                    rover.Commands = roverCommandInput;
                    plateau.Rovers.Add(rover);
                }

                Console.WriteLine("Do you want to add another rover ? (Y)");
                var addAnotherRoverInput = Console.ReadLine();
                if (addAnotherRoverInput.ToUpper() != "Y")
                {
                    addNewRover = false;
                }
            }

            Console.WriteLine("Expected Output :");

            foreach (var rover in plateau.Rovers)
            {
                var limitPoint = plateau.GetPlateauCoordinates();
                try
                {
                    rover.ProcessCommand(limitPoint.X, limitPoint.Y);

                }
                catch (OutOfLimitException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    throw;
                }
                Console.WriteLine(rover.GetRoverInfo());
            }
        }
    }
}
