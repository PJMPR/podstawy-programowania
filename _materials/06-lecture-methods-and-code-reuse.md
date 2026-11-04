---
layout: material
title: "Metody — organizacja i ponowne wykorzystanie kodu"
kind: lecture
week: 6
summary: "Definiowanie metod, parametry, wartości zwracane, zasięg zmiennych, zapis strzałkowy, proste lambdy i podział programu na mniejsze części."
published: true
content_ready: true
---

## Cel wykładu

Rosnący program trudno rozwijać jako jeden długi blok. Metody pozwalają nazwać operacje, ograniczyć powtórzenia i rozdzielić większy problem na mniejsze kroki.

Po wykładzie potrafisz:

- definiować i wywoływać metody `void`,
- przekazywać dane przez parametry,
- zwracać wyniki za pomocą `return`,
- rozpoznawać zasięg zmiennej,
- dzielić kod według odpowiedzialności,
- zapisać bardzo krótką metodę jako funkcję strzałkową,
- wykorzystać prostą lambdę do filtrowania znanej już listy.

> **Cel praktyczny:** po refaktoryzacji główna część programu ma przypominać plan gry, a nie instrukcję składania szafy bez obrazków.

W przykładach będą nam towarzyszyć:

- **Maciuś Pierwszy — junior programista**, pełen pomysłów i odrobiny zbyt dużej wiary w kopiowanie kodu,
- **Jan Kowalski — senior programista**, który widział już niejeden `Method1` i nadal zachował poczucie humoru.

## 1. Kiedy kod zaczyna prosić o metodę?

> **Maciuś:** Skopiowałem ten kod tylko cztery razy. To jeszcze nie jest powtórzenie, prawda?
>
> **Jan:** Oczywiście. To cztery niezależne egzemplarze tego samego błędu.

```csharp
Console.WriteLine("====================");
Console.WriteLine($"Bohater: {heroName}");
Console.WriteLine($"Zdrowie: {health}");
Console.WriteLine($"Złoto: {gold}");
Console.WriteLine("====================");
```
<!-- code-result: Przykładowy wynik (dla heroName = "Ada", health = 70, gold = 15):
====================
Bohater: Ada
Zdrowie: 70
Złoto: 15
==================== -->

Jeśli taki blok występuje w kilku miejscach, trzeba go kopiować. Każda późniejsza zmiana wymaga poprawienia wszystkich kopii. Możemy zamiast tego nadać operacji nazwę:

```csharp
void ShowStatus(string heroName, int health, int gold)
{
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("  STATUS BOHATERA  ");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Bohater:  ");
    Console.ResetColor();
    Console.WriteLine(heroName);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Zdrowie: ");
    Console.ResetColor();
    Console.WriteLine($"{health} HP");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Złoto:    ");
    Console.ResetColor();
    Console.WriteLine(gold);
}

ShowStatus(heroName, health, gold);
```
<!-- code-result: Wywołanie wyświetla kolorowy panel statusu. Dla wartości "Ada", 70 i 15 treść wygląda tak:
STATUS BOHATERA
Bohater:  Ada
Zdrowie: 70 HP
Złoto:    15 -->

Metodę warto wydzielić, gdy fragment:

- powtarza się,
- wykonuje jedną, dającą się nazwać czynność,
- jest długi i zasłania główny przebieg programu,
- przyda się do sprawdzenia niezależnie od reszty gry.

## 2. Anatomia metody

```csharp
void ShowMessage(string message)
{
    Console.BackgroundColor = ConsoleColor.DarkCyan;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" INFO ");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("  »  ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(message);
    Console.ResetColor();
}
```
<!-- code-result: Ten fragment tylko definiuje metodę ShowMessage. Dopóki metoda nie zostanie wywołana, konsola pozostaje bez zmian. -->

| Element | Przykład | Znaczenie |
|---|---|---|
| typ wyniku | `void` | metoda nie zwraca wartości |
| nazwa | `ShowMessage` | opisuje wykonywaną czynność |
| parametr | `string message` | dane potrzebne metodzie |
| ciało | `{ ... }` | instrukcje wykonywane po wywołaniu |

Sama definicja nie uruchamia metody. Kod wykona się dopiero po wywołaniu:

```csharp
ShowMessage("Wchodzisz do lochu.");
ShowMessage("Słyszysz podejrzane chrupanie.");
```
<!-- code-result: INFO   »  Wchodzisz do lochu.
INFO   »  Słyszysz podejrzane chrupanie.

