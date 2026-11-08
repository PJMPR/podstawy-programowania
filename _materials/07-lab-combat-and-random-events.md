---
layout: material
title: "Laboratorium 07 — rozwijamy klasy Player i Enemy"
kind: lab
week: 7
summary: "Dziewięć zadań rozwijających przykłady z wykładu: bohatera, przeciwnika, kolekcję obiektów i prostą walkę."
published: false
content_ready: true
---

## Cel laboratorium

Wszystkie zadania w tym laboratorium bazują na kodzie pokazanym na wykładzie. Najpierw skopiuj przykłady do własnego projektu, uruchom je i dopiero potem modyfikuj. Nie tworzysz dziewięciu niezależnych programów — rozwijasz jeden mały model gry krok po kroku.

```text
Player  →  Enemy  →  lista przeciwników  →  walka  →  mini-projekt
```

## Zasady pracy

- Każde zadanie wykonuj na kopii działającego rozwiązania z poprzedniego zadania.
- Nie przepisuj całego programu od nowa — zmieniaj tylko to, co jest potrzebne.
- Klasy `Player` i `Enemy` trzymaj w osobnych plikach.
- Po każdej zmianie uruchom program i sprawdź przynajmniej jeden przypadek poprawny oraz jeden brzegowy.
- Wymagania dotyczące komunikatów możesz realizować w `Program`, ale reguły stanu powinny pozostać w odpowiedniej klasie.
- Nie dodawaj dziedziczenia, interfejsów, polimorfizmu ani LINQ.

---

## Przykłady z wykładu

### Przykład 1 — klasa `Player`

Plik `Player.cs`:

```csharp
public class Player
{
    public string Name { get; }
    public int Health { get; private set; }
    public int MaxHealth { get; }
    public int Gold { get; private set; }

    public Player(string name, int maxHealth, int gold)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Gold = gold;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }
    }

    public void Heal(int amount)
    {
        Health += amount;

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}
```

### Przykład 2 — klasa `Enemy`

Plik `Enemy.cs`:

```csharp
public class Enemy
{
    public string Name { get; }
    public int Health { get; private set; }
    public int Damage { get; }

    public Enemy(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}
```

### Przykład 3 — obiekty i walka

Plik `Program.cs`:

```csharp
Player player = new Player("Maciuś", 100, 25);
Enemy goblin = new Enemy("Goblin", 30, 8);

Console.WriteLine($"{player.Name} spotyka {goblin.Name}.");

goblin.TakeDamage(12);
Console.WriteLine($"{goblin.Name} ma {goblin.Health} HP.");

if (goblin.IsAlive())
{
    player.TakeDamage(goblin.Damage);
    Console.WriteLine($"{player.Name} ma {player.Health} HP.");
}
else
{
    Console.WriteLine("Przeciwnik został pokonany.");
}
```

### Przykład 4 — lista przeciwników

```csharp
List<Enemy> enemies = new List<Enemy>
{
    new Enemy("Goblin", 30, 8),
    new Enemy("Nietoperz", 20, 5),
    new Enemy("Ork", 70, 15)
};

foreach (Enemy enemy in enemies)
{
    Console.WriteLine($"{enemy.Name}: {enemy.Health} HP");
}
```

Jeśli `List<Enemy>` nie jest rozpoznawana, dodaj `using System.Collections.Generic;` albo użyj projektu, w którym przestrzenie nazw są już dostępne.

### Diagram modelu z wykładu

```text
+------------------+             +------------------+
|      Player      |             |      Enemy       |
+------------------+             +------------------+
| Name             |             | Name             |
| Health           |             | Health           |
| MaxHealth        |             | Damage           |
| Gold             |             | TakeDamage()     |
| TakeDamage()     |             | IsAlive()        |
| Heal()           |             +--------+---------+
| IsAlive()        |                      |
+--------+---------+                      | wiele obiektów
         |                                v
         |                       +------------------+
         +---------------------->| List<Enemy>      |
             współpracują        +------------------+
             w walce             | Goblin           |
                                 | Nietoperz        |
                                 | Ork              |
                                 +------------------+
```

> **Komentarz:** Kod jest punktem startowym. W zadaniach nie musisz zachować angielskich nazw, ale jeśli je zmienisz, zmień je konsekwentnie we wszystkich plikach.

> **Maciuś:** Skopiowałem kod z wykładu i mam bohatera oraz goblina.
>
> **Jan:** A co potrafią?
>
> **Maciuś:** Bohater ma HP, goblin też ma HP.
>
> **Jan:** To już początek. Teraz spraw, żeby każdy obiekt miał własne zachowanie, a nie tylko własną etykietę.

