---
layout: material
title: "Pętle i sterowanie przebiegiem gry"
kind: lecture
week: 4
summary: "Pętle while, do-while i for, sterowanie ich przebiegiem oraz budowa głównej pętli gry i menu."
published: true
content_ready: true
---

## Cel wykładu

Instrukcje warunkowe pozwalają programowi podjąć pojedynczą decyzję. Pętle pozwalają wykonywać ten sam fragment kodu wiele razy: wyświetlać menu aż do wyboru wyjścia, odliczać kolejne tury albo ponawiać pytanie do czasu podania poprawnej wartości.

Po tym wykładzie będziesz potrafić:

- wyjaśnić, z jakich elementów składa się pętla,
- stosować pętle `while`, `do-while` i `for`,
- dobrać rodzaj pętli do problemu,
- używać `break` i `continue`,
- rozpoznawać pętle nieskończone i błędy typu „o jeden za dużo”,
- walidować dane podawane przez użytkownika,
- zbudować menu oraz prostą główną pętlę gry.

> **Ważne:** każda pętla powinna mieć jasno określony warunek kontynuowania albo sposób zakończenia.

---

## 1. Po co programowi pętla?

Bez pętli pięć tur trzeba byłoby zapisać pięć razy. Pętla opisuje powtarzanie za pomocą trzech elementów:

1. **stanu początkowego** — od czego zaczynamy,
2. **warunku** — jak długo wykonujemy kod,
3. **zmiany stanu** — co przybliża nas do końca.

    int tura = 1;           // stan początkowy

    while (tura <= 5)       // warunek
    {
        Console.WriteLine($"Tura {tura}");
        tura++;             // zmiana stanu
    }

Jedno wykonanie bloku pętli nazywamy **iteracją**. W przykładzie wystąpi pięć iteracji, a po zakończeniu zmienna `tura` ma wartość 6.

> **Pytanie do sali:** Co się stanie, jeśli usuniemy instrukcję `tura++`?

---

## 2. Pętla while — najpierw warunek

Pętla `while` sprawdza warunek **przed** każdą iteracją. Jeżeli warunek od początku jest fałszywy, jej blok nie wykona się ani razu.

    int energia = 3;

    while (energia > 0)
    {
        Console.WriteLine($"Bohater idzie. Energia: {energia}");
        energia--;
    }

    Console.WriteLine("Bohater musi odpocząć.");

| Iteracja | `energia` przed blokiem | Czy `energia > 0`? | `energia` po `energia--` |
|---|---:|---|---:|
| 1 | 3 | true | 2 |
| 2 | 2 | true | 1 |
| 3 | 1 | true | 0 |
| koniec | 0 | false | — |

`while` jest dobrym wyborem, gdy nie wiemy z góry, ile razy kod się powtórzy:

- pytamy o hasło aż będzie poprawne,
- prowadzimy grę aż gracz wybierze wyjście,
- wykonujemy tury, dopóki bohater i przeciwnik żyją.

    int punktyZycia = 0;

    while (punktyZycia > 0)
    {
        Console.WriteLine("Bohater wykonuje ruch.");
    }

Komunikat nie pojawi się, ponieważ pierwszy test warunku daje `false`.

---

## 3. Pętla do-while — najpierw działanie

Pętla `do-while` sprawdza warunek **po** wykonaniu bloku, dlatego zawsze wykona się co najmniej raz.

    string odpowiedz;

    do
    {
        Console.Write("Czy chcesz zagrać ponownie? (t/n): ");
        odpowiedz = Console.ReadLine()!;
    }
    while (odpowiedz != "t" && odpowiedz != "n");

Najpierw program zada pytanie, a następnie zdecyduje, czy je powtórzyć. Średnik po warunku `while` jest w tej konstrukcji wymagany.

`do-while` dobrze pasuje do menu, które trzeba pokazać przynajmniej raz, pytania o dane oraz ekranu „zagraj ponownie?”.

    // Najpierw sprawdzenie — możliwe zero wykonań.
    while (warunek)
    {
        // instrukcje
    }

    // Najpierw instrukcje — co najmniej jedno wykonanie.
    do
    {
        // instrukcje
    }
    while (warunek);

---

