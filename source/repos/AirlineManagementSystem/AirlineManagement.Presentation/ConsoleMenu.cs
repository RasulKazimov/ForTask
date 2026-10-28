using AirlineManagement.Application.DTOs;
using AirlineManagement.Application.Exceptions;
using AirlineManagement.Application.Services;
using AirlineManagement.Domain.Enums;

namespace AirlineManagement.ConsoleApp;

public class ConsoleMenu
{
    private readonly IAircraftService _aircraftService;
    private readonly IAirportService _airportService;
    private readonly IPassengerService _passengerService;
    private readonly IFlightService _flightService;
    private readonly IReservationService _reservationService;

    public ConsoleMenu(
        IAircraftService aircraftService,
        IAirportService airportService,
        IPassengerService passengerService,
        IFlightService flightService,
        IReservationService reservationService)
    {
        _aircraftService = aircraftService;
        _airportService = airportService;
        _passengerService = passengerService;
        _flightService = flightService;
        _reservationService = reservationService;
    }

    public async Task ShowMainMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===========================================");
            Console.WriteLine("  AVİAŞİRKƏT İDARƏETMƏ SİSTEMİ (MAIN MENU)");
            Console.WriteLine("===========================================");
            Console.WriteLine("1. Təyyarə İdarəetməsi");
            Console.WriteLine("2. Hava Limanı İdarəetməsi");
            Console.WriteLine("3. Uçuş İdarəetməsi");
            Console.WriteLine("4. Sərnişin İdarəetməsi");
            Console.WriteLine("5. Rezervasiya İdarəetməsi");
            Console.WriteLine("0. Çıxış");
            Console.Write("\nSeçiminizi edin: ");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    await AircraftMenuAsync();
                    break;
                case "2":
                    await AirportMenuAsync();
                    break;
                case "3":
                    await FlightMenuAsync();
                    break;
                case "4":
                    await PassengerMenuAsync();
                    break;
                case "5":
                    await ReservationMenuAsync();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Yanlış seçim! Yenidən cəhd edin.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private async Task AircraftMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- TƏYYARƏ İDARƏETMƏSİ ---");
            Console.WriteLine("1. Bütün Təyyarələri Göstər");
            Console.WriteLine("2. Yeni Təyyarə Əlavə Et");
            Console.WriteLine("3. Təyyarə Sil");
            Console.WriteLine("0. Geri");
            Console.Write("\nSeçim: ");

            var input = Console.ReadLine();
            if (input == "0") break;

