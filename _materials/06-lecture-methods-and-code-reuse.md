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

## Zakres wykładu — 90 minut

| Część | Czas |
|---|---:|
| Po co wydzielać metody | 10 min |
| Definicja, wywołanie i `void` | 15 min |
| Parametry i argumenty | 15 min |
| Typ wyniku oraz `return` | 15 min |
| Zasięg i przepływ danych | 10 min |
| Krótkie metody i zapis `=>` | 10 min |
| Refaktoryzacja fragmentu gry | 10 min |
| Podsumowanie | 5 min |

## 1. Kiedy kod zaczyna prosić o metodę?

```csharp
Console.WriteLine("====================");
Console.WriteLine($"Bohater: {heroName}");
Console.WriteLine($"Zdrowie: {health}");
Console.WriteLine($"Złoto: {gold}");
Console.WriteLine("====================");
```

Jeśli taki blok występuje w kilku miejscach, trzeba go kopiować. Każda późniejsza zmiana wymaga poprawienia wszystkich kopii. Możemy zamiast tego nadać operacji nazwę:

```csharp
void ShowStatus(string heroName, int health, int gold)
{
    Console.WriteLine("====================");
    Console.WriteLine($"Bohater: {heroName}");
    Console.WriteLine($"Zdrowie: {health}");
    Console.WriteLine($"Złoto: {gold}");
    Console.WriteLine("====================");
}

ShowStatus(heroName, health, gold);
```

Metodę warto wydzielić, gdy fragment:

- powtarza się,
- wykonuje jedną, dającą się nazwać czynność,
- jest długi i zasłania główny przebieg programu,
- przyda się do sprawdzenia niezależnie od reszty gry.

> **Maciuś Pierwszy (junior):** Skopiowałem ten kod tylko cztery razy. To jeszcze nie jest powtórzenie, prawda?
>
> **Jan Kowalski (senior):** Oczywiście. To cztery niezależne egzemplarze tego samego błędu.

## 2. Anatomia metody

```csharp
void ShowMessage(string message)
{
    Console.WriteLine(message);
}
```

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

Program przechodzi do ciała metody, wykonuje je, a następnie wraca do miejsca wywołania.

Nazwy metod zapisujemy w C# w stylu `PascalCase`. Dobra nazwa mówi, co metoda robi: `ShowMenu`, `ReadCommand`, `CalculateDamage`. Nazwy `DoIt`, `Thing` i `Method1` są poprawne dla kompilatora, ale nie dla człowieka, który wróci do projektu za tydzień. Tym człowiekiem bardzo często jesteś ty.

## 3. Parametry i argumenty

Parametr jest nazwą danych w definicji metody. Argument jest konkretną wartością przekazaną podczas wywołania.

```csharp
void ShowStatus(string name, int health)
{
    Console.WriteLine($"{name}: {health} HP");
}

ShowStatus("Ada", 80);
```

`name` i `health` są parametrami, a `"Ada"` i `80` argumentami. Kolejność oraz typ argumentów muszą pasować do parametrów:

```csharp
ShowStatus("Ada", 80); // poprawnie
// ShowStatus(80, "Ada"); // błąd: niewłaściwa kolejność typów
```

Parametry pozwalają użyć tej samej metody dla różnych danych:

```csharp
ShowStatus("Ada", 80);
ShowStatus("Goblin", 35);
```

> **Maciuś Pierwszy (junior):** Metoda nie widziała zmiennej `health`, więc zrobiłem drugą zmienną globalną.
>
> **Jan Kowalski (senior):** A gdy nie znajdziesz kluczy, dorabiasz drugie drzwi? Przekaż `health` jako parametr.

## 4. `void` czy wartość zwracana?

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

Wczesny `return` obsługuje szczególny przypadek bez dodatkowego zagnieżdżania.

> **Maciuś Pierwszy (junior):** Moja metoda `CalculateDamage` wypisuje wynik, odejmuje zdrowie i jeszcze pyta, czy zaatakować ponownie.
>
> **Jan Kowalski (senior):** To nie metoda. To jednoosobowy dział firmy bez zakresu obowiązków.

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

Metoda licząca obrażenia nie pyta o dane i niczego nie wypisuje. Dostaje potrzebne wartości i zwraca wynik. Można ją łatwo sprawdzić:

