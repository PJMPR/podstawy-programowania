---
layout: material
title: "Tablice, listy i słowniki — przechowywanie wielu wartości"
kind: lecture
week: 5
summary: "Tablice jednowymiarowe, listy, słowniki, indeksowanie, iterowanie oraz podstawowe algorytmy operujące na kolekcjach."
published: true
content_ready: true
---

## Cel wykładu

Dotychczas każda informacja wymagała osobnej zmiennej. To wystarcza dla imienia i punktów życia bohatera, ale staje się niewygodne, gdy chcemy zapisać wyniki dziesięciu tur, kilka nazw przeciwników albo zawartość plecaka.

**Kolekcja** pozwala przechowywać wiele wartości pod jedną nazwą. Poznamy trzy podstawowe rodzaje kolekcji w C#: tablicę o stałym rozmiarze, listę, której rozmiar może się zmieniać, oraz słownik, który łączy unikalne klucze z wartościami.

Po tym wykładzie będziesz potrafić:

- utworzyć i zainicjalizować tablicę jednowymiarową,
- bezpiecznie odczytywać i zmieniać jej elementy,
- wyjaśnić, dlaczego pierwszy element ma indeks 0,
- iterować za pomocą `for` i `foreach`,
- samodzielnie obliczyć sumę, minimum i maksimum,
- wyszukać wartość i policzyć jej wystąpienia,
- tworzyć oraz modyfikować `List<T>`,
- tworzyć `Dictionary<TKey, TValue>` i korzystać z kluczy,
- bezpiecznie dodawać, odczytywać, zmieniać i usuwać pary klucz–wartość,
- wybrać tablicę, listę albo słownik odpowiednio do problemu,
- rozpoznawać typowe błędy związane z kolekcjami.

> **Granica materiału:** korzystamy z tablic jednowymiarowych, `List<T>` i `Dictionary<TKey, TValue>`. Nie używamy jeszcze tablic 2D, LINQ ani własnych metod.

---

## 1. Dlaczego jedna zmienna nie wystarcza?

Załóżmy, że zapisujemy złoto zdobyte w pięciu turach:

    int zlotoTura1 = 4;
    int zlotoTura2 = 10;
    int zlotoTura3 = 0;
    int zlotoTura4 = 7;
    int zlotoTura5 = 12;

Taki kod ma kilka wad:

- każda nowa tura wymaga nowej zmiennej,
- nie da się łatwo przejść po wszystkich wynikach pętlą,
- obliczenie sumy wymaga wymienienia każdej zmiennej,
- kod dla 100 tur byłby bardzo długi.

Te same dane możemy zapisać jako jedną tablicę:

    int[] zlotoWTurach = { 4, 10, 0, 7, 12 };

| Indeks | 0 | 1 | 2 | 3 | 4 |
|---|---:|---:|---:|---:|---:|
| Wartość | 4 | 10 | 0 | 7 | 12 |

Zmienna `zlotoWTurach` daje dostęp do całej kolekcji, a każdy wynik ma miejsce oznaczone indeksem.

> **Pytanie do sali:** Który indeks odpowiada trzeciej turze?

---

## 2. Tablica i jej typ

Tablica przechowuje ustaloną liczbę elementów **tego samego typu**. Zapis `int[]` oznacza „tablica liczb całkowitych”, a `string[]` — „tablica tekstów”.

    int[] obrazenia = { 8, 12, 5 };
    string[] przeciwnicy = { "Szczur", "Goblin", "Szkielet" };
    bool[] otwarteDrzwi = { true, false, false };

Nie można umieścić tekstu w tablicy liczb:

    int[] punkty = { 10, 20, "trzydzieści" }; // błąd kompilacji

Jednolity typ pozwala kompilatorowi sprawdzać poprawność programu i umożliwia wykonywanie tej samej operacji na każdym elemencie.

### Trzy sposoby tworzenia tablicy

Gdy znamy wartości początkowe:

    string[] przedmioty = { "Miecz", "Tarcza", "Mikstura" };

Pełny zapis z użyciem `new`:

    string[] przedmioty = new string[] { "Miecz", "Tarcza", "Mikstura" };

Gdy znamy rozmiar, ale wartości uzupełnimy później:

    int[] wyniki = new int[5];