## 4. Pętla for — gdy znamy liczbę powtórzeń

Pętla `for` umieszcza inicjalizację, warunek i zmianę licznika w jednym wierszu:

    for (int tura = 1; tura <= 5; tura++)
    {
        Console.WriteLine($"Tura {tura}");
    }

Nagłówek ma postać `for (inicjalizacja; warunek; zmiana)`:

- `int tura = 1` wykonuje się raz przed rozpoczęciem pętli,
- `tura <= 5` jest sprawdzane przed każdą iteracją,
- `tura++` wykonuje się po każdej iteracji.

### Odliczanie w dół

    for (int sekunda = 3; sekunda >= 1; sekunda--)
    {
        Console.WriteLine(sekunda);
    }

    Console.WriteLine("Start!");

### Inny krok licznika

    for (int liczba = 0; liczba <= 10; liczba += 2)
    {
        Console.WriteLine(liczba);
    }

Program wypisze liczby parzyste od 0 do 10. Zmienna zadeklarowana w nagłówku, np. `tura`, istnieje tylko wewnątrz pętli.

---

## 5. Licznik, suma i akumulator

Pętle często aktualizują wartość przechowującą dotychczasowy wynik. Taką zmienną nazywamy **akumulatorem**.

    int sumaObrazen = 0;

    for (int tura = 1; tura <= 4; tura++)
    {
        Console.Write($"Obrażenia w turze {tura}: ");
        int obrazenia = int.Parse(Console.ReadLine()!);
        sumaObrazen += obrazenia;
    }

    Console.WriteLine($"Łączne obrażenia: {sumaObrazen}");

Wartość początkowa akumulatora ma znaczenie. Dla sumy najczęściej jest to 0. Licznik zdarzeń działa podobnie:

    int liczbaTrafien = 0;

    for (int proba = 1; proba <= 3; proba++)
    {
        Console.Write("Czy atak trafił? (t/n): ");
        string wynik = Console.ReadLine()!;

        if (wynik == "t")
        {
            liczbaTrafien++;
        }
    }

    Console.WriteLine($"Liczba trafień: {liczbaTrafien}");

---

## 6. Pętle zagnieżdżone

Pętla może znajdować się wewnątrz innej pętli. Zewnętrzna pętla wybiera wiersz, a wewnętrzna kolejne kolumny:

    for (int wiersz = 1; wiersz <= 3; wiersz++)
    {
        for (int kolumna = 1; kolumna <= 5; kolumna++)
        {
            Console.Write("#");
        }

        Console.WriteLine();
    }

Wynik:

    #####
    #####
    #####

Wewnętrzna pętla wykonuje się od początku dla każdej iteracji pętli zewnętrznej. Znak `#` zostanie wypisany `3 * 5`, czyli 15 razy.

### Tabliczka mnożenia

    for (int wiersz = 1; wiersz <= 5; wiersz++)
    {
        for (int kolumna = 1; kolumna <= 5; kolumna++)
        {
            Console.Write($"{wiersz * kolumna,4}");
        }

        Console.WriteLine();
    }

Wyrażenie `,4` ustala minimalną szerokość pola, dzięki czemu kolumny są wyrównane.

---

## 7. break i continue

Instrukcja `break` natychmiast kończy najbliższą pętlę:

    for (int skrzynia = 1; skrzynia <= 10; skrzynia++)
    {
        Console.WriteLine($"Sprawdzam skrzynię {skrzynia}.");

        if (skrzynia == 4)
        {
            Console.WriteLine("Znaleziono klucz!");
            break;
        }
    }

Instrukcja `continue` pomija resztę bieżącej iteracji i przechodzi do następnej:

    for (int numerDrzwi = 1; numerDrzwi <= 5; numerDrzwi++)
    {
        if (numerDrzwi == 3)
        {
            Console.WriteLine("Drzwi 3 są zablokowane.");
            continue;
        }

        Console.WriteLine($"Otwierasz drzwi {numerDrzwi}.");
    }

| Instrukcja | Efekt |
|---|---|
| `break` | kończy całą najbliższą pętlę |
| `continue` | kończy tylko bieżącą iterację |