---

## Zadania proste

### Zadanie 1 — Rozbuduj bohatera

Rozwiń klasę `Player` z przykładu.

Dodaj:

- właściwość `Level`,
- właściwość `Experience`,
- metodę zdobywania doświadczenia,
- awans po przekroczeniu ustalonego progu.

Po awansie zwiększ `MaxHealth` i uzupełnij `Health` do nowego maksimum.

Sprawdź:

- zdobycie małej liczby punktów,
- zdobycie dokładnie liczby potrzebnej do awansu,
- zdobycie większej liczby punktów,
- wyświetlenie poziomu i doświadczenia po każdej operacji.

**Podpowiedź:** decyzja o tym, czy nastąpił awans, powinna znajdować się w metodzie odpowiedzialnej za doświadczenie, a nie w kilku miejscach `Program`.

> **Uwaga:** Nie twórz publicznej właściwości, która pozwala ustawić poziom na wartość ujemną. Stan powinien pozostać kontrolowany przez klasę.

---

### Zadanie 2 — Bezpieczne obrażenia i leczenie

Uzupełnij metody `TakeDamage` i `Heal` w klasach `Player` oraz `Enemy` o obsługę błędnych argumentów.

Ustal własne reguły dla:

- obrażeń równych zero,
- obrażeń ujemnych,
- leczenia równego zero,
- leczenia ujemnego,
- obrażeń zadanych pokonanemu obiektowi.

Program powinien wypisać informację, czy operacja została wykonana, czy odrzucona.

Nie zmieniaj bezpośrednio `Health` w `Program`. Wszystkie zmiany wykonuj przez metody obiektu.

**Podpowiedź:** najpierw zdecyduj, czy błędną operację ignorujesz, czy sygnalizujesz przez wartość `bool`. Ważne, aby zachowanie było spójne w obu klasach.

---

### Zadanie 3 — Dwa obiekty, dwa niezależne stany

Na podstawie przykładu utwórz:

- dwóch graczy,
- dwóch przeciwników,
- osobny scenariusz obrażeń dla każdej pary.

Pokaż, że:

- obrażenia goblina nie zmieniają zdrowia orka,
- obrażenia jednego gracza nie zmieniają zdrowia drugiego,
- każdy obiekt ma własne imię i własny stan,
- dwie zmienne wskazujące różne obiekty nie współdzielą przypadkowo HP.

**Podpowiedź:** wykonaj operację tylko na pierwszym obiekcie, a potem wypisz stan wszystkich czterech. To prosty test niezależności instancji.

---

## Zadania średnie

### Zadanie 4 — Lista przeciwników i raport

Rozwiń listę `enemies` z przykładu do minimum pięciu przeciwników.

Dodaj metody lub fragmenty programu, które:

- wypisują wszystkich żywych przeciwników,
- obliczają sumę ich punktów życia,
- znajdują przeciwnika z największą liczbą HP,
- liczą, ilu przeciwników zostało pokonanych.

Nie używaj LINQ. Wykorzystaj pętlę `foreach` lub klasyczną pętlę `for`.

### Diagram przepływu raportu

```text
List<Enemy>
     |
     v
+----+-----------------------+
| przejdź po każdym obiekcie |
+----+-----------------------+
     |
     +--> IsAlive()  → raport żywych
     +--> Health     → suma HP
     +--> Health     → największe HP
     +--> IsAlive()  → liczba pokonanych
```

**Sugestia:** zapisz osobno wartości pomocnicze do sumy, maksimum i licznika. Nie próbuj obliczać wszystkiego w jednym nieczytelnym wyrażeniu.

---

### Zadanie 5 — Wybór przeciwnika do walki

Na podstawie listy przeciwników dodaj możliwość wyboru przeciwnika przez gracza.

Program powinien:

- wyświetlić przeciwników z numerami,
- pobrać numer od użytkownika,
- sprawdzić, czy numer jest poprawny,
- sprawdzić, czy wybrany przeciwnik żyje,
- zwrócić albo zapamiętać wybrany obiekt,
- pozwolić graczowi zaatakować właśnie ten obiekt.

Obsłuż sytuacje:

- tekst zamiast liczby,
- numer mniejszy od pierwszego,
- numer większy od liczby elementów,
- wybór pokonanego przeciwnika.

**Podpowiedź:** najpierw przetestuj wybór bez walki. Dopiero gdy program zawsze wybiera właściwy obiekt, połącz go z `TakeDamage`.

