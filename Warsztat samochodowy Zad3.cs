using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleRentalSystem
{
  
    public abstract class Vehicle
    {
        
        public string Id { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public decimal RentalRate { get; private set; } 
        public bool IsAvailable { get; private set; }

        
        protected Vehicle(string id, string brand, string model, decimal rentalRate)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Identyfikator nie może być pusty.");
            Id = id;
            Brand = brand;
            Model = model;
            RentalRate = rentalRate;
            IsAvailable = true; 
        }

       
        public void Rent()
        {
            if (!IsAvailable)
                throw new InvalidOperationException($"Pojazd {Id} jest aktualnie niedostępny.");
            IsAvailable = false;
        }

        public void ReturnVehicle()
        {
            if (IsAvailable)
                throw new InvalidOperationException($"Pojazd {Id} nie był wypożyczony.");
            IsAvailable = true;
        }

     
        public abstract decimal CalculateRentalCost(int minutes);
    }

   
    public class Car : Vehicle
    {
        public string FuelType { get; private set; }
        public bool HasInsurance { get; private set; }

        public Car(string id, string brand, string model, decimal rentalRate, string fuelType, bool hasInsurance)
            : base(id, brand, model, rentalRate)
        {
            FuelType = fuelType;
            HasInsurance = hasInsurance;
        }

       
        public override decimal CalculateRentalCost(int minutes)
        {
            decimal baseCost = minutes * RentalRate;
          
            return HasInsurance ? baseCost + 20.00m : baseCost;
        }
    }

    public class Bike : Vehicle
    {
        public int FrameSize { get; private set; }
        public bool HasBasket { get; private set; }

        public Bike(string id, string brand, string model, decimal rentalRate, int frameSize, bool hasBasket)
            : base(id, brand, model, rentalRate)
        {
            FrameSize = frameSize;
            HasBasket = hasBasket;
        }

        public override decimal CalculateRentalCost(int minutes)
        {
            
            int billableMinutes = Math.Max(0, minutes - 15);
            return billableMinutes * RentalRate;
        }
    }

    public class Scooter : Vehicle
    {
        public int BatteryLevel { get; private set; }

        public Scooter(string id, string brand, string model, decimal rentalRate, int batteryLevel)
            : base(id, brand, model, rentalRate)
        {
            BatteryLevel = batteryLevel;
        }

        public override decimal CalculateRentalCost(int minutes)
        {
          
            decimal startFee = 4.50m;
            return startFee + (minutes * RentalRate);
        }
    }

   
    public class User
    {
        public string UserId { get; private set; } 
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public User(string userId, string fullName, string email)
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
        }
    }

    public class Rental
    {
        public string RentalId { get; private set; }
        public string CustomerId { get; private set; }
        public Vehicle RentedVehicle { get; private set; } 
        public DateTime StartTime { get; private set; }

        public Rental(string rentalId, string customerId, Vehicle vehicle)
        {
            RentalId = rentalId;
            CustomerId = customerId;
            RentedVehicle = vehicle;
            StartTime = DateTime.Now;
        }
    }

   
    public class RentalManager
    {
      
        public List<Vehicle> Fleet { get; private set; } = new List<Vehicle>();
        public List<Rental> ActiveRentals { get; private set; } = new List<Rental>();

        
        public void AddVehicle(Vehicle vehicle)
        {
            Fleet.Add(vehicle);
        }

        public void RentVehicle(string userId, string vehicleId)
        {
            Vehicle vehicle = Fleet.FirstOrDefault(v => v.Id == vehicleId);
            if (vehicle == null)
            {
                Console.WriteLine($"[BŁĄD] Nie znaleziono pojazdu o ID: {vehicleId}");
                return;
            }

            try
            {
                vehicle.Rent(); 
                string rentalId = Guid.NewGuid().ToString().Substring(0, 8);
                Rental rental = new Rental(rentalId, userId, vehicle);
                ActiveRentals.Add(rental);
                Console.WriteLine($"[SUKCES] Klient {userId} wypożyczył pojazd: {vehicle.Brand} {vehicle.Model} ({vehicleId})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[BŁĄD OPERACJI]: {ex.Message}");
            }
        }

        public void ReturnVehicle(string vehicleId, int durationMinutes)
        {
            Rental rental = ActiveRentals.FirstOrDefault(r => r.RentedVehicle.Id == vehicleId);
            if (rental == null)
            {
                Console.WriteLine($"[BŁĄD] Brak aktywnego wypożyczenia dla pojazdu o ID: {vehicleId}");
                return;
            }

            rental.RentedVehicle.ReturnVehicle(); 
            ActiveRentals.Remove(rental);

           
            decimal finalCost = rental.RentedVehicle.CalculateRentalCost(durationMinutes);

            Console.WriteLine($"[ZWROT] Pojazd {vehicleId} został zwrócony.");
            Console.WriteLine($"\tCzas trwania: {durationMinutes} min.");
            Console.WriteLine($"\tKoszt całkowity: {finalCost:F2} zł (Obliczony polimorficznie dla typu: {rental.RentedVehicle.GetType().Name})");
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== SYSTEM REJESTRACJI I SYMULACJI WYPOŻYCZALNI POJAZDÓW ===\n");

            
            RentalManager manager = new RentalManager();

            
            Car car = new Car("S1-XYZ", "Audi", "A3", 0.90m, "Benzyna", true);
            Bike bike = new Bike("R-102", "Kross", "Vento", 0.20m, 19, true);
            Scooter scooter = new Scooter("H-99", "Xiaomi", "M365", 0.50m, 92);

            manager.AddVehicle(car);
            manager.AddVehicle(bike);
            manager.AddVehicle(scooter);

           
            User student = new User("ALBUM-12345", "Jakub Hrabia", "j.hrabia@student.wsb.pl");

           
            Console.WriteLine("--- KROK 1: Wypożyczenie trzech różnych kategorii pojazdów ---");
            manager.RentVehicle(student.UserId, "S1-XYZ");
            manager.RentVehicle(student.UserId, "R-102");
            manager.RentVehicle(student.UserId, "H-99");
            Console.WriteLine();

            Console.WriteLine("--- KROK 2: Próba ponownego wypożyczenia zajętego pojazdu (Walidacja) ---");
            manager.RentVehicle("INNY-USER", "S1-XYZ");
            Console.WriteLine();

            Console.WriteLine("--- KROK 3: Zwroty pojazdów z polimorficznym naliczaniem kosztów (Czas: 30 minut) ---");
           
            manager.ReturnVehicle("S1-XYZ", 30);

         
            manager.ReturnVehicle("R-102", 30);

            
            manager.ReturnVehicle("H-99", 30);

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć program...");
            Console.ReadKey();
        }
    }
}