Etykieta INFO ma ciemnoturkusowe tło, strzałka jest turkusowa, a treść biała. -->

Na ekranie obie wiadomości mają ten sam szablon:

```text
 INFO   »  Wchodzisz do lochu.
 INFO   »  Słyszysz podejrzane chrupanie.
```

Etykieta `INFO` ma ciemnoturkusowe tło, strzałka jest turkusowa, a treść biała. Metoda odpowiada za cały wygląd komunikatu, więc kod wywołujący przekazuje wyłącznie tekst. Późniejsza zmiana kolorów lub symbolu wymaga poprawienia tylko jednego miejsca.

Program przechodzi do ciała metody, wykonuje je, a następnie wraca do miejsca wywołania.

Nazwy metod zapisujemy w C# w stylu `PascalCase`. Dobra nazwa mówi, co metoda robi: `ShowMenu`, `ReadCommand`, `CalculateDamage`. Nazwy `DoIt`, `Thing` i `Method1` są poprawne dla kompilatora, ale nie dla człowieka, który wróci do projektu za tydzień. Tym człowiekiem bardzo często jesteś ty.

### Prosty szablon wyglądu konsoli

Powtarzalny wygląd także warto zamknąć w metodzie. Dzięki temu wszystkie panele mają ten sam nagłówek, a zmiana koloru nie wymaga poprawiania wielu miejsc.

```csharp
void ShowPanelTitle(string title, ConsoleColor backgroundColor)
{
    Console.BackgroundColor = backgroundColor;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"  {title.ToUpper()}  ");
    Console.ResetColor();
}

void ShowMenu()
{
    ShowPanelTitle("Menu", ConsoleColor.DarkCyan);
    Console.WriteLine("[1] Atak");
    Console.WriteLine("[2] Leczenie");
    Console.WriteLine("[3] Koniec gry");
}
```
<!-- code-result: Fragment tylko definiuje metodę. Po wywołaniu ShowMenu() konsola wyświetli:
1. Atak
2. Leczenie
3. Ucieczka -->
<!-- code-result: Ten fragment definiuje ShowPanelTitle i ShowMenu. Samo zdefiniowanie metod niczego nie wyświetla. Po wywołaniu ShowMenu() pojawi się kolorowy nagłówek MENU oraz trzy opcje. -->

`Console.ForegroundColor` ustawia kolor liter, a `Console.BackgroundColor` kolor tła. `Console.ResetColor()` przywraca ustawienia terminala. Wywołuj je po kolorowym fragmencie, aby reszta programu nie odziedziczyła przypadkowego stylu.

Kolor jest dodatkiem do czytelnego tekstu, nie jego zamiennikiem. Numery opcji, etykiety i komunikaty powinny być zrozumiałe również w terminalu, który nie pokazuje kolorów.

## 3. Parametry i argumenty

> **Maciuś:** Metoda nie widziała zmiennej `health`, więc zrobiłem drugą zmienną globalną.
>
> **Jan:** A gdy nie znajdziesz kluczy, dorabiasz drugie drzwi? Przekaż `health` jako parametr.

Parametr jest nazwą danych w definicji metody. Argument jest konkretną wartością przekazaną podczas wywołania.

```csharp
void ShowStatus(string name, int health)
{
    Console.WriteLine($"{name}: {health} HP");
}

ShowStatus("Ada", 80);
```
<!-- code-result: Ada: 80 HP -->

`name` i `health` są parametrami, a `"Ada"` i `80` argumentami. Kolejność oraz typ argumentów muszą pasować do parametrów:

```csharp
ShowStatus("Ada", 80); // poprawnie
// ShowStatus(80, "Ada"); // błąd: niewłaściwa kolejność typów
```
<!-- code-result: Pierwsze wywołanie wyświetla:
Ada: 80 HP

Drugie jest komentarzem. Po usunięciu // kompilator zgłosi błąd, ponieważ argumenty mają niewłaściwe typy i kolejność. -->

Parametry pozwalają użyć tej samej metody dla różnych danych:

```csharp
ShowStatus("Ada", 80);
ShowStatus("Goblin", 35);
```
<!-- code-result: Ada: 80 HP
Goblin: 35 HP -->

## 4. `void` czy wartość zwracana?