> **Maciuś:** Wybrałem przeciwnika numer 7, ale mam tylko trzech.
>
> **Jan:** To nie wybór przeciwnika, tylko próba zamówienia smoka z nieistniejącej strony menu.
>
> **Maciuś:** Czyli walidacja przed użyciem indeksu.

---

### Zadanie 6 — Pełna tura walki

Połącz `Player`, `Enemy` i listę przeciwników w powtarzalną turę walki.

Jedna tura ma przebiegać następująco:

1. wyświetlenie stanu gracza i wybranego przeciwnika,
2. atak gracza,
3. sprawdzenie, czy przeciwnik przeżył,
4. kontratak przeciwnika tylko wtedy, gdy nadal żyje,
5. sprawdzenie, czy gracz przeżył,
6. komunikat o wyniku tury.

Dodaj możliwość zakończenia walki po pokonaniu przeciwnika albo gracza.

Nie twórz nowej klasy systemu walki, jeśli nie potrafisz jeszcze wyjaśnić jej odpowiedzialności. Najpierw uporządkuj przepływ w metodzie lub kilku małych metodach programu.

### Diagram tury

```text
atak gracza
     |
     v
czy Enemy żyje? -- nie --> przeciwnik pokonany
     |
    tak
     v
kontratak Enemy
     |
     v
czy Player żyje? -- nie --> przegrana
     |
    tak
     v
następna tura
```

**Uwaga:** najczęstszy błąd to kontratak pokonanego przeciwnika. Warunek `IsAlive()` musi zostać sprawdzony przed jego akcją.

---

## Zadania trudne

### Zadanie 7 — Przedmioty i leczenie z użyciem obiektów

Dodaj do kodu z wykładu klasę przedmiotu leczniczego. Niech gracz posiada kolekcję przedmiotów.

Przedmiot powinien mieć:

- nazwę,
- liczbę punktów leczenia,
- liczbę sztuk.

Gracz powinien potrafić:

- dodać przedmiot do kolekcji,
- wyświetlić ekwipunek,
- użyć wybranego przedmiotu,
- zwiększyć HP, ale nie powyżej `MaxHealth`,
- zmniejszyć liczbę sztuk,
- odrzucić użycie nieistniejącego albo pustego przedmiotu.

### Diagram relacji

```text
+------------------+       posiada wiele       +------------------+
|      Player      |--------------------------->|      Item        |
+------------------+                            +------------------+
| Health           |                            | Name             |
| MaxHealth        |                            | HealAmount       |
| Inventory        |                            | Quantity         |
| Heal()           |                            | UseOne()         |
+------------------+                            +------------------+
```

**Podpowiedź:** `Player` powinien decydować, czy może przyjąć leczenie, a `Item` powinien pilnować liczby własnych sztuk. Nie trzymaj obu reguł w jednej instrukcji w `Main`.

---

### Zadanie 8 — Różne typy przeciwników bez dziedziczenia

Rozbuduj klasę `Enemy`, zachowując jedną klasę dla wszystkich przeciwników.

Dodaj właściwości, które pozwolą opisać różne zachowania:

- typ ataku,
- szansę na obronę albo ucieczkę,
- nagrodę w złocie,
- informację, czy przeciwnik jest aktualnie w obronie.

W walce dodaj co najmniej trzy możliwe sytuacje:

- zwykły atak,
- obrona zmniejszająca obrażenia,
- ucieczka usuwająca przeciwnika z aktywnej walki.

Utwórz przynajmniej cztery obiekty `Enemy` z różnymi wartościami tych właściwości. Nie twórz klas `Goblin`, `Ork` i `Dragon`. Celem jest pokazanie, że jedna klasa może tworzyć różne obiekty.

**Podpowiedź:** zacznij od jednej reguły, na przykład obrony. Dopiero gdy działa dla jednego przeciwnika, dodaj kolejne zachowania.

> **Komentarz:** To nadal podstawy klas i obiektów, a nie pełny system sztucznej inteligencji. Ważniejsze są jasne reguły i poprawny stan niż liczba efektów.

---

### Zadanie 9 — Projekt: arena na bazie kodu z wykładu

Rozbuduj przykłady z wykładu do działającej mini-areny. Projekt musi zaczynać się od klas `Player` i `Enemy`, a wszystkie nowe elementy powinny rozszerzać istniejący model.

#### Wymagania obowiązkowe