W pętlach zagnieżdżonych `break` kończy tylko pętlę, w której bezpośrednio się znajduje. Stosuj obie instrukcje oszczędnie, aby przebieg programu pozostał czytelny.

---

## 8. Bezpieczne wczytywanie danych

`int.Parse` kończy program błędem, gdy użytkownik wpisze tekst, którego nie można zamienić na liczbę. `int.TryParse` pozwala sprawdzić wynik konwersji:

    Console.Write("Podaj liczbę tur: ");
    bool poprawnaLiczba = int.TryParse(Console.ReadLine(), out int liczbaTur);

    if (poprawnaLiczba)
    {
        Console.WriteLine($"Liczba tur: {liczbaTur}");
    }
    else
    {
        Console.WriteLine("To nie jest liczba całkowita.");
    }

Pętla może ponawiać pytanie aż do uzyskania poprawnej wartości:

    int liczbaTur;

    while (true)
    {
        Console.Write("Podaj liczbę tur od 1 do 10: ");
        bool poprawnyFormat = int.TryParse(Console.ReadLine(), out liczbaTur);

        if (!poprawnyFormat)
        {
            Console.WriteLine("Wpisz liczbę całkowitą.");
            continue;
        }

        if (liczbaTur < 1 || liczbaTur > 10)
        {
            Console.WriteLine("Liczba musi należeć do zakresu 1–10.");
            continue;
        }

        break;
    }

    Console.WriteLine($"Wybrano {liczbaTur} tur.");

`while (true)` jest tu celowe: jedynym prawidłowym wyjściem jest `break` po przejściu wszystkich sprawdzeń.

---

## 9. Menu działające w pętli

Menu z poprzedniego tygodnia wykonywało tylko jedną akcję. Teraz może działać aż do wyboru wyjścia:

    bool graDziala = true;

    while (graDziala)
    {
        Console.WriteLine();
        Console.WriteLine("=== MENU ===");
        Console.WriteLine("1 - Pokaż stan bohatera");
        Console.WriteLine("2 - Odpocznij");
        Console.WriteLine("3 - Zakończ grę");
        Console.Write("Wybierz opcję: ");

        string wybor = Console.ReadLine()!;

        switch (wybor)
        {
            case "1":
                Console.WriteLine("Punkty życia: 75.");
                break;
            case "2":
                Console.WriteLine("Bohater odpoczywa.");
                break;
            case "3":
                graDziala = false;
                Console.WriteLine("Koniec gry.");
                break;
            default:
                Console.WriteLine("Nie ma takiej opcji.");
                break;
        }
    }

Zmienna `graDziala` opisuje stan programu. Wybranie opcji 3 zmienia ten stan, więc przed następną iteracją warunek pętli jest fałszywy.

Ten sam prosty mechanizm można zapisać za pomocą `while (true)` i instrukcji `break`. Zmienna logiczna zwykle lepiej pokazuje stan gry, a `break` jest wygodne przy jednym prostym punkcie wyjścia.

---

## 10. Główna pętla gry

W każdej iteracji głównej pętli gry program zwykle:

1. pokazuje aktualny stan,
2. pobiera decyzję gracza,
3. aktualizuje stan gry,
4. sprawdza warunek zakończenia.

```csharp
    int punktyZycia = 50;
    int zloto = 0;
    int numerTury = 1;
    bool graDziala = true;

    while (graDziala && punktyZycia > 0)
    {
        Console.WriteLine();
        Console.WriteLine($"=== TURA {numerTury} ===");
        Console.WriteLine($"Zdrowie: {punktyZycia} | Złoto: {zloto}");
        Console.WriteLine("1 - Eksploruj");
        Console.WriteLine("2 - Odpocznij");
        Console.WriteLine("3 - Wyjdź z gry");
        Console.Write("Akcja: ");

        string akcja = Console.ReadLine()!;

        switch (akcja)
        {
            case "1":
                zloto += 10;
                punktyZycia -= 5;
                Console.WriteLine("Znajdujesz 10 sztuk złota, ale tracisz 5 punktów życia.");
                break;
            case "2":
                punktyZycia += 10;
                Console.WriteLine("Odzyskujesz 10 punktów życia.");
                break;
            case "3":
                graDziala = false;
                Console.WriteLine("Opuszczasz grę.");
                break;
            default:
                Console.WriteLine("Nieznana akcja.");
                continue;
        }

        numerTury++;
    }

    if (punktyZycia <= 0)
    {
        Console.WriteLine("Bohater nie może kontynuować wyprawy.");
    }
```

