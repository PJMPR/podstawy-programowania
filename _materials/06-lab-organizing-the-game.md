---
layout: material
title: "Porządkowanie gry za pomocą metod"
kind: lab
week: 6
summary: "Dzielimy rosnący program na małe metody z parametrami, wartościami zwracanymi i prostym zapisem strzałkowym."
published: true
content_ready: true
---

## Cel laboratorium

Uporządkuj kod gry bez zmiany jej zachowania. Przećwicz metody `void`, parametry, wartości zwracane, zasięg zmiennych i zapis `=>` dla krótkich metod.

Po laboratorium główna pętla programu powinna pokazywać przebieg rozgrywki, a szczegóły powinny znajdować się w małych, nazwanych metodach.


## Kod startowy

Możesz pracować na projekcie z tygodnia 5. Jeśli nie jest gotowy, zacznij od poniższego programu:

```csharp
string heroName = "Ada";
int health = 70;
int maxHealth = 100;
int gold = 15;
int strength = 6;
int weaponDamage = 3;
bool isRunning = true;

while (isRunning)
{
    Console.WriteLine("====================");
    Console.WriteLine($"Bohater: {heroName}");
    Console.WriteLine($"Zdrowie: {health}/{maxHealth}");
    Console.WriteLine($"Złoto: {gold}");
    Console.WriteLine("====================");
    Console.WriteLine("1. Atak treningowy");
    Console.WriteLine("2. Odpoczynek");
    Console.WriteLine("3. Koniec gry");
    Console.Write("Wybór: ");

    string? command = Console.ReadLine();

    if (command == "1")
    {
        int damage = strength + weaponDamage;
        Console.WriteLine($"Zadajesz {damage} obrażeń manekinowi.");
    }
    else if (command == "2")
    {
        health += 10;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        Console.WriteLine($"Odpoczywasz. Masz teraz {health} HP.");
    }
    else if (command == "3")
    {
        isRunning = false;
    }
    else
    {
        Console.WriteLine("Nieznana komenda.");
    }
}
```
<!-- code-result: Program działa interaktywnie. W każdej turze wyświetla status bohatera i trzy opcje. Atak pokazuje 9 obrażeń, odpoczynek zwiększa zdrowie maksymalnie do 100, a opcja 3 kończy grę. -->

> **Zasada refaktoryzacji:** po każdym zadaniu uruchom program. Zmieniamy organizację kodu, nie zachowanie gry.

## Zadanie 1. Rozgrzewka — przeczytaj sygnaturę

Dla każdej metody wskaż typ wyniku, nazwę i parametry. Następnie zapisz po jednym poprawnym wywołaniu.

```csharp
void ShowMessage(string text)
{
    Console.WriteLine(text);
}

int AddGold(int gold, int reward)
{
    return gold + reward;
}

bool HasEnoughGold(int gold, int price) => gold >= price;
```
<!-- code-result: Fragment tylko definiuje trzy metody. Przykładowo AddGold(10, 5) zwróci 15, a HasEnoughGold(10, 8) zwróci true. Bez wywołań konsola pozostaje bez zmian. -->

Odpowiedz:

1. Która metoda nie zwraca wartości?
2. Jakiego typu wynik zwraca `HasEnoughGold`?
3. Co jest argumentem w wywołaniu `AddGold(10, 5)`?
4. Gdzie można użyć wyniku `HasEnoughGold(10, 8)`?

## Zadanie 2. Wydziel wyświetlanie

> **Maciuś:** Usunąłem powtórzenia. Teraz `ShowMenu` ma 48 parametrów.
>
> **Jan:** Świetnie, stworzyłeś formularz podatkowy. Zostaw tylko dane, których metoda naprawdę potrzebuje.

Napisz metody:

```csharp
void ShowStatus(string name, int health, int maxHealth, int gold)
void ShowMenu()
void ShowPanelTitle(string title, ConsoleColor backgroundColor)
```
<!-- code-result: To wymagane sygnatury metod, a nie kompletny program. Nie generują wyniku i bez ciał metod nie mogą zostać skompilowane. -->

Wymagania:

