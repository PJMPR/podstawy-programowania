---
layout: material
title: "Pierwszy program w C#"
kind: lecture
week: 1
summary: "Czym jest program i instrukcja, uruchamianie kodu, Console.WriteLine, Console.ReadLine oraz podstawowe typy danych."
published: true
content_ready: true
---

## Cel wykładu

Na tym wykładzie przejdziemy od pomysłu **„komputer wykonuje polecenia”** do pierwszych interaktywnych programów konsolowych w C#. Zobaczymy, jak kod źródłowy staje się działającym programem, jak komunikować się z użytkownikiem oraz jak przechowywać proste dane.

Po wykładzie student powinien:

- wyjaśnić, czym są program, kod źródłowy i instrukcja,
- uruchomić program konsolowy w C#,
- wyświetlać tekst i wartości za pomocą `Console.WriteLine`,
- pobierać tekst za pomocą `Console.ReadLine`,
- rozpoznawać i stosować typy `string`, `char`, `int`, `double`, `decimal` i `bool`,
- deklarować zmienne oraz nadawać im wartości,
- wskazać kilka typowych błędów początkującego programisty.

> **Plan na 90 minut:** wprowadzenie — 10 min, uruchamianie kodu — 15 min, wyjście programu — 15 min, zmienne i typy — 25 min, wejście programu — 15 min, wspólny przykład i podsumowanie — 10 min.

---

## 1. Czym jest program? (0–10 min)

**Program komputerowy** to uporządkowany zestaw instrukcji opisujących, co komputer ma zrobić. Instrukcje zapisujemy w języku programowania — na tym kursie będzie nim **C#**.

Komputer wykonuje polecenia bardzo dokładnie, ale nie domyśla się naszych intencji. Jeśli polecenie jest niepoprawne albo niepełne, program nie zadziała lub da wynik inny od oczekiwanego.

### Program jako przepis

Możemy porównać program do przepisu:

1. pobierz dane,
2. wykonaj obliczenia,
3. pokaż wynik.

```text
Zapytaj użytkownika o imię.
Zapamiętaj odpowiedź.
Wyświetl powitanie zawierające podane imię.
```

Ten sam pomysł w C#:

```csharp
Console.Write("Jak masz na imię? ");
string imie = Console.ReadLine()!;
Console.WriteLine($"Cześć, {imie}!");
```

### Instrukcja

**Instrukcja** to pojedyncze polecenie programu. W C# większość instrukcji kończymy średnikiem `;`.

```csharp
Console.WriteLine("Pierwsza instrukcja");
Console.WriteLine("Druga instrukcja");
Console.WriteLine("Trzecia instrukcja");
```

Program wykonuje je kolejno, od góry do dołu.

> **Pytanie do sali:** Co pojawi się jako pierwsze, jeśli zamienimy miejscami pierwszą i trzecią instrukcję?

### Kod źródłowy a działający program

Kod zapisany przez programistę nazywamy **kodem źródłowym**. Pliki C# mają rozszerzenie `.cs`. Zanim komputer wykona kod, narzędzia platformy .NET muszą go sprawdzić i przekształcić do postaci możliwej do uruchomienia.

```text
kod C# → kompilacja → program → wykonanie → wynik
```

---

## 2. Pierwszy projekt i uruchamianie kodu (10–25 min)

Najprostszy projekt konsolowy można utworzyć w środowisku programistycznym albo w terminalu:

```bash
dotnet new console -n PierwszyProgram
cd PierwszyProgram
dotnet run
```

- `dotnet new console` tworzy projekt aplikacji konsolowej,
- `-n PierwszyProgram` nadaje projektowi nazwę,
- `cd` przechodzi do katalogu projektu,
- `dotnet run` kompiluje i uruchamia program.

W pliku `Program.cs` zobaczymy kod podobny do tego:

```csharp
Console.WriteLine("Hello, World!");
```