`continue` przy nieznanej akcji powoduje, że numer tury nie wzrośnie. Błędny wybór nie jest liczony jako rozegrana tura.

W większych grach główna pętla obejmuje również ruch przeciwników, rysowanie świata i odmierzanie czasu. W programie konsolowym wystarczy na razie cykl: **stan → decyzja → zmiana → sprawdzenie końca**.

---

## 11. Najczęstsze błędy

### Pętla nieskończona

    int licznik = 1;

    while (licznik <= 5)
    {
        Console.WriteLine(licznik);
        // Brakuje licznik++.
    }

Warunek pozostaje prawdziwy, ponieważ `licznik` się nie zmienia.

### Średnik po nagłówku

    for (int i = 0; i < 5; i++);
    {
        Console.WriteLine("Ten blok nie należy do pętli.");
    }

Średnik tworzy pustą instrukcję wykonywaną w pętli. Blok w klamrach wykona się później tylko raz.

### Błąd „o jeden”

    for (int i = 1; i < 5; i++)
    {
        Console.WriteLine(i);
    }

Program wypisze 1, 2, 3 i 4. Aby wypisać również 5, potrzebny jest warunek `i <= 5`.

### Zły kierunek zmiany

    for (int i = 1; i <= 5; i--)
    {
        Console.WriteLine(i);
    }

Licznik maleje, więc nigdy nie przekroczy 5 i pętla się nie zakończy.

### continue przed zmianą stanu

    int licznik = 0;

    while (licznik < 5)
    {
        if (licznik == 2)
        {
            continue;
        }

        licznik++;
    }

Dla wartości 2 program ciągle wykonuje `continue` i nigdy nie dochodzi do `licznik++`. Przy `while` trzeba szczególnie pilnować aktualizacji stanu.

---

## 12. Jak dobrać pętlę?

| Sytuacja | Najczęstszy wybór | Powód |
|---|---|---|
| wykonaj dokładnie 10 tur | `for` | liczba powtórzeń jest znana |
| graj, dopóki bohater żyje | `while` | liczba powtórzeń nie jest znana |
| pokaż menu co najmniej raz | `do-while` | warunek sprawdzamy po pierwszym wykonaniu |
| pytaj aż dane będą poprawne | `while` lub `do-while` | koniec zależy od danych użytkownika |
| utwórz prostokąt ze znaków | zagnieżdżone `for` | znamy liczbę wierszy i kolumn |

To wskazówki, nie sztywne zakazy. Ten sam problem często da się rozwiązać kilkoma rodzajami pętli, ale jeden zapis może lepiej wyrażać zamiar programu.

---

## Podsumowanie

- pętla wielokrotnie wykonuje blok instrukcji,
- pojedyncze wykonanie bloku to iteracja,
- `while` sprawdza warunek przed iteracją i może nie wykonać się ani razu,
- `do-while` sprawdza warunek po iteracji i wykona się co najmniej raz,
- `for` jest wygodne, gdy znamy liczbę powtórzeń,
- pętle można zagnieżdżać,
- `break` kończy najbliższą pętlę,
- `continue` przechodzi do następnej iteracji,
- `int.TryParse` umożliwia bezpieczne sprawdzenie, czy podany tekst jest liczbą,
- menu i główna pętla gry działają aż do zmiany stanu kończącego program,
- licznik musi zmieniać się w kierunku, który prowadzi do zakończenia pętli.

## Ściąga

    while (warunek)
    {
        // instrukcje
    }

    do
    {
        // instrukcje
    }
    while (warunek);

    for (int i = 0; i < liczbaPowtorzen; i++)
    {
        // instrukcje
    }

    while (true)
    {
        Console.Write("Podaj liczbę: ");

        if (int.TryParse(Console.ReadLine(), out int liczba))
        {
            Console.WriteLine($"Podano: {liczba}");
            break;
        }

        Console.WriteLine("Niepoprawna wartość.");
    }
