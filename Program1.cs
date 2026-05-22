using System;

class Program
{
    static void Main()
    {
        // Ustawienie poprawnego wyświetlania polskich znaków w konsoli
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        bool kontynuuj = true;

        // Ta pętla będzie się wykonywać bez końca, dopóki zmienna kontynuuj będzie miała wartość true
        while (kontynuuj)
        {
            Console.Clear(); // Czyszczenie ekranu przed każdym nowym działaniem
            Console.WriteLine("=== PROSTY KALKULATOR C# (ZAPĘTLONY) ===");

            //  Pobieranie pierwszej liczby
            Console.Write("Podaj pierwszą liczbę: ");
            double liczba1 = Convert.ToDouble(Console.ReadLine());

            // Pobieranie znaku operacji
            Console.Write("Wybierz działanie (+, -, *, /): ");
            char znak = Convert.ToChar(Console.ReadLine());

            //  Pobieranie drugiej liczby
            Console.Write("Podaj drugą liczbę: ");
            double liczba2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("-------------------------");

            double wynik = 0;
            bool poprawnaOperacja = true;

            // 4. Obliczenia
            switch (znak)
            {
                case '+':
                    wynik = liczba1 + liczba2;
                    break;
                case '-':
                    wynik = liczba1 - liczba2;
                    break;
                case '*':
                    wynik = liczba1 * liczba2;
                    break;
                case '/':
                    if (liczba2 != 0)
                    {
                        wynik = liczba1 / liczba2;
                    }
                    else
                    {
                        Console.WriteLine("Błąd! Nie można dzielić przez zero!");
                        poprawnaOperacja = false;
                    }
                    break;
                default:
                    Console.WriteLine("Błąd! Nieznany znak działania!");
                    poprawnaOperacja = false;
                    break;
            }

            // Wyświetlenie wyniku
            if (poprawnaOperacja)
            {
                Console.WriteLine($"Wynik: {liczba1} {znak} {liczba2} = {wynik}");
            }

            Console.WriteLine("=========================");

            //  Pytanie o powtórzenie pętli
            Console.Write("Czy chcesz wykonać kolejne działanie? (t/n): ");
            char decyzja = Convert.ToChar(Console.ReadLine().ToLower()); 

            if (decyzja == 'n')
            {
                kontynuuj = false;
            }
        }

        Console.WriteLine("\nDziękuję za skorzystanie z kalkulatora Miłego dnia.");
        Console.WriteLine("Naciśnij dowolny klawisz, aby zamknąć...");
        Console.ReadKey();
    }
}