---
layout: material
title: "Laboratorium 07 — klasy i obiekty od zera"
kind: lab
week: 7
summary: "Dziewięć zadań o projektowaniu klas, tworzeniu obiektów i modelowaniu prostych elementów gry."
published: true
content_ready: true
---

## Cel laboratorium

W tym laboratorium samodzielnie zaprojektujesz i napiszesz kod oparty na klasach i obiektach. Zadania nie zawierają gotowych fragmentów implementacji z wykładu. Otrzymujesz wymagania, przykładowe dane i kryteria sprawdzenia — sposób rozwiązania należy do Ciebie.

Nie kopiuj klasy `Player` ani `Enemy` z wykładu. Każde zadanie wymaga zaprojektowania własnego modelu, nazw i reguł.

## Zasady pracy

- Każdą klasę umieść w osobnym pliku.
- Nazwy klas i właściwości dobieraj samodzielnie, ale zachowuj spójność.
- Konstruktor powinien tworzyć obiekt gotowy do użycia.
- Stan obiektu zmieniaj przez jego metody, jeśli dana reguła należy do tego obiektu.
- W `Main` lub w głównej pętli programu pokazuj działanie obiektów na rzeczywistych danych.
- Nie dodawaj dziedziczenia, interfejsów, polimorfizmu ani LINQ — nie są potrzebne do tych ćwiczeń.
- Jeśli zadanie wymaga walidacji, nie wystarczy sam komentarz. Program powinien rzeczywiście zareagować na błędne dane.

## Mapa laboratorium

```text
+--------------------+     +------------------------+
| Zadania 1–3        | --> | Zadania 4–6            |
| jeden obiekt       |     | współpraca obiektów    |
+--------------------+     +------------------------+
                                      |
                                      v
                         +------------------------+
                         | Zadania 7–8            |
                         | reguły i relacje       |
                         +------------------------+
                                      |
                                      v
                         +------------------------+
                         | Zadanie 9              |
                         | projekt mini-gry       |
                         +------------------------+
```

```text
JEDEN OBIEKT → KILKA OBIEKTÓW → REGUŁY → PROJEKT
```

## Kod startowy do skopiowania

Poniższe przykłady są celowo krótkie. Możesz skopiować je do własnego projektu, uruchomić, a następnie wykonywać zadania dodatkowe. Nie traktuj ich jako rozwiązania zadań 1–9 — są materiałem startowym do eksperymentów.

### Przykład A — obiekt z konstruktorem i metodami

Plik `Hero.cs`:

```csharp
public class Hero
{
    public string Name { get; }
    public int Health { get; private set; }
    public int MaxHealth { get; }

    public Hero(string name, int maxHealth)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
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

Plik `Program.cs`:

```csharp
Hero hero = new Hero("Maciuś", 100);

Console.WriteLine($"{hero.Name}: {hero.Health}/{hero.MaxHealth} HP");
hero.TakeDamage(35);
Console.WriteLine($"Po ataku: {hero.Health} HP");
hero.Heal(20);
Console.WriteLine($"Po leczeniu: {hero.Health} HP");
Console.WriteLine($"Czy żyje? {hero.IsAlive()}");
```

### Przykład B — wiele obiektów w kolekcji

```csharp
List<Hero> team = new List<Hero>
{
    new Hero("Maciuś", 100),
    new Hero("Jan", 120),
    new Hero("Ala", 80)
};

foreach (Hero hero in team)
{
    Console.WriteLine($"{hero.Name}: {hero.Health} HP");
}
```

Jeśli projekt nie rozpoznaje `List<T>`, dodaj na początku pliku dyrektywę `using System.Collections.Generic;` albo użyj wersji projektu, w której przestrzenie nazw są już dostępne.

### Przykład C — drugi rodzaj obiektu

```csharp
public class TrainingDummy
{
    public string Name { get; }
    public int Health { get; private set; }

