import os

kontynuuj = True
while kontynuuj:
    os.system('cls' if os.name == 'nt' else 'clear')
    print("=== ZADANIE 2: KONWERTER TEMPERATUR ===")
    
    opcja = input("Wybierz kierunek konwersji (C - Celsjusz na Fahrenheit, F - Fahrenheit na Celsjusz): ").upper()
    temp_wejsciowa = float(input("Podaj wartosc temperatury: "))
    
    print("---------------------------------------")
    
    if opcja == 'C':
        fahrenheit = temp_wejsciowa * 1.8 + 32
        print(f"Wynik: {temp_wejsciowa}C = {fahrenheit}F")
    elif opcja == 'F':
        celsjusz = (temp_wejsciowa - 32) / 1.8
        print(f"Wynik: {temp_wejsciowa}F = {celsjusz}C")
    else:
        print("Blad! Niepoprawny wybor kierunku (wybierz C lub F).")
        
    print("=======================================")
    if input("Czy chcesz przeliczyc kolejna temperature? (t/n): ").lower() == 'n':
        kontynuuj = False