Rozmiar tablicy ustalony podczas jej tworzenia nie może później zostać zmieniony. Tablica `wyniki` zawsze ma pięć miejsc.

### Wartości domyślne

Po utworzeniu tablicy każde miejsce zawiera wartość domyślną swojego typu:

| Typ elementu | Wartość domyślna |
|---|---|
| `int`, `double` | `0` |
| `bool` | `false` |
| `string` | `null` |

    int[] punkty = new int[3];
    Console.WriteLine(punkty[0]); // 0

`null` oznacza brak obiektu lub tekstu. Aby od razu mieć bezpieczne napisy, możemy wypełnić tablicę podczas tworzenia.

---

## 3. Indeksy zaczynają się od zera

Element wybieramy, podając jego indeks w nawiasach kwadratowych:

    string[] przeciwnicy = { "Szczur", "Goblin", "Szkielet" };

    Console.WriteLine(przeciwnicy[0]); // Szczur
    Console.WriteLine(przeciwnicy[1]); // Goblin
    Console.WriteLine(przeciwnicy[2]); // Szkielet

Pierwszy element ma indeks 0. Dla tablicy o długości 3 poprawne indeksy to 0, 1 i 2.

> **Ostatni poprawny indeks to `Length - 1`.**

Element tablicy może być używany tak jak zwykła zmienna:

    int[] zdrowie = { 30, 20, 15 };

    zdrowie[1] = 25;
    zdrowie[2] -= 5;

    Console.WriteLine(zdrowie[1]); // 25
    Console.WriteLine(zdrowie[2]); // 10

### Numer widoczny dla gracza a indeks

Ludzie zwykle numerują elementy od 1, a program od 0. Jeżeli gracz wybiera przeciwnika numer 2, odpowiada mu indeks 1:

    int numer = 2;
    int indeks = numer - 1;
    Console.WriteLine(przeciwnicy[indeks]);

Warto nazywać zmienne precyzyjnie: `numer` dla wartości widocznej w menu i `indeks` dla pozycji w kolekcji.

---

## 4. Długość tablicy i bezpieczny zakres

Właściwość `Length` zwraca liczbę elementów tablicy:

    string[] lokacje = { "Brama", "Korytarz", "Komnata", "Skarbiec" };

    Console.WriteLine(lokacje.Length);             // 4
    Console.WriteLine(lokacje[0]);                 // pierwszy element
    Console.WriteLine(lokacje[lokacje.Length - 1]); // ostatni element

Odczyt spoza zakresu kończy program wyjątkiem `IndexOutOfRangeException`:

    Console.WriteLine(lokacje[4]); // błąd: indeks 4 nie istnieje

Przed użyciem indeksu pochodzącego od użytkownika trzeba go sprawdzić:

    Console.Write("Wybierz lokację od 1 do 4: ");

    if (int.TryParse(Console.ReadLine(), out int numer))
    {
        int indeks = numer - 1;

        if (indeks >= 0 && indeks < lokacje.Length)
        {
            Console.WriteLine($"Wybrano: {lokacje[indeks]}");
        }
        else
        {
            Console.WriteLine("Numer jest poza zakresem.");
        }
    }
    else
    {
        Console.WriteLine("Wpisz liczbę całkowitą.");
    }

Najpierw sprawdzamy format, później zakres, a dopiero na końcu odczytujemy element.

---

## 5. Iterowanie za pomocą for

Pętla `for` daje dostęp zarówno do indeksu, jak i wartości elementu:

    string[] przeciwnicy = { "Szczur", "Goblin", "Szkielet" };

    for (int i = 0; i < przeciwnicy.Length; i++)
    {
        Console.WriteLine($"Indeks {i}: {przeciwnicy[i]}");
    }

Warunek to `i < przeciwnicy.Length`, a nie `i <= przeciwnicy.Length`. Gdy `i` zrówna się z długością, pętla ma się zakończyć.

Jeżeli pokazujemy menu użytkownikowi, wyświetlany numer zwiększamy o 1:

    for (int i = 0; i < przeciwnicy.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {przeciwnicy[i]}");
    }

Pętla `for` jest dobrym wyborem, gdy:

- potrzebujemy indeksu,
- chcemy zmieniać elementy,
- przechodzimy tylko po części kolekcji,
- idziemy od końca do początku.