    public TrainingDummy(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public void Hit(int damage)
    {
        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }
    }
}
```

> **Uwaga:** W przykładach użyto angielskich nazw, aby pokazać, że nazwy są decyzją projektową. W zadaniach możesz używać języka polskiego, ale nie mieszaj obu stylów w jednej klasie.

### Diagram kodu startowego

```text
+----------------+             +---------------------+
|    Program     |             |        Hero         |
+----------------+             +---------------------+
| tworzy obiekty |------------>| Name                |
| wywołuje metody|             | Health              |
+----------------+             | MaxHealth           |
                                | TakeDamage()        |
                                | Heal()              |
                                | IsAlive()           |
                                +----------+----------+
                                           |
                                           | wiele obiektów
                                           v
                                +---------------------+
                                | List<Hero> team     |
                                +---------------------+
```

### Zadania dodatkowe do przykładu A

1. Dodaj doświadczenie i poziom bohatera. Po zdobyciu ustalonej liczby punktów zwiększ poziom i maksymalne zdrowie.
2. Dodaj metodę odpoczynku, która leczy tylko wtedy, gdy bohater żyje.
3. Zabezpiecz metody przed ujemnymi obrażeniami i ujemnym leczeniem. Zdecyduj, czy odrzucasz taką operację, czy traktujesz ją jako zero.

### Zadania dodatkowe do przykładu B

1. Oblicz sumę zdrowia wszystkich bohaterów.
2. Znajdź bohatera z największą liczbą punktów życia bez używania LINQ.
3. Usuń z listy bohaterów, którzy nie żyją, i wypisz, ilu pozostało.

### Zadania dodatkowe do przykładu C

1. Dodaj informację, czy manekin jest aktywny.
2. Dodaj liczbę wszystkich otrzymanych uderzeń.
3. Napisz metodę resetującą manekin do zdrowia początkowego.

> **Sugestia pracy:** Najpierw uruchom kod bez zmian. Następnie wykonuj tylko jedno dodatkowe zadanie naraz. Po każdej zmianie dopisz scenariusz, który pozwala sprawdzić nową regułę.

> **Maciuś:** Skopiowałem kod, uruchomiłem i wszystko działa.
>
> **Jan:** Świetnie. A teraz zmień nazwę `Hero` na własny pomysł i dodaj jedną regułę, której nie ma w przykładzie.
>
> **Maciuś:** Czy „bohater czasem odkłada zadanie na później” się liczy?
>
> **Jan:** Tylko jeśli potrafisz zapisać to jako stan i metodę.

---

## Zadania proste

### Zadanie 1 — Wizytówka bohatera

Utwórz klasę opisującą bohatera gry fantasy. Samodzielnie wybierz nazwę klasy oraz co najmniej cztery właściwości, które mają sens w wizytówce, na przykład imię, profesję, poziom, liczbę punktów reputacji lub ulubioną broń.

Wymagania:

- konstruktor przyjmuje dane potrzebne do utworzenia bohatera,
- program tworzy co najmniej trzy różne obiekty,
- każdy obiekt jest wypisywany w czytelnej formie,
- zmiana właściwości jednego bohatera nie zmienia pozostałych,
- przynajmniej jedna właściwość ma wartość początkową ustalaną wewnątrz konstruktora.

**Sprawdzenie:** utwórz bohatera o imieniu „Maciuś”, zmień jego poziom, a następnie wyświetl dane pozostałych bohaterów. Ich dane powinny pozostać bez zmian.

**Podpowiedź:** najpierw zapisz na kartce zdanie: „Mój obiekt ma …”. To zdanie pomoże wybrać właściwości. Nie zaczynaj od metod.

> **Uwaga dla prowadzącego:** Jeśli student tworzy jedną klasę z właściwościami `ImieBohatera1`, `ImieBohatera2` i `ImieBohatera3`, poproś o powrót do modelu „jedna instancja = jeden bohater”.

> **Maciuś:** Zrobiłem jednego bohatera z dwunastoma imionami.
>
> **Jan:** To bohater czy rada miejska?
>
> **Maciuś:** Rada miejska. Ale przynajmniej nie muszę tworzyć drugiego obiektu.

---

### Zadanie 2 — Licznik energii

Zaprojektuj klasę reprezentującą źródło energii: baterię, latarkę, generator albo magiczny kryształ.

Obiekt powinien przechowywać:

- nazwę,
- aktualny poziom energii,
- maksymalny poziom energii.

Dodaj zachowania pozwalające:

- zużyć określoną ilość energii,
- naładować urządzenie,
- sprawdzić, czy energia jest dostępna,
- wyświetlić aktualny stan.

Reguły:

- energia nie może spaść poniżej zera,
- energia nie może przekroczyć maksimum,
- nieprawidłowa wartość początkowa powinna zostać odrzucona albo poprawiona,
- program ma pokazać co najmniej jeden przypadek próby zużycia większej ilości energii niż dostępna.

**Sprawdzenie:** wykonaj kolejno ładowanie, zużycie, zużycie zbyt dużej ilości oraz ponowne ładowanie. Po każdej operacji wypisz stan.

**Podpowiedź:** wypisz na kartce dwie granice, których nie wolno przekroczyć. Następnie zdecyduj, która metoda ma pilnować każdej granicy.

> **Komentarz:** To ćwiczenie nie jest o baterii. Jest o pilnowaniu poprawnego stanu obiektu.

---

### Zadanie 3 — Zwierzak w schronisku

Utwórz klasę opisującą zwierzę przebywające w schronisku. Wybierz własny zestaw danych, ale obiekt powinien znać co najmniej imię, gatunek, poziom głodu i poziom nastroju.

Dodaj metody odpowiadające na pytania:

- co dzieje się po nakarmieniu,
- co dzieje się po zabawie,
- czy zwierzę wymaga opieki,
- czy może zostać adoptowane.

Wymagania:

- wartości głodu i nastroju muszą mieścić się w ustalonym zakresie,
- konstruktor tworzy zwierzę w sensownym stanie początkowym,
- program tworzy minimum dwa zwierzęta o różnych danych,
- co najmniej jedna metoda zwraca wartość `bool`.

**Sprawdzenie:** przygotuj scenariusz dnia w schronisku: utworzenie zwierząt, karmienie jednego, zabawa z drugim i sprawdzenie ich stanu.

**Podpowiedź:** nie twórz osobnej zmiennej `czyMozeBycAdoptowane`, jeśli da się ją obliczyć na podstawie aktualnego stanu obiektu.

> **Maciuś:** Mój pies ma głód równy 140.
>
> **Jan:** To już nie głód, tylko czarna dziura.
>
> **Maciuś:** Dlatego właśnie potrzebuję metody, która pilnuje zakresu.

---

## Zadania średnie

### Zadanie 4 — Automat z napojami

Zaprojektuj klasę produktu oraz klasę automatu z napojami. Automat ma przechowywać listę dostępnych produktów, ich ceny i liczbę sztuk.

Użytkownik powinien móc:

- wyświetlić dostępne produkty,
- wybrać produkt,
- zapłacić podaną kwotę,
- otrzymać informację o braku produktu albo niewystarczającej kwocie,
- kupić produkt i zmniejszyć jego stan magazynowy.

Wymagania projektowe:

- produkt i automat są osobnymi klasami,
- automat nie może sprzedać produktu z liczbą sztuk równą zero,
- zakup nie może zmienić stanu innych produktów,
- program powinien pokazać co najmniej trzy różne wyniki operacji: sukces, brak produktu, za mała kwota.

### Diagram odpowiedzialności

```text
+------------------+          1        wiele       +------------------+
|     Automat      | o---------------------------->|     Produkt      |
+------------------+                               +------------------+
| - produkty       |                               | - nazwa         |
| + pokazProdukty  |                               | - cena          |
| + kupProdukt     |                               | - liczbaSztuk   |
+------------------+                               +------------------+
```

**Podpowiedź:** zadaj sobie pytanie, kto powinien wiedzieć, ile kosztuje napój — `Program`, czy `Produkt`? A kto powinien zmniejszyć stan magazynowy — produkt czy automat?

> **Uwaga dla prowadzącego:** Zadanie dobrze pokazuje relację „jeden obiekt przechowuje kolekcję innych obiektów”. Nie wymagaj jeszcze obsługi prawdziwych monet ani interfejsu użytkownika.

---

### Zadanie 5 — Drużyna poszukiwaczy

Utwórz klasę postaci oraz klasę drużyny. Drużyna ma posiadać kolekcję postaci i udostępniać operacje na całej grupie.

Drużyna powinna potrafić:

- dodać postać,
- usunąć postać po nazwie albo indeksie,
- wyświetlić skład,
- obliczyć sumę punktów życia całej drużyny,
- znaleźć postać z największą wartością wybranej statystyki.

Postać powinna mieć przynajmniej nazwę, rolę i dwie statystyki liczbowe.

Wymagania:

- nie można dodać dwóch postaci o tej samej nazwie,
- usuwanie nieistniejącej postaci nie może zakończyć programu błędem,
- drużyna sama zarządza swoją kolekcją,
- `Program` nie powinien bezpośrednio modyfikować listy wewnątrz drużyny.

### Diagram przepływu

```text
                         +----------------------+
                         |       Program        |
                         +----------+-----------+
                                    |
                                    v
                         +----------------------+
                         |       Drużyna        |
                         +--+--------+--------+--+
                            |        |        |
                            v        v        v
                         Postać 1  Postać 2  Postać 3

                         Drużyna odpowiada za:
                         - dodawanie i usuwanie,
                         - skład zespołu,
                         - obliczenia grupowe.
