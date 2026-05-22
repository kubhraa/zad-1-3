using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool kontynuuj = true;

        while (kontynuuj)
        {
            Console.Clear();
            Console.WriteLine("=== ZADANIE 2: KONWERTER TEMPERATUR ===");

            Console.Write("Wybierz kierunek konwersji (C - Celsjusz na Fahrenheit, F - Fahrenheit na Celsjusz): ");
            char opcja = Convert.ToChar(Console.ReadLine().ToUpper()); // .ToUpper() zmienia na wielką literę

            Console.Write("Podaj wartość temperatury: ");
            double tempWejsciowa = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("---------------------------------------");

            // Instrukcja warunkowa do rozróżnienia przypadków
            if (opcja == 'C')
            {
                double fahrenheit = tempWejsciowa * 1.8 + 32;
                Console.WriteLine($"Wynik: {tempWejsciowa}°C = {fahrenheit}°F");
            }
            else if (opcja == 'F')
            {
                double celsjusz = (tempWejsciowa - 32) / 1.8;
                Console.WriteLine($"Wynik: {tempWejsciowa}°F = {celsjusz}°C");
            }
            else
            {
                Console.WriteLine("Błąd! Niepoprawny wybór kierunku (wybierz C lub F).");
            }

            Console.WriteLine("=======================================");
            Console.Write("Czy chcesz przeliczyć kolejną temperaturę? (t/n): ");
            if (Console.ReadLine().ToLower() == "n") kontynuuj = false;
        }
    }
}