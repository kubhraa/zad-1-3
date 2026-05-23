import os

kontynuuj = True
while kontynuuj:
    os.system('cls' if os.name == 'nt' else 'clear')
    print("=== PROSTY KALKULATOR PYTHON===")
    
    # 1. Pobieranie danych
    liczba1 = float(input("Podaj pierwsza liczbe: "))
    znak = input("Wybierz dzialanie (+, -, *, /): ")
    liczba2 = float(input("Podaj druga liczbe: "))
    
    print("-------------------------")
    wynik = 0
    poprawna_operacja = True
    
    # 2. Obliczenia
    if znak == '+':
        wynik = liczba1 + liczba2
    elif znak == '-':
        wynik = liczba1 - liczba2
    elif znak == '*':
        wynik = liczba1 * liczba2
    elif znak == '/':
        if liczba2 != 0:
            wynik = integer1 / liczba2
        else:
            print("Blad! Nie mozna dzielic przez zero!")
            poprawna_operacja = False
    else:
        print("Nieznany znak dzialania!")
        poprawna_operacja = False
        
    # 3. Wyswietlenie wyniku
    if poprawna_operacja:
        print(f"Wynik: {liczba1} {znak} {liczba2} = {wynik}")
        
    print("=========================")
    if input("Czy chcesz wykonac kolejne dzialanie? (t/n): ").lower() == 'n':
        kontynuuj = False