```csharp
Console.WriteLine(CalculateDamage(5, 3)); // oczekujemy 8
Console.WriteLine(CalculateDamage(0, 4)); // oczekujemy 4
```

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

Blok `if`, `for` lub `while` także tworzy zasięg:

```csharp
if (health < 20)
{
    string warning = "Mało zdrowia!";
    Console.WriteLine(warning);
}

// Console.WriteLine(warning); // błąd: warning istnieje tylko w bloku if
```

Zamiast udostępniać wszystkim metodom wszystkie zmienne, przekazujemy tylko dane, których metoda rzeczywiście potrzebuje.

## 7. Funkcje strzałkowe — krótki zapis krótkiej metody

W C# zapis `=>` nazywamy składnią z ciałem wyrażeniowym. Potocznie mówi się też o zapisie strzałkowym. Na tym etapie używamy go jako skrótu dla metody wykonującej **jedno proste wyrażenie**.

Te dwa zapisy robią to samo:

```csharp
bool IsGameOver(int health)
{
    return health <= 0;
}
```

```csharp
bool IsGameOver(int health) => health <= 0;
```

Inne przykłady:

```csharp
int CalculateDamage(int strength, int weaponDamage) => strength + weaponDamage;
void ShowSeparator() => Console.WriteLine("--------------------");
```

Użyj `=>`, gdy metoda ma jedno proste wyrażenie i pozostaje czytelna bez dodatkowych zmiennych. Zwykły blok będzie lepszy dla kilku kroków, warunków i wielu instrukcji.

Nie przyznajemy punktów za zmieszczenie całej gry po prawej stronie jednej strzałki.

> **Maciuś Pierwszy (junior):** Przepisałem wszystko na `=>`. Teraz metoda mieści się w jednej linii.
>
> **Jan Kowalski (senior):** A ja mogę zapisać numer telefonu bez spacji. To jeszcze nie znaczy, że lepiej się go czyta.

### Ta sama strzałka, dwa zastosowania

Metoda z ciałem wyrażeniowym ma nazwę i pełną sygnaturę:

```csharp
bool IsGameOver(int health) => health <= 0;
```

Wyrażenie lambda jest krótką, bezimienną funkcją przekazaną w miejscu użycia:

```csharp
List<string> inventory = new List<string> { "miecz", "mikstura", "łuk" };
List<string> longNames = inventory.FindAll(item => item.Length > 5);
```

Czytamy `item => item.Length > 5` jako: „dla elementu `item` sprawdź, czy jego nazwa ma więcej niż 5 znaków”. `FindAll` wykonuje ten test dla każdego elementu i tworzy listę pasujących elementów.

Na tym etapie lambda przydaje się do krótkiego warunku, którego używamy tylko w jednym miejscu:

```csharp
List<int> prices = new List<int> { 25, 100, 250 };
List<int> expensivePrices = prices.FindAll(price => price >= 100);
bool hasPotion = inventory.Exists(item => item == "mikstura");
```

Jeśli warunek robi się długi lub powtarza się, nadaj mu nazwę:

```csharp
bool IsHealingItem(string item) =>
    item == "mikstura" || item == "eliksir";

List<string> healingItems = inventory.FindAll(IsHealingItem);
```

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

Główna pętla pokazuje teraz ogólny przebieg gry. Szczegóły nadal istnieją, lecz mają nazwy i własne miejsce.

## Typowe błędy

### Wypisanie wyniku zamiast jego zwrócenia

```csharp
void CalculateDamage(int strength)
{
    Console.WriteLine(strength * 2);
}
```

Jeśli wynik ma być dalej używany, metoda powinna go zwrócić:

```csharp
int CalculateDamage(int strength) => strength * 2;
```

### Ignorowanie zwróconej wartości

```csharp
Heal(health, 10, 100); // wynik przepada
health = Heal(health, 10, 100); // wynik zostaje zapisany
```

### Zmiana kopii parametru

```csharp
void Heal(int health)
{
    health += 10;
}
```

Zmiana parametru nie aktualizuje automatycznie zmiennej przekazanej przez wywołującego. Na tym etapie zwracamy nową wartość:

```csharp
int Heal(int health) => health + 10;
health = Heal(health);
```

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