- `ShowStatus` wyświetla imię, zdrowie i złoto,
- `ShowMenu` wyświetla trzy dostępne komendy,
- `ShowPanelTitle` nadaje nagłówkom wspólny wygląd,
- w pętli nie pozostają kopie instrukcji przeniesionych do metod,
- metody tylko wyświetlają dane — nie zmieniają stanu gry,
- po kolorowym fragmencie program wywołuje `Console.ResetColor()`.

Możesz użyć poniższego motywu lub dobrać własne kolory:

```csharp
void ShowPanelTitle(string title, ConsoleColor backgroundColor)
{
    Console.BackgroundColor = backgroundColor;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"  {title.ToUpper()}  ");
    Console.ResetColor();
}

void ShowStatus(string name, int health, int maxHealth, int gold)
{
    ShowPanelTitle("Status bohatera", ConsoleColor.DarkBlue);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Bohater:  ");
    Console.ResetColor();
    Console.WriteLine(name);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Zdrowie: ");
    Console.ResetColor();
    Console.WriteLine($"{health}/{maxHealth} HP");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Złoto:    ");
    Console.ResetColor();
    Console.WriteLine(gold);
}

void ShowMenu()
{
    ShowPanelTitle("Menu", ConsoleColor.DarkCyan);
    Console.WriteLine("[1] Atak treningowy");
    Console.WriteLine("[2] Odpoczynek");
    Console.WriteLine("[3] Koniec gry");
}
```
<!-- code-result: Fragment definiuje wspólny wygląd nagłówków, statusu i menu. Sam niczego nie wyświetla. Po wywołaniu ShowStatus("Ada", 70, 100, 15) i ShowMenu() pojawią się dwa kolorowe panele z danymi bohatera i trzema opcjami. -->

> **Dostępność:** nie przekazuj znaczenia wyłącznie kolorem. Tekst `Zdrowie`, `Złoto` i numery opcji powinny wystarczyć do zrozumienia ekranu także bez kolorów.

Po zmianie początek pętli powinien wyglądać mniej więcej tak:

```csharp
while (isRunning)
{
    ShowStatus(heroName, health, maxHealth, gold);
    ShowMenu();
    // dalsza część pętli
}
```
<!-- code-result: Początek każdej tury wyświetla kolorowy status i menu. Dalszy wynik zależy od kodu umieszczonego w miejscu komentarza. -->

## Zadanie 3. Metody zwracające wynik

> **Maciuś:** Wywołałem `Heal(health, 10, maxHealth)`, ale zdrowie się nie zmieniło.
>
> **Jan:** Automat wydał resztę, tylko odszedłeś bez jej zabrania. Zapisz wynik: `health = Heal(...)`.

Napisz i wykorzystaj trzy metody:

```csharp
int CalculateDamage(int strength, int weaponDamage)
int Heal(int health, int amount, int maxHealth)
bool IsGameOver(int health)
```
<!-- code-result: To wymagane sygnatury. Po zaimplementowaniu CalculateDamage(6, 3) ma zwracać 9, Heal(95, 10, 100) ma zwracać 100, a IsGameOver(0) ma zwracać true. -->

Reguły:

- obrażenia są sumą siły i obrażeń broni,
- leczenie nie może zwiększyć zdrowia powyżej `maxHealth`,
- gra jest zakończona, gdy zdrowie jest mniejsze lub równe zero,
- metody nie korzystają z `Console.ReadLine()` i nie wypisują wyniku.

Przykładowe użycie:

```csharp
int damage = CalculateDamage(strength, weaponDamage);
health = Heal(health, 10, maxHealth);

if (IsGameOver(health))
{
    Console.WriteLine("Koniec gry.");
}
```
<!-- code-result: damage otrzymuje sumę siły i obrażeń broni, a health wynik leczenia. Napis „Koniec gry.” pojawi się tylko wtedy, gdy IsGameOver(health) zwróci true. -->

### Szybkie testy

| Wywołanie | Oczekiwany wynik |
|---|---:|
| `CalculateDamage(6, 3)` | `9` |
| `CalculateDamage(0, 4)` | `4` |
| `Heal(70, 10, 100)` | `80` |
| `Heal(95, 10, 100)` | `100` |
| `IsGameOver(0)` | `true` |
| `IsGameOver(1)` | `false` |

## Zadanie 4. Walidacja komendy

Napisz metodę `string ReadCommand()`, która:

