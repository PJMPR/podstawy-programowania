---
layout: material
title: "Laboratorium 07 — rozwijamy klasy Player i Enemy"
kind: lab
week: 7
summary: "Dziewięć zadań rozwijających przykłady z wykładu: bohatera, przeciwnika, kolekcję obiektów i prostą walkę."
published: true
content_ready: true
---

## Cel laboratorium

Wszystkie zadania w tym laboratorium bazują na kodzie pokazanym na wykładzie. Najpierw skopiuj przykłady do własnego projektu, uruchom je i dopiero potem modyfikuj. Rozwijasz jeden mały model gry krok po kroku.

```text
Player  →  Enemy  →  lista przeciwników  →  walka  →  mini-projekt
```

## Zasady pracy

- Każde zadanie wykonuj na kopii działającego rozwiązania z poprzedniego zadania.
- Rozwijaj poprzednie rozwiązanie małymi zmianami, aby łatwo obserwować ich wpływ.
- Klasy `Player` i `Enemy` trzymaj w osobnych plikach.
- Po każdej zmianie uruchom program i sprawdź przynajmniej jeden przypadek poprawny oraz jeden brzegowy.
- Wymagania dotyczące komunikatów możesz realizować w `Program`, ale reguły stanu powinny pozostać w odpowiedniej klasie.
- Skup się na klasach, obiektach, właściwościach, metodach i kolekcjach poznanych na wykładzie.

---

## Przykłady z wykładu

### Przykład 1 — klasa `Player`

Plik `Player.cs`:

```csharp
public class Player
{
    public string Name { get; }
    public int Health { get; set; }
    public int MaxHealth { get; }
    public int Gold { get; set; }

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
    public int Health { get; set; }
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

<figure class="material-diagram">
    <img src="/podstawy-programowania/assets/diagrams/07/model-klas.svg" alt="Diagram modelu klas Player i Enemy oraz listy przeciwników">
    <figcaption>Model klas i obiektów używany w laboratorium.</figcaption>
</figure>

<aside class="material-callout callout-comment">
<strong>Komentarz</strong>
<p>Kod jest punktem startowym. Możesz zachować angielskie nazwy albo zmienić je na polskie — ważna jest konsekwencja we wszystkich plikach.</p>
</aside>

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

<aside class="material-callout callout-hint">
<strong>Podpowiedź</strong>
<p>Decyzja o tym, czy nastąpił awans, powinna znajdować się w metodzie odpowiedzialnej za doświadczenie.</p>
</aside>

<aside class="material-callout callout-note">
<strong>Uwaga</strong>
<p>Zadbaj, aby stan poziomu pozostał poprawny. Najwygodniej kontrolować jego zmianę wewnątrz klasy.</p>
</aside>

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

Zmiany `Health` wykonuj przez metody obiektu, aby reguły zdrowia pozostały w jednym miejscu.

<aside class="material-callout callout-hint">
<strong>Podpowiedź</strong>
<p>Najpierw zdecyduj, czy błędną operację ignorujesz, czy sygnalizujesz przez wartość `bool`. Zachowanie powinno być spójne w obu klasach.</p>
</aside>

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

<aside class="material-callout callout-hint">
<strong>Podpowiedź</strong>
<p>Wykonaj operację tylko na pierwszym obiekcie, a potem wypisz stan wszystkich czterech. To prosty test niezależności instancji.</p>
</aside>

---

## Zadania średnie

### Zadanie 4 — Lista przeciwników i raport

Rozwiń listę `enemies` z przykładu do minimum pięciu przeciwników.

Dodaj metody lub fragmenty programu, które:

- wypisują wszystkich żywych przeciwników,
- obliczają sumę ich punktów życia,
- znajdują przeciwnika z największą liczbą HP,
- liczą, ilu przeciwników zostało pokonanych.

Raport zbuduj za pomocą pętli i wartości pomocniczych, tak aby było widać kolejne obiekty oraz obliczenia.

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

<aside class="material-callout callout-suggestion">
<strong>Sugestia</strong>
<p>Zapisz osobno wartości pomocnicze do sumy, maksimum i licznika. Dzięki temu kolejne obliczenia będą łatwiejsze do sprawdzenia.</p>
</aside>

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

<aside class="material-callout callout-hint">
<strong>Podpowiedź</strong>
<p>Najpierw przetestuj wybór bez walki. Gdy program wybiera właściwy obiekt, połącz go z `TakeDamage`.</p>
</aside>

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

Jeśli wydzielisz klasę systemu walki, opisz jej odpowiedzialność jednym zdaniem. W przeciwnym razie uporządkuj przepływ w kilku małych metodach programu.

### Diagram tury

<figure class="material-diagram">
    <img src="/podstawy-programowania/assets/diagrams/07/przebieg-walki.svg" alt="Diagram przebiegu jednej tury walki">
    <figcaption>Kolejność operacji w jednej turze walki.</figcaption>
</figure>

<aside class="material-callout callout-note">
<strong>Uwaga</strong>
<p>Najczęstszy błąd to kontratak pokonanego przeciwnika. Warunek `IsAlive()` sprawdź przed jego akcją.</p>
</aside>

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

<figure class="material-diagram">
    <img src="/podstawy-programowania/assets/diagrams/07/relacja-obiektow.svg" alt="Diagram relacji między Player, Item i Enemy">
    <figcaption>Relacje między obiektami w rozwiniętym modelu gry.</figcaption>
</figure>

<aside class="material-callout callout-hint">
<strong>Podpowiedź</strong>
<p>`Player` powinien decydować, czy może przyjąć leczenie, a `Item` powinien pilnować liczby własnych sztuk. Rozdziel te reguły między odpowiedzialne obiekty.</p>
</aside>

---

### Zadanie 8 — Różne typy przeciwników

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

Utwórz przynajmniej cztery obiekty `Enemy` z różnymi wartościami tych właściwości. Celem jest pokazanie, że jedna klasa może tworzyć różne obiekty.

<aside class="material-callout callout-hint">
<strong>Podpowiedź</strong>
<p>Zacznij od jednej reguły, na przykład obrony. Gdy działa dla jednego przeciwnika, dodaj kolejne zachowania.</p>
</aside>

<aside class="material-callout callout-comment">
<strong>Komentarz</strong>
<p>To nadal podstawy klas i obiektów. Ważniejsze są jasne reguły i poprawny stan niż liczba efektów.</p>
</aside>

---

### Zadanie 9 — Projekt: arena

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

<figure class="material-diagram">
    <img src="/podstawy-programowania/assets/diagrams/07/architektura-areny.svg" alt="Diagram architektury projektu mini-areny">
    <figcaption>Proponowana architektura projektu końcowego.</figcaption>
</figure>

#### Wskazówki jakości projektu

- Każda nowa klasa powinna mieć uzasadnioną odpowiedzialność.
- Reguły zmiany stanu umieszczaj blisko danych, których dotyczą.
- Główny program powinien koordynować przebieg gry, a nie zawierać wszystkie reguły.
- Kod projektu powinien zawierać komentarz przy co najmniej dwóch decyzjach projektowych: dlaczego wybrano dane właściwości oraz dlaczego dana metoda należy do konkretnej klasy.

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
- Dlaczego `Health` ma `get` i `set`?
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
- listę dwóch decyzji projektowych i trzech przetestowanych przypadków brzegowych.