### Modyfikowanie wszystkich elementów

    int[] obrazenia = { 5, 8, 10 };

    for (int i = 0; i < obrazenia.Length; i++)
    {
        obrazenia[i] += 2;
    }

Po pętli tablica zawiera wartości 7, 10 i 12.

---

## 6. Iterowanie za pomocą foreach

Pętla `foreach` pobiera kolejno każdy element kolekcji. Nie musimy samodzielnie zarządzać indeksem:

    string[] przedmioty = { "Miecz", "Tarcza", "Mikstura" };

    foreach (string przedmiot in przedmioty)
    {
        Console.WriteLine(przedmiot);
    }

Czytamy to jako: „dla każdego tekstu `przedmiot` w tablicy `przedmioty` wykonaj blok”.

`foreach` jest dobrym wyborem, gdy chcemy odczytać wszystkie elementy od początku do końca, nie potrzebujemy indeksu i nie zmieniamy struktury kolekcji.

Zmienna pętli jest tylko bieżącą wartością i nie można przypisać do niej nowej wartości:

    foreach (int obrazenie in obrazenia)
    {
        obrazenie += 2; // błąd kompilacji
    }

Do zmiany elementów tablicy używamy `for` i zapisu `obrazenia[i]`.

| Potrzeba | Pętla |
|---|---|
| tylko odczytać wszystkie elementy | `foreach` |
| znać indeks elementu | `for` |
| zmienić element tablicy | `for` |
| przejść od końca | `for` |

---

## 7. Wczytywanie danych do tablicy

Rozmiar tablicy może pochodzić ze zmiennej:

    Console.Write("Ile tur chcesz zapisać? ");
    int liczbaTur = int.Parse(Console.ReadLine()!);

    int[] zlotoWTurach = new int[liczbaTur];

    for (int i = 0; i < zlotoWTurach.Length; i++)
    {
        Console.Write($"Złoto w turze {i + 1}: ");
        zlotoWTurach[i] = int.Parse(Console.ReadLine()!);
    }

    Console.WriteLine("Zapisane wyniki:");

    foreach (int zloto in zlotoWTurach)
    {
        Console.WriteLine(zloto);
    }

Po utworzeniu tablicy liczba jej miejsc pozostaje stała, nawet jeżeli później zmienimy zmienną `liczbaTur`.

---

## 8. Suma i średnia

Kolekcje często przetwarzamy za pomocą akumulatora:

    int[] zlotoWTurach = { 4, 10, 0, 7, 12 };
    int suma = 0;

    foreach (int zloto in zlotoWTurach)
    {
        suma += zloto;
    }

    double srednia = (double)suma / zlotoWTurach.Length;

    Console.WriteLine($"Suma: {suma}");
    Console.WriteLine($"Średnia: {srednia:F2}");

Rzutowanie `(double)` sprawia, że dzielenie nie odrzuca części ułamkowej. Przed obliczeniem średniej dla kolekcji tworzonej dynamicznie trzeba upewnić się, że nie jest pusta — nie wolno dzielić przez zero.

---

## 9. Minimum i maksimum

Najbezpieczniej rozpocząć od pierwszego elementu, a następnie porównywać z nim pozostałe:

    int[] obrazenia = { 8, 3, 12, 6 };
    int najmniejsze = obrazenia[0];
    int najwieksze = obrazenia[0];

    for (int i = 1; i < obrazenia.Length; i++)
    {
        if (obrazenia[i] < najmniejsze)
        {
            najmniejsze = obrazenia[i];
        }

        if (obrazenia[i] > najwieksze)
        {
            najwieksze = obrazenia[i];
        }
    }

    Console.WriteLine($"Minimum: {najmniejsze}");
    Console.WriteLine($"Maksimum: {najwieksze}");

Pętla zaczyna się od indeksu 1, ponieważ element o indeksie 0 posłużył do ustawienia wartości początkowych.

Nie zawsze poprawnie jest zaczynać od zera:

    int najwieksze = 0; // źle, jeżeli wszystkie dane są ujemne

Dla tablicy `{ -8, -3, -12 }` program błędnie pozostawiłby maksimum 0, chociaż zera nie ma w danych.

