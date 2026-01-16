using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class CurrencyResponse
{
    public string Base { get; set; }
    public Dictionary<string, decimal> Rates { get; set; }
}

class Currency
{
    public string Code { get; set; }
    public decimal Rate { get; set; }
}

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("CurrencyTracker başlatıldı...");
        Console.WriteLine("Döviz verileri alınıyor...\n");

        List<Currency> currencies = await GetCurrenciesAsync();

        Console.WriteLine("\n===== CurrencyTracker =====");

        while (true)
        {
            Console.WriteLine("1. Tüm dövizleri listele");
            Console.WriteLine("2. Koda göre döviz ara");
            Console.WriteLine("3. Belirli bir değerden büyük dövizleri listele");
            Console.WriteLine("4. Dövizleri değere göre sırala");
            Console.WriteLine("5. İstatistiksel özet göster");
            Console.WriteLine("0. Çıkış");
            Console.Write("Seçiminiz: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ListAllCurrencies(currencies);
                    break;

                case "2":
                    SearchByCode(currencies);
                    break;

                case "3":
                    FilterByRate(currencies);
                    break;

                case "4":
                    SortCurrencies(currencies);
                    break;

                case "5":
                    ShowStatistics(currencies);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Geçersiz seçim.\n");
                    break;
            }
        }
    }

    // ================= API =================

    static async Task<List<Currency>> GetCurrenciesAsync()
    {
        try
        {
            using HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(5);

            Console.WriteLine("API isteği gönderiliyor...");

            var response = await client.GetStringAsync(
                "https://api.frankfurter.app/latest?from=TRY"
            );

            var data = JsonSerializer.Deserialize<CurrencyResponse>(
                response,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            Console.WriteLine("API'den veri alındı.");

            return data.Rates
                .Select(x => new Currency
                {
                    Code = x.Key,
                    Rate = x.Value
                })
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("API HATASI:");
            Console.WriteLine(ex.Message);
            Console.WriteLine("\nDemo veriler kullanılacak.");

            return GenerateDemoCurrencies();
        }
    }

    // ================= MENÜ =================

    static void ListAllCurrencies(List<Currency> currencies)
    {
        foreach (var c in currencies)
        {
            Console.WriteLine($"{c.Code} : {c.Rate}");
        }
        Console.WriteLine();
    }

    static void SearchByCode(List<Currency> currencies)
    {
        Console.Write("Döviz kodu girin: ");
        string code = Console.ReadLine();

        var result = currencies
            .Where(c => c.Code.Equals(code, StringComparison.OrdinalIgnoreCase));

        foreach (var c in result)
        {
            Console.WriteLine($"{c.Code} : {c.Rate}");
        }

        Console.WriteLine();
    }

    static void FilterByRate(List<Currency> currencies)
    {
        Console.Write("Minimum değer girin: ");
        decimal min = decimal.Parse(Console.ReadLine());

        var result = currencies.Where(c => c.Rate > min);

        foreach (var c in result)
        {
            Console.WriteLine($"{c.Code} : {c.Rate}");
        }

        Console.WriteLine();
    }

    static void SortCurrencies(List<Currency> currencies)
    {
        var sorted = currencies.OrderByDescending(c => c.Rate);

        foreach (var c in sorted)
        {
            Console.WriteLine($"{c.Code} : {c.Rate}");
        }

        Console.WriteLine();
    }

    static void ShowStatistics(List<Currency> currencies)
    {
        Console.WriteLine($"Toplam döviz sayısı: {currencies.Count()}");
        Console.WriteLine($"En yüksek kur: {currencies.Max(c => c.Rate)}");
        Console.WriteLine($"En düşük kur: {currencies.Min(c => c.Rate)}");
        Console.WriteLine($"Ortalama kur: {currencies.Average(c => c.Rate)}");
        Console.WriteLine();
    }

    // ================= DEMO =================

    static List<Currency> GenerateDemoCurrencies()
    {
        return new List<Currency>
        {
            new Currency { Code = "USD", Rate = 1.23m },
            new Currency { Code = "EUR", Rate = 1.10m },
            new Currency { Code = "GBP", Rate = 1.35m },
            new Currency { Code = "JPY", Rate = 0.0085m },
            new Currency { Code = "CHF", Rate = 1.15m }
        };
    }
}
