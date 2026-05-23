import os

kontynuuj = True
while kontynuuj:
    os.system('cls' if os.name == 'nt' else 'clear')
    print("=== SREDNIA OCEN ===")
    
    liczba_ocen = int(input("Podaj liczbe ocen, ktore chcesz wprowadzic: "))
    suma = 0
    
    # Petla FOR do pobrania serii ocen
    for i in range(1, liczba_ocen + 1):
        ocena = float(input(f"Podaj ocene nr {i} (skala 1-6): "))
        suma += ocena
        
    srednia = suma / liczba_ocen
    print("---------------------------------------")
    print(f"Srednia: {srednia:.2f}")
    
    # Sprawdzenie warunku zaliczenia (wszystkie polskie znaki usuniete)
    if srednia >= 3.0:
        print("Uczen zdal.")
    else:
        print("Uczen nie zdal.")
        
    print("=========================")
    if input("Czy chcesz obliczyc srednia dla innego ucznia? (t/n): ").lower() == 'n':
        kontynuuj = False