> **Ważne:** algorytm korzystający z elementu `[0]` wymaga kolekcji zawierającej co najmniej jeden element.

---

## 10. Wyszukiwanie i zliczanie

### Czy element istnieje?

    string[] ekwipunek = { "Miecz", "Klucz", "Mikstura" };
    bool znaleziono = false;

    foreach (string przedmiot in ekwipunek)
    {
        if (przedmiot == "Klucz")
        {
            znaleziono = true;
            break;
        }
    }

    Console.WriteLine(znaleziono ? "Masz klucz." : "Nie masz klucza.");

Po znalezieniu wartości dalsze sprawdzanie nie jest potrzebne, dlatego używamy `break`.

### Na którym indeksie znajduje się element?

    int znalezionyIndeks = -1;

    for (int i = 0; i < ekwipunek.Length; i++)
    {
        if (ekwipunek[i] == "Klucz")
        {
            znalezionyIndeks = i;
            break;
        }
    }

Wartość `-1` oznacza „nie znaleziono”, ponieważ poprawne indeksy nigdy nie są ujemne.

### Ile razy występuje wartość?

    string[] lupy = { "Moneta", "Mikstura", "Moneta", "Klucz", "Moneta" };
    int liczbaMonet = 0;

    foreach (string lup in lupy)
    {
        if (lup == "Moneta")
        {
            liczbaMonet++;
        }
    }

    Console.WriteLine($"Liczba monet: {liczbaMonet}");

To trzy różne pytania: czy element istnieje, gdzie jest pierwszy element oraz ile razy element występuje. Wybór algorytmu zależy od potrzebnego wyniku.

---

## 11. Lista — kolekcja o zmiennym rozmiarze

Tablica dobrze działa, gdy liczba elementów jest znana i stała. Zawartość plecaka zmienia się podczas gry: przedmioty są znajdowane i zużywane. Do tego lepiej pasuje `List<T>`.

    List<string> plecak = new List<string>();

Zapis w nawiasach ostrych określa typ elementu:

- `List<string>` — lista tekstów,
- `List<int>` — lista liczb całkowitych,
- `List<bool>` — lista wartości logicznych.

Można od razu podać elementy początkowe:

    List<string> plecak = new List<string>
    {
        "Miecz",
        "Mikstura"
    };

W nowszych projektach .NET przestrzeń nazw potrzebna dla `List<T>` jest zwykle dołączana automatycznie. Jeżeli kompilator nie rozpoznaje `List`, na początku pliku dodaj:

    using System.Collections.Generic;

---

## 12. Podstawowe operacje na liście

### Count i indeksowanie

Lista używa właściwości `Count`, natomiast tablica — `Length`:

    Console.WriteLine(plecak.Count);
    Console.WriteLine(plecak[0]);
    plecak[0] = "Stalowy miecz";

### Dodawanie

    plecak.Add("Klucz");
    plecak.Add("Pochodnia");

`Add` umieszcza element na końcu listy i zwiększa `Count`.

### Sprawdzanie i wyszukiwanie

    bool maKlucz = plecak.Contains("Klucz");
    int indeksMikstury = plecak.IndexOf("Mikstura");

`Contains` zwraca `true` albo `false`. `IndexOf` zwraca indeks pierwszego wystąpienia lub `-1`, gdy elementu nie ma. Porównywanie tekstów jest wrażliwe na wielkość liter: `"klucz"` i `"Klucz"` to różne wartości.

### Usuwanie po wartości

    bool usunieto = plecak.Remove("Mikstura");

`Remove` usuwa pierwsze wystąpienie wartości i informuje, czy operacja się udała.

### Usuwanie po indeksie

    int indeks = 1;

    if (indeks >= 0 && indeks < plecak.Count)
    {
        plecak.RemoveAt(indeks);
    }

`RemoveAt` wymaga poprawnego indeksu i nie zwraca wartości logicznej. Po usunięciu późniejsze elementy przesuwają się o jedno miejsce w lewo.

### Usuwanie wszystkich elementów

    plecak.Clear();

Po `Clear` lista nadal istnieje, ale jej `Count` wynosi 0.