Współczesny C# pozwala pisać takie krótkie programy bez ręcznego tworzenia klasy `Program` i metody `Main`. Są to **instrukcje najwyższego poziomu**. W starszych materiałach ten sam program może wyglądać tak:

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
    }
}
```

Na początku kursu będziemy korzystać z krótszego zapisu. Oba warianty prowadzą do tego samego efektu.

### Co dzieje się po wybraniu „Uruchom”?

1. Edytor zapisuje kod źródłowy.
2. Kompilator sprawdza składnię i typy.
3. Jeśli nie ma błędów kompilacji, powstaje program.
4. Środowisko .NET uruchamia program.
5. Wynik pojawia się w konsoli.

### Trzy rodzaje problemów

**Błąd kompilacji** — kod narusza reguły języka:

```csharp
Console.WriteLine("Brakuje średnika")
```

**Błąd wykonania** — program się uruchamia, ale podczas pracy występuje problem:

```csharp
int liczba = int.Parse("kot");
Console.WriteLine(liczba);
```

**Błąd logiczny** — program działa, ale daje zły wynik:

```csharp
int cena = 20;
int liczbaSztuk = 3;
int koszt = cena + liczbaSztuk; // powinno być mnożenie
Console.WriteLine(koszt);
```

> **Demonstracja:** uruchom kolejno każdy przykład. Poproś studentów, aby opisali różnicę między komunikatem kompilatora, przerwaniem działania i niepoprawnym wynikiem.

---

## 3. Wyświetlanie danych — `Console.WriteLine` i `Console.Write` (25–40 min)

Klasa `Console` pozwala programowi komunikować się z użytkownikiem w konsoli. Metoda `WriteLine` wyświetla wartość i przechodzi do nowego wiersza.

```csharp
Console.WriteLine("Witaj na kursie C#!");
Console.WriteLine("To jest drugi wiersz.");
Console.WriteLine(2026);
Console.WriteLine(3.14);
Console.WriteLine(true);
```

Metoda `Write` nie przechodzi do nowego wiersza:

```csharp
Console.Write("Ala ");
Console.Write("ma ");
Console.Write("kota.");
```

Wynik: `Ala ma kota.`

### Tekst i znaki specjalne

```csharp
Console.WriteLine("Powiedział: \"Dzień dobry!\"");
Console.WriteLine("Pierwszy wiersz\nDrugi wiersz");
Console.WriteLine("Kolumna 1\tKolumna 2");
Console.WriteLine("C:\\projekty\\program.cs");
```

| Zapis | Znaczenie |
|---|---|
| `\n` | nowy wiersz |
| `\t` | tabulator |
| `\"` | cudzysłów w tekście |
| `\\` | odwrotny ukośnik |

### Łączenie i interpolacja tekstu

```csharp
string imie = "Ola";
int wiek = 20;

Console.WriteLine("Mam na imię " + imie + ".");
Console.WriteLine("Mam " + wiek + " lat.");
Console.WriteLine($"Mam na imię {imie} i mam {wiek} lat.");
Console.WriteLine($"Za rok będę mieć {wiek + 1} lat.");
```

Przed interpolowanym tekstem stawiamy `$`, a wartości umieszczamy w `{}`.

> **Minićwiczenie:** Wyświetl wizytówkę składającą się z trzech wierszy: imienia, kierunku studiów i ulubionej gry.

```csharp
string imie = "Maja";
string kierunek = "Informatyka";
string gra = "Minecraft";

Console.WriteLine("=== WIZYTÓWKA ===");
Console.WriteLine($"Imię: {imie}");
Console.WriteLine($"Kierunek: {kierunek}");
Console.WriteLine($"Ulubiona gra: {gra}");
```

---

## 4. Dane, wartości i zmienne (40–50 min)

Programy operują na danych. **Zmienna** jest nazwaną przestrzenią, w której program przechowuje wartość określonego typu.

```csharp
string nazwaGracza = "Ada";
int punkty = 100;
bool graTrwa = true;
```

```text
typ      nazwa           wartość
 ↓         ↓                ↓
int liczbaPunktow = 100;
```

Wartość zmiennej może się zmienić:

```csharp
int punkty = 10;
Console.WriteLine(punkty);

punkty = 25;
Console.WriteLine(punkty);
```

Przy ponownym przypisaniu nie podajemy już typu:

```csharp
int punkty = 10;
// int punkty = 25; // błąd: taka zmienna już istnieje
punkty = 25;        // poprawnie: zmiana wartości
```

### Nazwy zmiennych

```csharp
int liczbaStudentow = 24;
double temperaturaCiala = 36.6;
bool czyZalogowany = false;
```

Dobra nazwa informuje, co przechowuje zmienna. W C# wielkość liter ma znaczenie. `wiek`, `Wiek` i `WIEK` to różne nazwy. Dla zmiennych stosujemy zwykle zapis **camelCase**, np. `liczbaPunktow`.

---

## 5. Podstawowe typy danych (50–65 min)

Typ określa, jakie wartości można przechowywać oraz jakie operacje można na nich wykonywać.

| Typ | Przykładowa wartość | Zastosowanie |
|---|---:|---|
| `string` | `"Ala"` | tekst |
| `char` | `'A'` | pojedynczy znak |
| `int` | `42` | liczby całkowite |
| `long` | `8_000_000_000L` | duże liczby całkowite |
| `double` | `3.14` | liczby z częścią ułamkową |
| `decimal` | `19.99m` | dokładne wartości dziesiętne, np. pieniądze |
| `bool` | `true` | prawda albo fałsz |

### `string` — tekst

```csharp
string tytul = "Podstawy programowania";
string pustyTekst = "";
string liczbaJakoTekst = "123";

Console.WriteLine(tytul);
Console.WriteLine(liczbaJakoTekst + 1); // 1231, a nie 124
```