> **Maciuś:** Moja metoda `CalculateDamage` wypisuje wynik, odejmuje zdrowie i jeszcze pyta, czy zaatakować ponownie.
>
> **Jan:** To nie metoda. To jednoosobowy dział firmy bez zakresu obowiązków.

Metoda `void` wykonuje czynność, ale nie daje wywołującemu wyniku:

```csharp
void ShowMenu()
{
    Console.WriteLine("1. Atak");
    Console.WriteLine("2. Leczenie");
    Console.WriteLine("3. Ucieczka");
}
```

Metoda obliczająca wynik określa jego typ i używa `return`:

```csharp
int CalculateDamage(int strength, int weaponDamage)
{
    int damage = strength + weaponDamage;
    return damage;
}

int damage = CalculateDamage(5, 3);
enemyHealth -= damage;
```
<!-- code-result: CalculateDamage(5, 3) zwraca 8. Zmienna damage otrzymuje wartość 8, a enemyHealth zostaje zmniejszone o 8. Fragment niczego nie wypisuje. -->

`return` kończy działanie metody. Każda możliwa ścieżka metody zwracającej wartość musi zwrócić odpowiedni typ.

### Wczesny `return`

```csharp
int Heal(int health, int amount, int maxHealth)
{
    if (amount <= 0)
    {
        return health;
    }

    int newHealth = health + amount;
    return Math.Min(newHealth, maxHealth);
}
```
<!-- code-result: Fragment definiuje metodę Heal. Przykładowo Heal(95, 10, 100) zwróci 100, ale sama definicja niczego nie wyświetla. -->

Wczesny `return` obsługuje szczególny przypadek bez dodatkowego zagnieżdżania.

## 5. Jedna odpowiedzialność i przepływ danych

Metoda powinna mieć jedno główne zadanie. Szczególnie warto oddzielać:

- wejście — np. `ReadCommand`,
- logikę — np. `CalculateDamage`,
- wyjście — np. `ShowStatus`.

```csharp
int CalculateDamage(int strength, int weaponDamage)
{
    return strength + weaponDamage;
}

int damage = CalculateDamage(strength, weaponDamage);
enemyHealth -= damage;
Console.WriteLine($"Zadajesz {damage} obrażeń.");
```
<!-- code-result: Dla strength = 5 i weaponDamage = 3:
Zadajesz 8 obrażeń. -->

Metoda licząca obrażenia nie pyta o dane i niczego nie wypisuje. Dostaje potrzebne wartości i zwraca wynik. Można ją łatwo sprawdzić:

```csharp
Console.WriteLine(CalculateDamage(5, 3)); // oczekujemy 8
Console.WriteLine(CalculateDamage(0, 4)); // oczekujemy 4
```
<!-- code-result: 8
4 -->

## 6. Zasięg zmiennych

Zmienna lokalna istnieje tylko w bloku, w którym została zadeklarowana:

```csharp
int CalculateDamage(int strength, int weaponDamage)
{
    int damage = strength + weaponDamage;
    return damage;
}

// Console.WriteLine(damage); // błąd: tutaj damage nie istnieje
```
<!-- code-result: Metoda zostaje zdefiniowana, ale niczego nie wypisuje. Po odkomentowaniu ostatniej linii kompilator zgłosi błąd zasięgu: damage nie istnieje poza metodą. -->

Parametry również są lokalne dla metody. Dwie metody mogą mieć parametr o tej samej nazwie i nie jest to ta sama zmienna.

```csharp
void ShowHealth(int health)
{
    Console.WriteLine(health);
}

bool IsGameOver(int health)
{
    return health <= 0;
}
```
<!-- code-result: Fragment definiuje dwie metody. ShowHealth wypisze przekazane zdrowie, a IsGameOver zwróci true dla wartości mniejszej lub równej 0. Bez wywołania nie ma wyniku w konsoli. -->

Blok `if`, `for` lub `while` także tworzy zasięg:

```csharp
if (health < 20)
{
    string warning = "Mało zdrowia!";
    Console.WriteLine(warning);
}

// Console.WriteLine(warning); // błąd: warning istnieje tylko w bloku if
```
<!-- code-result: Jeśli health jest mniejsze niż 20, konsola wyświetli:
Mało zdrowia!

Po odkomentowaniu ostatniej linii kompilator zgłosi błąd, bo warning istnieje tylko wewnątrz bloku if. -->

Zamiast udostępniać wszystkim metodom wszystkie zmienne, przekazujemy tylko dane, których metoda rzeczywiście potrzebuje.