```

**Podpowiedź:** najpierw zaprojektuj operacje na jednej postaci, a dopiero potem operacje na kolekcji. Nie próbuj pisać całej drużyny w jednej metodzie `Main`.

> **Maciuś:** Moja drużyna ma dwie postacie, ale jedna z nich nazywa się tak samo jak druga.
>
> **Jan:** To drużyna klonów czy błąd w formularzu?
>
> **Maciuś:** Automat drużyny powinien pilnować unikalnych nazw.

---

### Zadanie 6 — Biblioteka zaklęć

Zaprojektuj system, w którym mag posiada księgę zaklęć. Zaklęcie powinno mieć nazwę, koszt many, opis i siłę działania. Mag powinien mieć manę oraz kolekcję znanych zaklęć.

Dodaj możliwość:

- nauczenia się zaklęcia,
- wyświetlenia znanych zaklęć,
- rzucenia wybranego zaklęcia,
- odrzucenia próby rzucenia nieznanego zaklęcia,
- odrzucenia próby rzucenia zaklęcia bez wystarczającej many,
- odnowienia many.

Wymagania:

- to samo zaklęcie nie może zostać dodane drugi raz,
- rzucenie zaklęcia zmniejsza manę,
- nieudana próba nie zmienia many,
- każda klasa ma mieć jasno określoną odpowiedzialność.

### Diagram współpracy

```text
Gracz       Mag          Księga zaklęć       Zaklęcie
  |          |                 |                |
  | wybiera  |                 |                |
  |--------->|                 |                |
  |          | wyszukuje       |                |
  |          |---------------->|                |
  |          | znaleziono/brak |                |
  |          |<----------------|                |
  |          | sprawdza koszt many              |
  |          |--------------------------------->|
  |          | można rzucić/brak many           |
  |          |<---------------------------------|
  | wynik    |                 |                |
  |<---------|                 |                |