### `char` — pojedynczy znak

```csharp
char pierwszaLitera = 'A';
char symbol = '#';
char cyfraJakoZnak = '7';

string slowo = "A"; // tekst zawierający jeden znak
char znak = 'A';     // pojedynczy znak
```

### `int` i `long` — liczby całkowite

```csharp
int rok = 2026;
int temperatura = -5;
int milion = 1_000_000;
long liczbaMieszkancowZiemi = 8_000_000_000L;

Console.WriteLine($"Rok: {rok}");
```

### `double` — liczba zmiennoprzecinkowa

W kodzie część ułamkową oddzielamy **kropką**, niezależnie od języka systemu:

```csharp
double wzrost = 1.78;
double temperatura = 21.5;
double pi = 3.141592653589793;

Console.WriteLine($"Wzrost: {wzrost} m");
```

### `decimal` — wartości dziesiętne

`decimal` jest często używany dla kwot. Litera `m` oznacza wartość typu `decimal`:

```csharp
decimal cena = 19.99m;
decimal stanKonta = 1250.50m;

Console.WriteLine($"Cena: {cena} zł");
```

### `bool` — prawda lub fałsz

```csharp
bool padaDeszcz = true;
bool jestKoniecGry = false;

Console.WriteLine($"Czy pada? {padaDeszcz}");
```

### Typ ma znaczenie

```csharp
int liczba = 10;
string tekst = "10";

Console.WriteLine(liczba + 5); // 15
Console.WriteLine(tekst + 5);  // 105
```

Nie każdą wartość można przypisać do dowolnego typu:

```csharp
int wiek = 20;
// wiek = "dwadzieścia"; // błąd kompilacji
```

> **Pytanie do sali:** Jakiego typu użylibyście dla imienia, liczby punktów, ceny biletu, znaku gracza na planszy i informacji, czy drzwi są otwarte?

---

## 6. Pobieranie danych — `Console.ReadLine` (65–80 min)

`Console.ReadLine()` zatrzymuje program, czeka na wpisanie tekstu i naciśnięcie Enter, a następnie zwraca wpisaną wartość.

```csharp
Console.Write("Podaj swoje imię: ");
string imie = Console.ReadLine()!;

Console.WriteLine($"Witaj, {imie}!");
```

Znak `!` po `ReadLine()` informuje kompilator, że w tym prostym programie zakładamy otrzymanie tekstu. Obsługę braku wartości poznamy później.

### Kilka pytań

```csharp
Console.Write("Jak masz na imię? ");
string imie = Console.ReadLine()!;

Console.Write("Jaki jest Twój ulubiony kolor? ");
string kolor = Console.ReadLine()!;

Console.WriteLine($"Cześć, {imie}!");
Console.WriteLine($"Twój ulubiony kolor to {kolor}.");
```

### `ReadLine` zawsze daje tekst

Nawet gdy użytkownik wpisze `25`, `Console.ReadLine()` zwraca `string`. Aby wykonać obliczenia, musimy zamienić tekst na liczbę.

```csharp
Console.Write("Podaj wiek: ");
string wpisanyTekst = Console.ReadLine()!;
int wiek = int.Parse(wpisanyTekst);

Console.WriteLine($"Za rok będziesz mieć {wiek + 1} lat.");
```

Krótszy zapis:

```csharp
Console.Write("Podaj rok urodzenia: ");
int rokUrodzenia = int.Parse(Console.ReadLine()!);

int przyblizonyWiek = 2026 - rokUrodzenia;
Console.WriteLine($"Masz około {przyblizonyWiek} lat.");
```

Jeżeli użytkownik wpisze tekst, którego nie da się zamienić na liczbę, program zakończy się błędem. Bezpieczną walidację danych poznamy później.

### Odczyt liczby ułamkowej

```csharp
Console.Write("Podaj swój wzrost w metrach: ");
double wzrost = double.Parse(Console.ReadLine()!);

Console.WriteLine($"Podany wzrost: {wzrost} m");
```

Separator dziesiętny zależy od ustawień systemu. W polskiej konfiguracji użytkownik zwykle wpisuje `1,75`, mimo że w kodzie literał zapisujemy jako `1.75`.

### Prosty kalkulator sumy

```csharp
Console.Write("Podaj pierwszą liczbę: ");
int pierwszaLiczba = int.Parse(Console.ReadLine()!);

Console.Write("Podaj drugą liczbę: ");
int drugaLiczba = int.Parse(Console.ReadLine()!);

int suma = pierwszaLiczba + drugaLiczba;
Console.WriteLine($"{pierwszaLiczba} + {drugaLiczba} = {suma}");
```

> **Minićwiczenie:** Zmień kalkulator tak, aby obliczał pole prostokąta na podstawie boków podanych przez użytkownika.