## 7. Funkcje strzałkowe — krótki zapis krótkiej metody

> **Maciuś:** Przepisałem wszystko na `=>`. Teraz metoda mieści się w jednej linii.
>
> **Jan:** A ja mogę zapisać numer telefonu bez spacji. To jeszcze nie znaczy, że lepiej się go czyta.

W C# zapis `=>` nazywamy składnią z ciałem wyrażeniowym. Potocznie mówi się też o zapisie strzałkowym. Na tym etapie używamy go jako skrótu dla metody wykonującej **jedno proste wyrażenie**.

Te dwa zapisy robią to samo:

```csharp
bool IsGameOver(int health)
{
    return health <= 0;
}
```
<!-- code-result: Fragment definiuje metodę w zapisie blokowym. IsGameOver(0) zwróci true, a IsGameOver(1) zwróci false. Sama definicja niczego nie wypisuje. -->

```csharp
bool IsGameOver(int health) => health <= 0;
```
<!-- code-result: Obie wersje definiują tę samą metodę. IsGameOver(0) zwróci true, a IsGameOver(1) zwróci false. Sama definicja niczego nie wypisuje. -->

Inne przykłady:

```csharp
int CalculateDamage(int strength, int weaponDamage) => strength + weaponDamage;
void ShowSeparator() => Console.WriteLine("--------------------");
```
<!-- code-result: Fragment definiuje dwie krótkie metody. Po wywołaniu ShowSeparator() konsola wyświetli:
20 znaków „-” tworzących poziomy separator. -->

Użyj `=>`, gdy metoda ma jedno proste wyrażenie i pozostaje czytelna bez dodatkowych zmiennych. Zwykły blok będzie lepszy dla kilku kroków, warunków i wielu instrukcji.

Nie przyznajemy punktów za zmieszczenie całej gry po prawej stronie jednej strzałki.

### Ta sama strzałka, dwa zastosowania

Metoda z ciałem wyrażeniowym ma nazwę i pełną sygnaturę:

```csharp
bool IsGameOver(int health) => health <= 0;
```
<!-- code-result: Fragment definiuje metodę z ciałem wyrażeniowym. IsGameOver(0) zwróci true, a IsGameOver(1) zwróci false. Sama definicja niczego nie wypisuje. -->

Wyrażenie lambda jest krótką, bezimienną funkcją przekazaną w miejscu użycia:

```csharp
List<string> inventory = new List<string> { "miecz", "mikstura", "łuk" };
List<string> longNames = inventory.FindAll(item => item.Length > 5);
```
<!-- code-result: longNames zawiera jeden element:
mikstura

Fragment nie wypisuje listy na konsoli. -->

Czytamy `item => item.Length > 5` jako: „dla elementu `item` sprawdź, czy jego nazwa ma więcej niż 5 znaków”. `FindAll` wykonuje ten test dla każdego elementu i tworzy listę pasujących elementów.

Na tym etapie lambda przydaje się do krótkiego warunku, którego używamy tylko w jednym miejscu:

```csharp
List<int> prices = new List<int> { 25, 100, 250 };
List<int> expensivePrices = prices.FindAll(price => price >= 100);
bool hasPotion = inventory.Exists(item => item == "mikstura");
```
<!-- code-result: expensivePrices zawiera: 100, 250
hasPotion ma wartość: true

Fragment nie wypisuje tych wartości na konsoli. -->

Jeśli warunek robi się długi lub powtarza się, nadaj mu nazwę:

```csharp
bool IsHealingItem(string item) =>
    item == "mikstura" || item == "eliksir";

List<string> healingItems = inventory.FindAll(IsHealingItem);
```
<!-- code-result: Dla wcześniejszej listy inventory kolekcja healingItems zawiera:
mikstura

Kod niczego nie wypisuje. -->

Nie musisz teraz znać mechanizmu delegatów. Wystarczy praktyczny model: metoda listy prosi o mały warunek, a lambda dostarcza go za pomocą `=>`.

## 8. Refaktoryzacja pętli gry

Po wydzieleniu metod główna pętla może wyglądać tak:

```csharp
while (!IsGameOver(health))
{
    ShowStatus(heroName, health, gold);
    ShowMenu();
    string command = ReadCommand();

    if (command == "1")
    {
        int damage = CalculateDamage(strength, weaponDamage);
        Console.WriteLine($"Zadajesz {damage} obrażeń.");
    }
    else if (command == "2")
    {
        health = Heal(health, 10, maxHealth);
    }
}
```
<!-- code-result: Wynik zależy od stanu gry i komend użytkownika. W każdej turze program pokazuje status i menu, odczytuje komendę, a następnie atakuje albo leczy bohatera. -->