            if (input == "1")
            {
                try
                {
                    var list = await _aircraftService.GetAllAsync();
                    Console.WriteLine("\n--- TƏYYARƏ SİYAHISI ---");
                    foreach (var item in list)
                    {
                        Console.WriteLine($"ID: {item.Id} | Model: {item.Model} | Reg: {item.RegistrationNumber} | Tutum: {item.Capacity} (Biznes: {item.BusinessClassSeats}, Ekonom: {item.EconomyClassSeats}) | Status: {item.Status}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nXəta baş verdi: {ex.Message}");
                }
            }
            else if (input == "2")
            {
                try
                {
                    Console.Write("Model (məs: Boeing 737): ");
                    var model = Console.ReadLine() ?? "";

                    Console.Write("Qeydiyyat Nömrəsi: ");
                    var regNum = Console.ReadLine() ?? "";

                    Console.Write("Ümumi Tutum: ");
                    int.TryParse(Console.ReadLine(), out int capacity);

                    Console.Write("Biznes Klass Oturacaq Sayı: ");
                    int.TryParse(Console.ReadLine(), out int businessSeats);

                    Console.Write("Ekonom Klass Oturacaq Sayı: ");
                    int.TryParse(Console.ReadLine(), out int economySeats);

                    var dto = new CreateAircraftDto(model, regNum, capacity, businessSeats, economySeats);
                    await _aircraftService.CreateAsync(dto);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n✅ Təyyarə uğurla əlavə olundu!");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n❌ Xəta: {ex.Message}");
                    Console.ResetColor();
                }
            }
            else if (input == "3")
            {
                try
                {
                    Console.Write("Silinəcək Təyyarənin ID-sini daxil edin: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        await _aircraftService.DeleteAsync(id);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n✅ Təyyarə uğurla silindi!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Yanlış ID formatı!");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n❌ Xəta: {ex.Message}");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\nDavam etmək üçün Enter sıxın...");
            Console.ReadLine();
        }
    }

    private async Task AirportMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- HAVA LİMANI İDARƏETMƏSİ ---");
            Console.WriteLine("1. Hava Limanlarını Göstər");
            Console.WriteLine("2. Yeni Hava Limanı Əlavə Et");
            Console.WriteLine("3. Hava Limanı Sil");
            Console.WriteLine("0. Geri");
            Console.Write("\nSeçim: ");

            var input = Console.ReadLine();
            if (input == "0") break;

            if (input == "1")
            {
                try
                {
                    var list = await _airportService.GetAllAsync();
                    Console.WriteLine("\n--- HAVA LİMANLARI SİYAHISI ---");
                    foreach (var a in list)
                    {
                        Console.WriteLine($"ID: {a.Id} | Kod: {a.Code} | Adı: {a.Name} | {a.City}, {a.Country}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nXəta: {ex.Message}");
                }
            }
            else if (input == "2")
            {
                try
                {
                    Console.Write("Adı: "); var name = Console.ReadLine() ?? "";
                    Console.Write("Kod (məs: GYD): "); var code = Console.ReadLine() ?? "";
                    Console.Write("Şəhər: "); var city = Console.ReadLine() ?? "";
                    Console.Write("Ölkə: "); var country = Console.ReadLine() ?? "";

                    await _airportService.CreateAsync(new CreateAirportDto(name, code, city, country));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n✅ Hava limanı əlavə olundu!");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n❌ Xəta: {ex.Message}");
                    Console.ResetColor();
                }
            }
            else if (input == "3")
            {
                try
                {
                    Console.Write("Silinəcək Hava Limanının ID-sini daxil edin: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        await _airportService.DeleteAsync(id);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n✅ Hava limanı uğurla silindi!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Yanlış ID formatı!");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n❌ Xəta: {ex.Message}");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\nDavam etmək üçün Enter sıxın...");
            Console.ReadLine();
        }
    }

    private async Task FlightMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- UÇUŞ İDARƏETMƏSİ ---");
            Console.WriteLine("1. Uçuşları Göstər");
            Console.WriteLine("2. Uçuşu Ləğv Et (Sil)");
            Console.WriteLine("0. Geri");
            Console.Write("\nSeçim: ");

            var input = Console.ReadLine();
            if (input == "0") break;

            if (input == "1")
            {
                try
                {
                    var list = await _flightService.GetAllFlightsAsync();
                    Console.WriteLine("\n--- UÇUŞ SİYAHISI ---");
                    foreach (var f in list)
                    {
                        Console.WriteLine($"ID: {f.Id} | Uçuş No: {f.FlightNumber} | Təyyarə: {f.AircraftModel} | Qalxış: {f.DepartureAirport} ({f.DepartureTime:dd.MM.yyyy HH:mm}) -> Eniş: {f.ArrivalAirport} ({f.ArrivalTime:dd.MM.yyyy HH:mm}) | Status: {f.Status}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nXəta: {ex.Message}");
                }
            }
            else if (input == "2")
            {
                try
                {
                    Console.Write("Ləğv ediləcək Uçuşun ID-sini daxil edin: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        await _flightService.CancelFlightAsync(id);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n✅ Uçuş uğurla ləğv edildi!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Yanlış ID formatı!");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n❌ Xəta: {ex.Message}");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\nDavam etmək üçün Enter sıxın...");
            Console.ReadLine();
        }
    }

    private async Task PassengerMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- SƏRNİŞİN İDARƏETMƏSİ ---");
            Console.WriteLine("1. Sərnişinləri Göstər");
            Console.WriteLine("2. Yeni Sərnişin Əlavə Et");
            Console.WriteLine("3. Sərnişin Sil");
            Console.WriteLine("0. Geri");
            Console.Write("\nSeçim: ");

            var input = Console.ReadLine();
            if (input == "0") break;

            if (input == "1")
            {
                try
                {
                    var list = await _passengerService.GetAllAsync();
                    Console.WriteLine("\n--- SƏRNİŞİN SİYAHISI ---");
                    foreach (var p in list)
                    {
                        Console.WriteLine($"ID: {p.Id} | Ad: {p.FullName} | Pasport: {p.PassportNumber} | Email: {p.Email} | Tel: {p.PhoneNumber}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nXəta: {ex.Message}");
                }
            }
            else if (input == "2")
            {
                try
                {
                    Console.Write("Ad Soyad: "); var name = Console.ReadLine() ?? "";
                    Console.Write("Pasport No: "); var passport = Console.ReadLine() ?? "";
                    Console.Write("Email: "); var email = Console.ReadLine() ?? "";
                    Console.Write("Telefon: "); var phone = Console.ReadLine() ?? "";

                    await _passengerService.CreateAsync(new CreatePassengerDto(name, passport, email, phone, DateTime.Now.AddYears(-20)));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n✅ Sərnişin əlavə olundu!");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n❌ Xəta: {ex.Message}");
                    Console.ResetColor();
                }
            }
            else if (input == "3")
            {
                try
                {
                    Console.Write("Silinəcək Sərnişinin ID-sini daxil edin: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        await _passengerService.DeleteAsync(id);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n✅ Sərnişin uğurla silindi!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Yanlış ID formatı!");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n❌ Xəta: {ex.Message}");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\nDavam etmək üçün Enter sıxın...");
            Console.ReadLine();
        }
    }

    private async Task ReservationMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- REZERVASİYA İDARƏETMƏSİ ---");
            Console.WriteLine("1. Bütün Rezervasiyaları Göstər");
            Console.WriteLine("2. Rezervasiyanı Ləğv Et (Sil)");
            Console.WriteLine("0. Geri");
            Console.Write("\nSeçim: ");

            var input = Console.ReadLine();
            if (input == "0") break;

            if (input == "1")
            {
                try
                {
                    var list = await _reservationService.GetAllReservationsAsync();
                    Console.WriteLine("\n--- REZERVASİYA SİYAHISI ---");
                    foreach (var r in list)
                    {
                        Console.WriteLine($"ID: {r.Id} | Kod: {r.ReservationCode} | Sərnişin: {r.PassengerName} | Uçuş No: {r.FlightNumber} | Qiymət: {r.TotalPrice} | Status: {r.Status}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nXəta: {ex.Message}");
                }
            }
            else if (input == "2")
            {
                try
                {
                    Console.Write("Ləğv ediləcək Rezervasiyanın ID-sini daxil edin: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.Write("Ləğv edilmə səbəbini yazın: ");
                        var reason = Console.ReadLine() ?? "İstifadəçi tərəfindən silindi";

                        await _reservationService.CancelReservationAsync(id, reason);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n✅ Rezervasiya uğurla ləğv edildi!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Yanlış ID formatı!");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n❌ Xəta: {ex.Message}");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\nDavam etmək üçün Enter sıxın...");
            Console.ReadLine();
        }
    }
}