| Operacja | Znaczenie |
|---|---|
| `lista.Count` | liczba elementów |
| `lista.Add(wartosc)` | dodaje na końcu |
| `lista.Contains(wartosc)` | sprawdza obecność |
| `lista.IndexOf(wartosc)` | zwraca pierwszy indeks lub `-1` |
| `lista.Remove(wartosc)` | usuwa pierwsze wystąpienie |
| `lista.RemoveAt(indeks)` | usuwa element pod indeksem |
| `lista.Clear()` | usuwa wszystkie elementy |

---

## 13. Iterowanie po liście

Po liście można przechodzić tak samo jak po tablicy:

    for (int i = 0; i < plecak.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plecak[i]}");
    }

    foreach (string przedmiot in plecak)
    {
        Console.WriteLine(przedmiot);
    }

Nie wolno zmieniać rozmiaru listy wewnątrz `foreach`:

    foreach (string przedmiot in plecak)
    {
        if (przedmiot == "Mikstura")
        {
            plecak.Remove(przedmiot); // błąd podczas działania programu
        }
    }

Pętla `foreach` śledzi przebieg kolekcji. Dodanie lub usunięcie elementu unieważnia ten przebieg i zwykle powoduje `InvalidOperationException`.

Jeśli chcemy usuwać wiele elementów według warunku bez LINQ, możemy przejść od końca:

    for (int i = plecak.Count - 1; i >= 0; i--)
    {
        if (plecak[i] == "Zużyta pochodnia")
        {
            plecak.RemoveAt(i);
        }
    }

Idąc od końca, nie pomijamy elementów, które po usunięciu przesunęły się w lewo.

---

## 14. Słownik — wartości dostępne przez klucz

Tablica i lista identyfikują element przez indeks liczbowy. Czasem naturalniejszym identyfikatorem jest nazwa przedmiotu, kod lokacji albo imię postaci. Wtedy przydaje się `Dictionary<TKey, TValue>` — kolekcja par **klucz–wartość**.

    Dictionary<string, int> ceny = new Dictionary<string, int>
    {
        { "Mikstura", 15 },
        { "Pochodnia", 5 },
        { "Miecz", 40 }
    };

W tym przykładzie kluczem jest `string`, a wartością `int`. Każdy klucz musi być unikalny, natomiast wartości mogą się powtarzać. Jeżeli kompilator nie rozpoznaje typu `Dictionary`, dodaj `using System.Collections.Generic;`.

### Odczyt i zmiana wartości

    Console.WriteLine(ceny["Mikstura"]); // 15
    ceny["Mikstura"] = 12;

Odwołanie do nieistniejącego klucza przez nawiasy kwadratowe powoduje `KeyNotFoundException`. Klucz pochodzący od użytkownika należy najpierw sprawdzić:

    Console.Write("Podaj nazwę przedmiotu: ");
    string nazwa = Console.ReadLine()!;

    if (ceny.ContainsKey(nazwa))
    {
        Console.WriteLine($"Cena: {ceny[nazwa]} sztuk złota");
    }
    else
    {
        Console.WriteLine("Nie ma takiego przedmiotu.");
    }

### Dodawanie, usuwanie i iterowanie

    ceny.Add("Tarcza", 30);
    bool usunieto = ceny.Remove("Pochodnia");

`Add` wymaga nowego klucza. Ponowne dodanie istniejącego klucza powoduje błąd. Indekser może zmienić istniejącą wartość lub dodać nową parę:

    ceny["Miecz"] = 45;       // zmiana
    ceny["Zwój"] = 20;        // dodanie

Po parach słownika przechodzimy pętlą `foreach`:

    foreach (KeyValuePair<string, int> para in ceny)
    {
        Console.WriteLine($"{para.Key}: {para.Value} sztuk złota");
    }

`para.Key` oznacza klucz, a `para.Value` przypisaną mu wartość. Słownik ma właściwość `Count`, podobnie jak lista.

| Operacja | Znaczenie |
|---|---|
| `slownik.Count` | liczba par |
| `slownik.Add(klucz, wartosc)` | dodaje nową parę |
| `slownik.ContainsKey(klucz)` | sprawdza istnienie klucza |
| `slownik[klucz]` | odczytuje lub ustawia wartość |
| `slownik.Remove(klucz)` | usuwa parę i zwraca wynik operacji |
| `slownik.Clear()` | usuwa wszystkie pary |