Przykładowa walidacja komendy:

```csharp
string ReadCommand()
{
    while (true)
    {
        Console.Write("Wybierz 1 lub 2: ");
        string? command = Console.ReadLine();

        if (command == "1" || command == "2")
        {
            return command;
        }

        Console.WriteLine("Nieznana komenda.");
    }
}
```
<!-- code-result: Po wywołaniu metoda wyświetla pytanie „Wybierz 1 lub 2:”. Dla innych danych pokazuje „Nieznana komenda.” i pyta ponownie. Zwraca dopiero tekst "1" albo "2". -->

Główna pętla pokazuje teraz ogólny przebieg gry. Szczegóły nadal istnieją, lecz mają nazwy i własne miejsce.

## Typowe błędy

### Wypisanie wyniku zamiast jego zwrócenia

```csharp
void CalculateDamage(int strength)
{
    Console.WriteLine(strength * 2);
}
```
<!-- code-result: Sam fragment tylko definiuje metodę. Po wywołaniu CalculateDamage(5) konsola wyświetli 10, ale wartości 10 nie można przypisać do zmiennej, ponieważ metoda ma typ void. -->

Jeśli wynik ma być dalej używany, metoda powinna go zwrócić:

```csharp
int CalculateDamage(int strength) => strength * 2;
```
<!-- code-result: Metoda niczego nie wypisuje. CalculateDamage(5) zwróci wartość 10 do miejsca wywołania. -->

### Ignorowanie zwróconej wartości

```csharp
Heal(health, 10, 100); // wynik przepada
health = Heal(health, 10, 100); // wynik zostaje zapisany
```
<!-- code-result: Pierwsze wywołanie oblicza wynik i go porzuca. Drugie zapisuje zwróconą wartość w health. Fragment niczego nie wypisuje. -->

### Zmiana kopii parametru

```csharp
void Heal(int health)
{
    health += 10;
}
```
<!-- code-result: Fragment tylko definiuje metodę. Zmiana dotyczy lokalnej kopii parametru health, więc zdrowie poza metodą nie zostanie zmienione. -->

Zmiana parametru nie aktualizuje automatycznie zmiennej przekazanej przez wywołującego. Na tym etapie zwracamy nową wartość:

```csharp
int Heal(int health) => health + 10;
health = Heal(health);
```
<!-- code-result: Heal zwraca wartość większą o 10, a przypisanie zapisuje ją w health. Dla health = 70 nowa wartość to 80. Fragment niczego nie wypisuje. -->

### Metoda robi zbyt wiele

Jeżeli nazwa zaczyna przypominać `ReadCommandAndAttackAndShowStatus`, prawdopodobnie są to co najmniej trzy metody.

## Pytania kontrolne

1. Czym różni się metoda `void` od metody zwracającej `int`?
2. Jaka jest różnica między parametrem a argumentem?
3. Czy zmienna lokalna metody istnieje po jej zakończeniu?
4. Dlaczego metoda licząca obrażenia nie musi niczego wypisywać?
5. Co stanie się ze zwróconym wynikiem, jeśli go nie zapiszemy?
6. Która metoda lepiej nadaje się do zapisu strzałkowego: `IsGameOver` czy wieloetapowe `ReadCommand`? Dlaczego?

## Podsumowanie

- Metoda nadaje nazwę wydzielonej operacji.
- Parametry dostarczają metodzie dane, a `return` przekazuje wynik na zewnątrz.
- `void` oznacza brak zwracanej wartości.
- Zmienne lokalne są dostępne tylko w swoim zasięgu.
- Małe metody łatwiej czytać, sprawdzać i ponownie wykorzystywać.
- Zapis `=>` jest wygodny dla bardzo krótkich metod, ale nie jest konkursem na najmniejszą liczbę nawiasów.
- Krótka lambda może opisać jednorazowy warunek dla `FindAll` lub `Exists`.

> **Granica materiału:** nie wprowadzamy jeszcze `ref`, `out` ani teorii delegatów i callbacków. Zapis `=>` wykorzystujemy w prostych metodach oraz krótkich lambdach przekazywanych do znanych operacji na liście.
