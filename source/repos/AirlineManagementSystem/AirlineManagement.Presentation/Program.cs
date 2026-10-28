using AirlineManagement.Application.Mappings;
using AirlineManagement.Application.Services;
using AirlineManagement.ConsoleApp;
using AirlineManagement.Persistence.Context;
using AirlineManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Globalization;
var culture = new CultureInfo("az-AZ");
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
    })
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
      options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AirlineDb;Trusted_Connection=True;TrustServerCertificate=True;",
      sql => sql.EnableRetryOnFailure()));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IAircraftService, AircraftService>();
        services.AddScoped<IAirportService, AirportService>();
        services.AddScoped<IPassengerService, PassengerService>();
        services.AddScoped<IFlightService, FlightService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
        services.AddTransient<ConsoleMenu>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var menu = scope.ServiceProvider.GetRequiredService<ConsoleMenu>();

await menu.ShowMainMenuAsync();