1. prosi użytkownika o komendę,
2. akceptuje tylko `"1"`, `"2"` lub `"3"`,
3. dla innej wartości wyświetla komunikat i ponawia pytanie,
4. zwraca poprawną komendę.

```csharp
string ReadCommand()
{
    while (true)
    {
        Console.Write("Wybór: ");
        string? command = Console.ReadLine();

        // Sprawdź command.
        // Jeśli jest poprawna, zwróć ją przez return.
        // W przeciwnym razie wyświetl komunikat.
    }
}
```
<!-- code-result: To nieukończony szablon metody. Po uzupełnieniu ma pytać o „Wybór:”, odrzucać wartości inne niż 1, 2 lub 3 i zwracać pierwszą poprawną komendę. -->

Przetestuj pusty tekst, `7`, `atak` oraz poprawne wartości `1`, `2` i `3`.

## Zadanie 5. Funkcje strzałkowe w praktyce

Przepisz na zapis `=>` tylko te metody, które składają się z jednego prostego wyrażenia.

```csharp
int CalculateDamage(int strength, int weaponDamage)
{
    return strength + weaponDamage;
}
```
<!-- code-result: Fragment definiuje metodę w zwykłej postaci. CalculateDamage(6, 3) zwróci 9, ale bez wywołania nic nie pojawi się w konsoli. -->

Po zmianie:

```csharp
int CalculateDamage(int strength, int weaponDamage) => strength + weaponDamage;
```
<!-- code-result: Krótszy zapis działa identycznie: CalculateDamage(6, 3) zwróci 9. Metoda niczego nie wypisuje. -->

Rozważ osobno:

- `CalculateDamage`,
- `IsGameOver`,
- `ShowMenu`,
- `ReadCommand`,
- `Heal`.

Nie każda metoda powinna zostać skrócona. Zapisz przy każdej decyzji jednozdaniowe uzasadnienie.

> **Wskazówka:** `=>` ma skracać prosty kod, a nie ukrywać skomplikowany kod.

### Jedna prawdziwa lambda

W projekcie z tygodnia 5 masz już listy. Użyj krótkiej lambdy, aby znaleźć elementy spełniające warunek:

```csharp
List<string> inventory = new List<string> { "miecz", "mikstura", "łuk" };

List<string> longNames = inventory.FindAll(item => item.Length > 5);
bool hasPotion = inventory.Exists(item => item == "mikstura");
```
<!-- code-result: longNames zawiera: mikstura
hasPotion ma wartość: true

Fragment nie wypisuje wyników — trzeba użyć Console.WriteLine lub pętli, aby zobaczyć je w konsoli. -->

Wyświetl wyniki, a następnie zmień warunki tak, aby:

1. znaleźć nazwy mające co najmniej 5 znaków,
2. sprawdzić, czy ekwipunek zawiera `"miecz"`.

Nie zapisuj całej logiki gry w lambdzie. Tutaj lambda jest tylko krótkim, jednorazowym pytaniem zadanym każdemu elementowi listy.

## Zadanie 6. Uporządkuj główną pętlę

Zrefaktoryzuj program tak, aby pętla przedstawiała ogólny przebieg gry:

```csharp
while (isRunning)
{
    ShowStatus(heroName, health, maxHealth, gold);
    ShowMenu();
    string command = ReadCommand();

    if (command == "1")
    {
        int damage = CalculateDamage(strength, weaponDamage);
        Console.WriteLine($"Zadajesz {damage} obrażeń manekinowi.");
    }
    else if (command == "2")
    {
        health = Heal(health, 10, maxHealth);
        Console.WriteLine($"Odpoczywasz. Masz teraz {health} HP.");
    }
    else
    {
        isRunning = false;
    }
}
```
<!-- code-result: Program pokazuje w każdej turze status i menu. Komenda 1 wyświetla 9 obrażeń, komenda 2 leczy bohatera, a komenda 3 kończy pętlę. Dokładny przebieg zależy od wyborów użytkownika. -->

Przenieś do metod także wyświetlanie ekwipunku i historii akcji z projektu z tygodnia 5, jeśli znajdują się w twojej grze.

Sprawdź, czy:

- główna pętla nie zawiera zduplikowanych bloków wyświetlania,
- metoda obliczeniowa nie czyta danych z konsoli,
- każda metoda ma nazwę odpowiadającą jednej czynności,
- stan gry zmienia się tylko tam, gdzie jest to potrzebne.