```

**Podpowiedź:** rozdziel „zaklęcie jako dane” od „maga, który z niego korzysta”. Jeśli jedna klasa zna wszystkie szczegóły drugiej, zastanów się, czy odpowiedzialność nie została umieszczona w złym miejscu.

> **Komentarz dla prowadzącego:** Nie wymagaj tutaj systemu obrażeń ani losowości. Celem jest współpraca kilku obiektów i kontrola nieudanych operacji.

---

## Zadania trudne

### Zadanie 7 — Kolejka klientów w karczmie

Zaprojektuj model karczmy, w której klienci składają zamówienia, a karczmarz obsługuje je w ustalonej kolejności.

Potrzebne są co najmniej trzy rodzaje obiektów, na przykład klient, zamówienie i karczma. Samodzielnie zdecyduj, które dane i zachowania należą do poszczególnych klas.

System powinien obsługiwać:

- dodawanie klienta do kolejki,
- przyjęcie zamówienia,
- obsłużenie pierwszego oczekującego zamówienia,
- wyświetlenie aktualnej kolejki,
- obliczenie przychodu,
- komunikat, gdy kolejka jest pusta.

Reguły:

- zamówienia są obsługiwane w kolejności zgłoszeń,
- klient bez wystarczającej liczby monet nie może złożyć zamówienia,
- obsłużone zamówienie znika z kolejki,
- dane klientów nie mogą być mieszane między zamówieniami.

### Diagram modelu

```text
+------------------+       zawiera        +------------------+
|     Karczma      | o------------------->|    Zamówienie    |
+------------------+                      +------------------+
| - kolejka        |                       | - klient        |
| - przychód       |                       | - produkt       |
| + dodaj          |                       | - cena          |
| + obsłużNastępne |                       | - status        |
+------------------+                      +--------+---------+
                                                   |
                                                   | należy do
                                                   v
                                          +------------------+
                                          |      Klient      |
                                          +------------------+
                                          | - nazwa          |
                                          | - monety         |
                                          +------------------+