> **Ważne:** nie zmieniaj rozmiaru słownika przez `Add`, `Remove` ani `Clear` wewnątrz `foreach` iterującego po tym słowniku.

---

## 15. Tablica, lista czy słownik?

| Cecha | Tablica `T[]` | Lista `List<T>` | Słownik `Dictionary<TKey, TValue>` |
|---|---|---|---|
| Rozmiar | stały po utworzeniu | może się zmieniać | może się zmieniać |
| Liczba elementów | `Length` | `Count` | `Count` |
| Sposób dostępu | indeks liczbowy | indeks liczbowy | unikalny klucz |
| Dodawanie i usuwanie | brak prostych operacji | `Add`, `Remove`, `RemoveAt` | `Add`, `Remove` |
| Przykład | wyniki 5 tur | zawartość plecaka | ceny przedmiotów |

Wybierz tablicę, gdy liczba miejsc jest częścią problemu, np. siedem dni tygodnia, trzy próby albo wyniki ustalonej liczby tur.

Wybierz listę, gdy elementy pojawiają się i znikają, np. ekwipunek, historia akcji albo lista odkrytych lokacji.

Lista nie jest „lepszą tablicą” w każdej sytuacji. Dobry typ kolekcji pokazuje zamiar programu.

Wybierz słownik, gdy chcesz znaleźć wartość na podstawie znaczącego, unikalnego klucza, np. cenę według nazwy przedmiotu albo liczbę odwiedzin według nazwy lokacji. Do danych uporządkowanych pozycją lepiej pasuje tablica lub lista.

---

## 16. Kolekcje w pętli gry

Lista może przechowywać historię akcji wykonanych podczas gry:

    List<string> historia = new List<string>();
    bool graDziala = true;

    while (graDziala)
    {
        Console.WriteLine("1 - Eksploruj");
        Console.WriteLine("2 - Pokaż historię");
        Console.WriteLine("3 - Wyjdź");
        Console.Write("Wybór: ");

        string wybor = Console.ReadLine()!;

        switch (wybor)
        {
            case "1":
                Console.WriteLine("Bohater bada korytarz.");
                historia.Add("Zbadano korytarz.");
                break;

            case "2":
                if (historia.Count == 0)
                {
                    Console.WriteLine("Historia jest pusta.");
                }
                else
                {
                    for (int i = 0; i < historia.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {historia[i]}");
                    }
                }
                break;

            case "3":
                graDziala = false;
                break;

            default:
                Console.WriteLine("Nieznana opcja.");
                break;
        }
    }

Każda poprawna akcja może dopisać nowy element, a lista sama zwiększa swój rozmiar. Wyświetlenie historii nie wymaga wiedzy, ile wpisów powstało wcześniej.

---

## 17. Najczęstsze błędy

### Użycie długości jako indeksu

    int ostatni = wyniki[wyniki.Length]; // błąd

Poprawny ostatni indeks to `wyniki.Length - 1`.

### Warunek <= w pętli

    for (int i = 0; i <= wyniki.Length; i++)
    {
        Console.WriteLine(wyniki[i]);
    }

Ostatnia iteracja próbuje użyć nieistniejącego indeksu. Warunek powinien brzmieć `i < wyniki.Length`.

### Pomylenie numeru z indeksem

Gracz wybiera pozycję 1, ale program odczytuje `lista[1]`, czyli drugi element. Dla numeracji od 1 potrzebne jest `int indeks = numer - 1`.

### Pomylenie Length i Count

    tablica.Length
    lista.Count

### Minimum dla pustej kolekcji

    int minimum = wyniki[0];

Ten zapis nie działa dla pustej kolekcji. Najpierw trzeba sprawdzić `Length > 0` lub `Count > 0`.

### Usuwanie podczas foreach

Nie dodawaj ani nie usuwaj elementów listy w trakcie `foreach`. Użyj pojedynczego `Remove`, indeksu albo pętli `for` biegnącej od końca.

### Utrata listy przez ponowne utworzenie

    while (graDziala)
    {
        List<string> historia = new List<string>();
        // lista jest tworzona od nowa w każdej iteracji
    }

Kolekcje przechowujące stan gry trzeba utworzyć **przed** główną pętlą.