```csharp
Console.Write("Podaj długość pierwszego boku: ");
double bokA = double.Parse(Console.ReadLine()!);

Console.Write("Podaj długość drugiego boku: ");
double bokB = double.Parse(Console.ReadLine()!);

double pole = bokA * bokB;
Console.WriteLine($"Pole prostokąta wynosi {pole}.");
```

---

## 7. Wspólny przykład — karta bohatera (80–87 min)

Zbudujmy mały program wykorzystujący wejście, wyjście, zmienne i kilka typów danych.

```csharp
Console.WriteLine("=== KREATOR BOHATERA ===");

Console.Write("Podaj imię bohatera: ");
string imie = Console.ReadLine()!;

Console.Write("Podaj klasę postaci: ");
string klasaPostaci = Console.ReadLine()!;

Console.Write("Podaj poziom bohatera: ");
int poziom = int.Parse(Console.ReadLine()!);

Console.Write("Podaj liczbę punktów życia: ");
double punktyZycia = double.Parse(Console.ReadLine()!);

char symbol = '@';
bool aktywny = true;

Console.WriteLine();
Console.WriteLine("=== KARTA BOHATERA ===");
Console.WriteLine($"Imię: {imie}");
Console.WriteLine($"Klasa: {klasaPostaci}");
Console.WriteLine($"Poziom: {poziom}");
Console.WriteLine($"Punkty życia: {punktyZycia}");
Console.WriteLine($"Symbol na mapie: {symbol}");
Console.WriteLine($"Aktywny: {aktywny}");
```

Przykładowe uruchomienie:

```text
=== KREATOR BOHATERA ===
Podaj imię bohatera: Luna
Podaj klasę postaci: Mag
Podaj poziom bohatera: 3
Podaj liczbę punktów życia: 75,5

=== KARTA BOHATERA ===
Imię: Luna
Klasa: Mag
Poziom: 3
Punkty życia: 75,5
Symbol na mapie: @
Aktywny: True
```

> **Rozwinięcie na żywo:** dodaj pytanie o liczbę monet typu `decimal`, ulubioną literę typu `char` albo rok rozpoczęcia przygody typu `int`.

---

## 8. Podsumowanie i pytania kontrolne (87–90 min)

- program jest uporządkowanym zestawem instrukcji,
- instrukcje C# są wykonywane kolejno i zwykle kończą się średnikiem,
- `Console.WriteLine` wyświetla dane i przechodzi do nowego wiersza,
- `Console.Write` pozostawia kursor w tym samym wierszu,
- `Console.ReadLine` pobiera od użytkownika tekst,
- zmienna ma typ, nazwę i wartość,
- typ mówi, jakie dane można przechowywać i jak można ich używać,
- tekst pobrany z konsoli trzeba przekonwertować, zanim użyjemy go jak liczby.

### Pytania kontrolne

1. Czym różni się kod źródłowy od uruchomionego programu?
2. Po co instrukcje kończymy średnikiem?
3. Czym różnią się `Console.Write` i `Console.WriteLine`?
4. Jaki typ wybierzesz dla ceny, a jaki dla liczby studentów?
5. Dlaczego `"20" + 5` nie daje wyniku `25`?
6. Jak pobrać od użytkownika liczbę całkowitą?
7. Czym różnią się `"A"` i `'A'`?

### Krótkie zadanie na zakończenie

Napisz program, który pyta o tytuł filmu, rok premiery oraz ocenę w skali od 1 do 10, a następnie wyświetla czytelne podsumowanie.

```csharp
Console.Write("Podaj tytuł filmu: ");
string tytul = Console.ReadLine()!;

Console.Write("Podaj rok premiery: ");
int rokPremiery = int.Parse(Console.ReadLine()!);

Console.Write("Podaj ocenę: ");
double ocena = double.Parse(Console.ReadLine()!);

Console.WriteLine();
Console.WriteLine($"Film: {tytul}");
Console.WriteLine($"Rok premiery: {rokPremiery}");
Console.WriteLine($"Ocena: {ocena}/10");
```

## Ściąga

```csharp
// Wyświetlanie
Console.Write("bez nowego wiersza");
Console.WriteLine("z nowym wierszem");

// Podstawowe typy i zmienne
string tekst = "Cześć";
char znak = 'A';
int liczbaCalkowita = 42;
double liczbaUlamek = 3.14;
decimal kwota = 19.99m;
bool prawdaLubFalsz = true;

// Pobieranie danych
string odpowiedz = Console.ReadLine()!;
int liczba = int.Parse(Console.ReadLine()!);
double wartosc = double.Parse(Console.ReadLine()!);

// Interpolacja tekstu
Console.WriteLine($"Odpowiedź: {odpowiedz}, liczba: {liczba}");
```