```

**Podpowiedź:** przed napisaniem kodu narysuj trzy pudełka i strzałki między nimi. Następnie przy każdym pudełku zapisz: „co ten obiekt wie?” oraz „co ten obiekt potrafi?”.

> **Maciuś:** Obsługuję klientów metodą `ObsluzWszystkichNaraz`.
>
> **Jan:** A kolejka?
>
> **Maciuś:** Kolejka jest smutna, ale za to szybka.
>
> **Jan:** W karczmie najpierw obsługujemy pierwszego klienta. Nawet gobliny mają swoje prawa.

---

### Zadanie 8 — Przeciwnik z zachowaniem

Zbuduj system przeciwników, którzy różnią się statystykami i prostym zachowaniem. Nie korzystaj z dziedziczenia. Każdy przeciwnik ma być obiektem tej samej klasy, ale powinien posiadać dane pozwalające na różne decyzje.

Każdy przeciwnik powinien mieć między innymi:

- nazwę,
- punkty życia,
- siłę ataku,
- poziom odwagi albo agresji,
- informację, czy żyje.

Zaimplementuj turę, w której przeciwnik wybiera jedną z decyzji:

- atak,
- obrona,
- ucieczka,
- oczekiwanie.

Decyzja ma zależeć od stanu przeciwnika, na przykład od poziomu HP i odwagi. Utwórz grupę co najmniej czterech przeciwników i przeprowadź kilka tur.

Wymagania:

- pokonany przeciwnik nie może wykonywać akcji,
- obrona powinna mieć widoczny skutek w kolejnej turze,
- ucieczka powinna zmienić stan obiektu,
- przebieg każdej tury powinien być czytelnie wypisany,
- reguły decyzji powinny znajdować się w klasie przeciwnika albo w osobnej klasie odpowiedzialnej za wybór akcji — nie w kilkudziesięciu warunkach w `Main`.

### Diagram cyklu tury

```text
       +-----------+
       | Start tury|
       +-----+-----+
             v
      +------+------+
      | Czy żyje?   |
      +---+------+--+
       nie|      |tak
          v      v
   +------+--+  +-----------------------+
   | Pomiń   |  | Oceń HP, odwagę,      |
   | obiekt  |  | obronę                |
   +---------+  +-----------+-----------+
                            v
                    +-------+--------+
                    | Wybierz akcję  |
                    +-------+--------+
                            v
                    +-------+--------+
                    | Wykonaj akcję  |
                    +-------+--------+
                            v
                    +-------+--------+
                    | Aktualizuj stan|
                    +----------------+