## Zadanie 7. Polowanie na błędy juniora

Znajdź błąd lub problem projektowy w każdym fragmencie i zaproponuj poprawę.

### A. Wynik, który przepada

```csharp
int Heal(int health, int amount) => health + amount;
Heal(health, 10);
```
<!-- code-result: Heal oblicza nową wartość, ale wynik przepada. Konsola niczego nie wyświetla, a health pozostaje bez zmian. Poprawa: health = Heal(health, 10); -->

### B. Zmienna poza zasięgiem

```csharp
if (health < 20)
{
    string warning = "Mało zdrowia!";
}

Console.WriteLine(warning);
```
<!-- code-result: Kod nie skompiluje się. Zmienna warning istnieje tylko wewnątrz bloku if i jest niedostępna w Console.WriteLine(warning). -->

### C. Metoda orkiestra

```csharp
int CalculateDamage(int strength, int weaponDamage)
{
    Console.Write("Czy chcesz zaatakować? ");
    string? answer = Console.ReadLine();
    Console.WriteLine("Rozpoczynam animację ataku...");
    return strength + weaponDamage;
}
```
<!-- code-result: Po wywołaniu metoda pyta użytkownika o atak, wyświetla komunikat o animacji i zwraca sumę parametrów. Problem projektowy: metoda obliczeniowa jednocześnie obsługuje wejście i wyjście. -->

### D. Strzałka za wszelką cenę

```csharp
bool CanHeal(int health, int maxHealth, int potions) =>
    health < maxHealth && potions > 0 && health > 0;
```
<!-- code-result: Metoda niczego nie wypisuje. Zwraca true tylko wtedy, gdy bohater żyje, nie ma pełnego zdrowia i posiada co najmniej jedną miksturę. -->

Czy D jest błędem? Porównaj wersję strzałkową z blokiem `{ }`. Wybierz czytelniejszy zapis i uzasadnij wybór. Możliwa jest więcej niż jedna dobra odpowiedź.

## Zadanie dodatkowe

Dodaj metody:

```csharp
bool CanAfford(int gold, int price)
int BuyItem(int gold, int price)
```
<!-- code-result: To wymagane sygnatury metod. Bez ciał kod nie zostanie skompilowany. Przykładowo CanAfford(15, 10) powinno zwrócić true, a BuyItem(15, 10) wartość 5. -->

- `CanAfford` zwraca informację, czy gracz ma wystarczająco dużo złota.
- `BuyItem` zwraca stan złota po zakupie.
- Program nie może dopuścić do zakupu, jeśli brakuje złota.
- Co najmniej jedną metodę zapisz za pomocą `=>`, o ile pozostaje czytelna.

Przygotuj testy dla ceny mniejszej, równej i większej od posiadanego złota.

## Kryteria ukończenia

- [ ] Program zawiera metody `void` i metody zwracające wartość.
- [ ] Parametry mają odpowiednie typy i czytelne nazwy.
- [ ] Zwracane wartości są zapisywane lub świadomie używane.
- [ ] Logika obliczeń nie wymaga bezpośredniego odczytu z konsoli.
- [ ] `ReadCommand` nie kończy się, dopóki nie otrzyma poprawnej komendy.
- [ ] Co najmniej jedna prosta metoda korzysta z czytelnego zapisu `=>`.
- [ ] Program używa krótkiej lambdy z `FindAll` lub `Exists`.
- [ ] Złożone metody zachowują blok `{ }`.
- [ ] Po refaktoryzacji zachowanie gry pozostało poprawne.

## Pytania na zakończenie

1. Dlaczego `Heal` zwraca nowe zdrowie zamiast tylko zmieniać parametr?
2. Co zyskujemy, oddzielając obliczenia od `Console.WriteLine()`?
3. Która metoda w rozwiązaniu ma najwięcej odpowiedzialności? Czy można ją jeszcze podzielić?
4. Kiedy zapis `=>` poprawia czytelność, a kiedy ją pogarsza?

> **Granica materiału:** nie używaj `ref`, `out` ani zmiennych globalnych jako sposobu przekazywania każdego wyniku. Nie omawiamy jeszcze teorii delegatów; zapis `=>` ćwiczymy na prostych metodach i krótkich warunkach przekazywanych do operacji na liście.