### Odczyt nieistniejącego klucza

    int cena = ceny["Łuk"]; // błąd, jeśli klucza nie ma

Przed odczytem klucza pochodzącego od użytkownika sprawdź `ceny.ContainsKey("Łuk")`.

### Ponowne dodanie tego samego klucza

    ceny.Add("Miecz", 40);
    ceny.Add("Miecz", 45); // błąd: klucz już istnieje

Klucze słownika muszą być unikalne. Istniejącą wartość zmieniamy przez `ceny["Miecz"] = 45`.

---

## 18. Przykład przewodni — raport wyprawy i plecak

Poniższy fragment łączy tablicę stałych wyników z listą zmiennego ekwipunku:

    int[] zlotoWTurach = { 5, 0, 12, 8, 12 };
    List<string> plecak = new List<string>
    {
        "Miecz",
        "Mikstura"
    };

    int sumaZlota = 0;
    int najwiecejZlota = zlotoWTurach[0];
    int najlepszaTura = 1;

    for (int i = 0; i < zlotoWTurach.Length; i++)
    {
        sumaZlota += zlotoWTurach[i];

        if (zlotoWTurach[i] > najwiecejZlota)
        {
            najwiecejZlota = zlotoWTurach[i];
            najlepszaTura = i + 1;
        }
    }

    plecak.Add("Klucz");

    if (plecak.Contains("Mikstura"))
    {
        plecak.Remove("Mikstura");
        Console.WriteLine("Bohater używa mikstury.");
    }

    Console.WriteLine($"Łączne złoto: {sumaZlota}");
    Console.WriteLine($"Najlepszy wynik: {najwiecejZlota}, tura {najlepszaTura}");
    Console.WriteLine("Pozostałe przedmioty:");

    for (int i = 0; i < plecak.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plecak[i]}");
    }

Warunek `>` sprawia, że przy remisie zapamiętujemy pierwszą turę z najlepszym wynikiem. Gdyby użyć `>=`, zapamiętalibyśmy ostatnią taką turę.

---

## Podsumowanie

- kolekcja przechowuje wiele elementów tego samego typu,
- tablica ma stały rozmiar, a lista może go zmieniać,
- indeksy zaczynają się od 0,
- ostatni poprawny indeks to liczba elementów minus 1,
- tablica podaje liczbę elementów przez `Length`, a lista przez `Count`,
- `for` jest przydatne, gdy potrzebujemy indeksu lub zmieniamy elementy,
- `foreach` upraszcza odczyt wszystkich elementów,
- sumę, minimum, maksimum, wyszukiwanie i zliczanie można wykonać pętlą,
- `Add` dodaje element do listy, `Remove` usuwa po wartości, a `RemoveAt` po indeksie,
- słownik przechowuje pary klucz–wartość, a każdy klucz musi być unikalny,
- `ContainsKey` pozwala bezpiecznie sprawdzić klucz przed odczytem,
- każdy indeks pochodzący od użytkownika trzeba sprawdzić przed użyciem,
- nie należy zmieniać rozmiaru listy podczas `foreach`.

## Ściąga

    int[] wyniki = { 4, 10, 7 };
    int[] pustaTablica = new int[5];

    Console.WriteLine(wyniki.Length);
    Console.WriteLine(wyniki[0]);

    for (int i = 0; i < wyniki.Length; i++)
    {
        Console.WriteLine(wyniki[i]);
    }

    foreach (int wynik in wyniki)
    {
        Console.WriteLine(wynik);
    }

    List<string> plecak = new List<string>();
    plecak.Add("Mikstura");

    bool maMiksture = plecak.Contains("Mikstura");
    int indeks = plecak.IndexOf("Mikstura");
    bool usunieto = plecak.Remove("Mikstura");

    if (indeks >= 0 && indeks < plecak.Count)
    {
        plecak.RemoveAt(indeks);
    }

    Dictionary<string, int> ceny = new Dictionary<string, int>();
    ceny.Add("Mikstura", 15);
    ceny["Mikstura"] = 12;

    if (ceny.ContainsKey("Mikstura"))
    {
        Console.WriteLine(ceny["Mikstura"]);
    }

    foreach (KeyValuePair<string, int> para in ceny)
    {
        Console.WriteLine($"{para.Key}: {para.Value}");
    }