```

**Podpowiedź:** najpierw zaprojektuj i przetestuj decyzję dla jednego przeciwnika. Dopiero potem dodaj kolekcję. W przeciwnym razie trudno będzie ustalić, czy błąd dotyczy obiektu, czy pętli.

> **Uwaga:** „zachowanie” w tym zadaniu nie oznacza jeszcze sztucznej inteligencji. To kilka jasno zapisanych reguł i decyzji zależnych od stanu.

---

### Zadanie 9 — Projekt: mini-arena obiektowa

Zaprojektuj i zaimplementuj własną mini-grę tekstową opartą na klasach i obiektach. Temat wybierz samodzielnie: arena, ekspedycja, sklep, stacja kosmiczna, laboratorium, turniej kulinarny albo inny świat, w którym występują co najmniej trzy rodzaje bytów.

#### Minimalne wymagania projektu

Projekt musi zawierać:

- co najmniej **cztery własne klasy**,
- co najmniej **dwa obiekty** każdej z dwóch wybranych klas,
- konstruktory ustawiające poprawny stan początkowy,
- właściwości opisujące stan obiektów,
- metody zmieniające stan zgodnie z regułami gry,
- kolekcję przechowującą obiekty,
- co najmniej jedną relację między klasami, np. drużyna posiada postacie albo stacja posiada moduły,
- warunek zwycięstwa i warunek zakończenia niepowodzeniem,
- minimum pięć różnych komunikatów wynikających z decyzji gracza,
- obsługę przynajmniej trzech niepoprawnych sytuacji.

#### Ograniczenia

- nie kopiuj gotowego przykładu `Player`/`Enemy`,
- nie twórz całej gry w jednym pliku i jednej metodzie,
- nie używaj dziedziczenia ani interfejsów,
- nie dodawaj mechaniki tylko po to, aby zwiększyć liczbę klas,
- każda klasa musi mieć uzasadnioną odpowiedzialność.

#### Etapy pracy

1. Opisz pomysł w pięciu zdaniach.
2. Narysuj diagram klas i relacji.
3. Wypisz właściwości każdej klasy.
4. Wypisz metody każdej klasy bez pisania kodu.
5. Zaimplementuj jeden działający scenariusz.
6. Dodaj walidację i przypadki niepoprawne.
7. Przygotuj test ręczny i krótkie podsumowanie decyzji projektowych.

### Diagram planowania projektu

```text
+--------+   +----------------------+   +------------------+
| Pomysł |-->| Klasy i             |-->| Diagram relacji |
+--------+   | odpowiedzialności   |   +--------+---------+
             +----------------------+            |
                                                v
             +----------------------+   +--------+---------+
             | Stan początkowy     |<--| Metody i reguły  |
             +----------+-----------+   +--------+---------+
                        |                         |
                        v                         v
             +----------+-----------+   +---------+--------+
             | Scenariusz działania |-->| Testy i poprawki |
             +----------------------+   +------------------+
