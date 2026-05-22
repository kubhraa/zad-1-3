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
            Console.WriteLine("=== ZADANIE 3: ŚREDNIA OCEN ===");

            Console.Write("Podaj liczbę ocen, które chcesz wprowadzić: ");
            int liczbaOcen = Convert.ToInt32(Console.ReadLine());

            double suma = 0;

            
            for (int i = 1; i <= liczbaOcen; i++)
            {
                Console.Write($"Podaj ocenę nr {i} (skala 1-6): ");
                double ocena = Convert.ToDouble(Console.ReadLine());
                suma += ocena; // dodajemy ocenę do sumy
            }

            double srednia = suma / liczbaOcen;
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Średnia: {srednia:F2}"); 

           
            if (srednia >= 3.0)
            {
                Console.WriteLine("Uczeń zdał.");
            }
            else
            {
                Console.WriteLine("Uczeń nie zdał.");
            }

            Console.WriteLine("=======================================");
            Console.Write("Czy chcesz obliczyć średnią dla innego ucznia? (t/n): ");
            if (Console.ReadLine().ToLower() == "n") kontynuuj = false;
        }
    }
}