- zachowaj klasę `Player` z HP, maksymalnym HP, złotem i metodami zmiany stanu,
- zachowaj klasę `Enemy` z HP, obrażeniami i metodą sprawdzania życia,
- utwórz listę co najmniej pięciu przeciwników,
- pozwól wybrać przeciwnika i przeprowadzić z nim walkę,
- dodaj co najmniej jedną klasę wynikającą z rozwoju kodu z wykładu, np. przedmiot lub nagrodę,
- dodaj menu minimum trzech akcji,
- dodaj warunek zwycięstwa i porażki,
- obsłuż co najmniej trzy niepoprawne dane użytkownika,
- po zakończeniu walki pokaż podsumowanie: HP, złoto i liczbę pokonanych przeciwników.

#### Etapy realizacji

1. Uruchom przykłady bez zmian.
2. Dodaj listę przeciwników.
3. Dodaj wybór przeciwnika.
4. Dodaj pełną turę walki.
5. Dodaj przedmiot, nagrodę albo inny element wynikający z przykładu.
6. Dodaj menu i warunki końca.
7. Przetestuj przypadki brzegowe.

### Diagram projektu

```text
                         +----------------+
                         |    Program     |
                         | menu i tury    |
                         +-------+--------+
                                 |
                +----------------+----------------+
                |                                 |
                v                                 v
       +----------------+                +----------------+
       |     Player     |                |  List<Enemy>   |
       +-------+--------+                +--------+-------+
               |                                  |
               | posiada                          | zawiera wiele
               v                                  v
       +----------------+                +----------------+
       |  Item / Reward |                |     Enemy      |
       +----------------+                +----------------+
```

#### Ograniczenia projektu

- Nie kopiuj gotowego rozwiązania z internetu.
- Nie przenoś wszystkich reguł do jednej metody `Main`.
- Nie dodawaj dziedziczenia ani interfejsów.
- Każda nowa klasa musi mieć uzasadnioną odpowiedzialność.
- Kod projektu powinien zawierać komentarz przy co najmniej dwóch decyzjach projektowych: dlaczego właściwość jest prywatna oraz dlaczego dana metoda należy do konkretnej klasy.

> **Maciuś:** Dodałem do areny smoka, sklep, pogodę, zapis gry i trzy zakończenia.
>
> **Jan:** A działa podstawowa walka?
>
> **Maciuś:** Tylko czasami.
>
> **Jan:** Najpierw doprowadź jedną turę od ataku do zwycięstwa. Dopiero potem zapraszaj pogodę na arenę.

---

## Sugestie do pracy

### Gdy nie wiesz, od czego zacząć

1. Uruchom dokładnie przykład z wykładu.
2. Zmień tylko jedną wartość konstruktora.
3. Wypisz stan obiektu przed i po wywołaniu metody.
4. Dodaj przypadek brzegowy.
5. Dopiero potem przejdź do kolekcji albo pętli walki.

### Pytania kontrolne

- Czy `Player` i `Enemy` są klasami czy obiektami?
- Co tworzy `new Enemy(...)`?
- Dlaczego `Health` ma `private set`?
- Co się stanie, jeśli kontratak nastąpi bez sprawdzenia `IsAlive()`?
- Dlaczego dwa wywołania `new Enemy(...)` tworzą niezależnych przeciwników?
- Która klasa powinna pilnować liczby przedmiotów?

## Kryteria zaliczenia

### Zadania 1–3 — proste

- [ ] Student poprawnie modyfikuje klasy `Player` i `Enemy`.
- [ ] Konstruktor nadal tworzy poprawny stan początkowy.
- [ ] Metody nie pozwalają na oczywiście błędny stan HP.
- [ ] Obiekty zachowują niezależne dane.

### Zadania 4–6 — średnie

- [ ] Lista przeciwników jest poprawnie przetwarzana.
- [ ] Wybór obiektu jest walidowany.
- [ ] Tura nie wykonuje kontrataku pokonanego przeciwnika.
- [ ] Program obsługuje zakończenie walki.

### Zadania 7–9 — trudne

- [ ] Nowe klasy współpracują z `Player` i `Enemy`.
- [ ] Reguły są umieszczone w odpowiedzialnych klasach.
- [ ] Projekt ma działający scenariusz od początku do końca.
- [ ] Student potrafi wyjaśnić, co zmienił w kodzie z wykładu.

## Co oddać

- pliki źródłowe projektu,
- krótką instrukcję uruchomienia,
- zrzut lub tekstowy przykład działania programu,
- w zadaniu 9 diagram klas albo tabelę odpowiedzialności,
- listę dwóch decyzji projektowych i trzech przetestowanych przypadków brzegowych.