```

### Karta projektu do uzupełnienia

| Element | Odpowiedź studenta |
|---|---|
| Nazwa projektu |  |
| Główny cel gracza |  |
| Klasa 1 i odpowiedzialność |  |
| Klasa 2 i odpowiedzialność |  |
| Klasa 3 i odpowiedzialność |  |
| Klasa 4 i odpowiedzialność |  |
| Kolekcja obiektów |  |
| Warunek wygranej |  |
| Warunek przegranej |  |
| Trzy sytuacje błędne |  |

> **Komentarz dla prowadzącego:** Oceniaj przede wszystkim model i odpowiedzialności klas, a nie rozmiar gry. Mały, spójny projekt jest lepszy niż duża gra, w której wszystkie reguły znajdują się w `Main`.

> **Maciuś:** Mój projekt ma 47 klas i trzy ekrany menu.
>
> **Jan:** A co potrafi gracz?
>
> **Maciuś:** Na razie nic, ale architektura jest imponująca.
>
> **Jan:** Zacznij od jednego działającego scenariusza. Smok może poczekać.

---

## Sugestie i komentarze do pracy

### Jak zacząć każde zadanie

1. Zapisz rzeczowniki z treści zadania — często podpowiadają nazwy klas.
2. Zapisz czasowniki — często podpowiadają nazwy metod.
3. Oddziel dane od działań.
4. Ustal, kto jest właścicielem każdej reguły.
5. Dopiero potem utwórz pliki i zacznij implementację.

### Pytania pomocnicze

- Czy ten obiekt może istnieć bez tej właściwości?
- Czy zmiana tej wartości powinna być możliwa z dowolnego miejsca programu?
- Który obiekt powinien pilnować tej reguły?
- Czy metoda robi jedną czytelnie nazwaną rzecz?
- Czy dwa utworzone obiekty są niezależne?
- Co powinno się stać dla zera, wartości ujemnej i pustej kolekcji?

### Typowe problemy

| Problem | Pytanie naprowadzające |
|---|---|
| Wszystko znajduje się w `Main` | Który fragment opisuje jeden konkretny byt? |
| Właściwość ma przypadkową wartość | Czy konstruktor ustawia stan początkowy? |
| HP spada poniżej zera | Która metoda zmienia HP i gdzie pilnuje granicy? |
| Zmiana jednego obiektu zmienia drugi | Czy utworzono dwa razy `new`, czy skopiowano odwołanie? |
| Klasa ma kilkanaście niezwiązanych zadań | Czy można podzielić odpowiedzialności? |
| Program kończy się błędem dla pustej listy | Czy sprawdzono przypadek brzegowy przed odczytem? |

## Kryteria zaliczenia

### Zadania 1–3 — proste

- [ ] Klasa opisuje jeden wyraźny rodzaj obiektu.
- [ ] Obiekt jest tworzony przez konstruktor.
- [ ] Utworzono minimum dwa niezależne obiekty.
- [ ] Stan obiektu można odczytać i zmienić zgodnie z regułami.

### Zadania 4–6 — średnie

- [ ] Współpracują co najmniej dwie klasy.
- [ ] Jedna klasa przechowuje kolekcję innych obiektów.
- [ ] Niepoprawna operacja nie niszczy stanu programu.
- [ ] Odpowiedzialności klas są widoczne w nazwach i metodach.

### Zadania 7–9 — trudne

- [ ] Model obejmuje kilka rodzajów obiektów i ich relacje.
- [ ] Reguły znajdują się w odpowiednich klasach.
- [ ] Program obsługuje przypadki brzegowe.
- [ ] Istnieje działający scenariusz od początku do końca.
- [ ] Student potrafi ustnie wyjaśnić, dlaczego każda klasa istnieje.

## Co oddać

Do każdego zadania oddaj:

- pliki źródłowe,
- krótką instrukcję uruchomienia,
- dwa lub trzy przykładowe scenariusze działania,
- w zadaniach 5–9 diagram albo tabelę odpowiedzialności,
- w zadaniu 9 dodatkowo opis decyzji projektowych i listę znanych ograniczeń.
