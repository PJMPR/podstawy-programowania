# Audyt programu kursu — tygodnie 5–15

## Cel i założenia audytu

Audyt odpowiada na trzy pytania:

1. Czy temat wykładu naturalnie wypełnia 90 minut bez sztucznego rozciągania?
2. Czy laboratorium wykorzystuje materiał poznany najpóźniej na wykładzie z tego samego tygodnia?
3. Czy kolejne tygodnie prowadzą początkującą osobę do kompletnej konsolowej gry typu roguelike?

Zakładam zajęcia dla osób początkujących oraz 90 minut czasu kalendarzowego na wykład i 90 minut na laboratorium. Wykład nie powinien oznaczać 90 minut nieprzerwanej teorii. W podanych rozkładach znajdują się również demonstracje kodu, krótkie pytania do grupy, przewidywanie wyniku programu i podsumowanie.

## Wnioski ogólne

Plan ma dobry kierunek i pozwala doprowadzić projekt do działającej gry. Przed rozwinięciem materiałów potrzebne są jednak cztery korekty.

### 1. Należy zmienić kolejność tygodni 6–8

Obecne laboratorium 6 wymaga metod, chociaż wykład o metodach jest dopiero w tygodniu 7. Laboratorium 7 wymaga losowości, podczas gdy wykład o `Random` przypada na tydzień 8. Najbardziej naturalna kolejność to:

- tydzień 5 — tablice i listy,
- tydzień 6 — metody i organizacja kodu,
- tydzień 7 — losowość i mechanika walki,
- tydzień 8 — słowniki i przetwarzanie kolekcji.

Nie oznacza to usunięcia żadnego tematu, tylko zamianę kolejności wykładów 6–8.

### 2. Większość placeholderów laboratoriów nie odpowiada swoim tytułom

Listy zadań w laboratoriach 5–14 wyglądają jak pozostałość wcześniejszego planu. Przykłady:

- laboratorium 5 wprowadza mapę 2D, którą wykład omawia dopiero w tygodniu 9,
- laboratorium 7 zawiera lambdy, callbacki i optymalizację zamiast walki losowej,
- laboratorium 8 dotyczy rekurencji zamiast ekwipunku,
- laboratorium 9 dotyczy LINQ zamiast mapy lochu,
- laboratorium 13 dotyczy struktur i enumeracji zamiast zapisu gry,
- laboratorium 14 dotyczy profilowania i FPS, mimo że powstaje gra konsolowa.

Te zadania powinny zostać napisane od nowa na podstawie tytułów i efektów uczenia się.

### 3. Temat tygodnia 9 wystarczy na 90 minut pod warunkiem zachowania kontekstu gry

Same operacje na `char[,]` byłyby zbyt wąskie. Pełny temat „Tablice dwuwymiarowe i reprezentacja świata gry” jest jednak wystarczający, ponieważ łączy składnię, układ współrzędnych, zagnieżdżone pętle, model danych, renderowanie mapy i bezpieczeństwo indeksów.

### 4. Tygodnie 14 i 15 muszą mieć różne funkcje

- tydzień 14 powinien służyć diagnozowaniu, testowaniu i stabilizacji wersji 0.9,
- tydzień 15 powinien służyć kontrolowanej refaktoryzacji, finalizacji i prezentacji wersji 1.0.

Bez tego oba tygodnie łatwo zamienią się w ogólne „dokończ projekt”.

## Rekomendowana mapa tygodni

| Tydzień | Rekomendowany wykład | Rekomendowane laboratorium | Ocena 90 minut |
|---:|---|---|---|
| 5 | Tablice i listy | Kolekcje w działającej pętli gry | odpowiedni |
| 6 | Metody i organizacja kodu | Porządkowanie gry za pomocą metod | odpowiedni |
| 7 | Losowość i mechanika walki | Walka i zdarzenia losowe | odpowiedni |
| 8 | Słowniki i przetwarzanie kolekcji | Ekwipunek bohatera | odpowiedni |
| 9 | Tablice 2D i świat gry | Pierwsza mapa lochu | odpowiedni, jeśli temat pozostanie praktyczny |
| 10 | Ruch, wejście i kolizje | Sterowanie WASD, ściany i interakcje | obszerny, wymaga pilnowania zakresu |
| 11 | Klasy i obiekty | Bohater i przeciwnicy jako obiekty | odpowiedni |
| 12 | Stan gry i przepływ rozgrywki | Poziomy, interfejs i stany gry | odpowiedni |
| 13 | Pliki i zapis danych | Save / Load | odpowiedni |
| 14 | Debugowanie i obsługa błędów | Rogue 0.9 — testowanie i stabilizacja | odpowiedni |
| 15 | Integracja i dobre praktyki | Rogue 1.0 — finalizacja i prezentacja | odpowiedni jako wykład podsumowujący |

## Audyt szczegółowy

### Tydzień 5 — tablice i listy

**Ocena:** temat bez problemu wypełni 90 minut. Jest nawet ryzyko przeciążenia, jeśli zostaną dodane zaawansowane operacje albo LINQ.

**Zakres na wykład:**

- problem przechowywania wielu wartości tego samego rodzaju,
- deklarowanie, inicjalizowanie i indeksowanie tablic,
- indeksy od zera i ostatni poprawny indeks,
- odczyt i modyfikacja elementów,
- `Length`, `for` oraz `foreach`,
- wyszukiwanie, suma, minimum i maksimum wykonywane ręcznie,
- ograniczenia stałego rozmiaru tablicy,
- `List<T>`, `Count`, `Add`, `Remove`, `RemoveAt`, `Contains`,
- wybór między tablicą a listą,
- typowe błędy: wyjście poza zakres i modyfikowanie listy w `foreach`.

**Proponowany rozkład 90 minut:**

| Część | Czas |
|---|---:|
| Motywacja i tablica jako zbiór danych | 10 min |
| Tworzenie, indeksowanie i modyfikacja tablic | 15 min |
| Iterowanie za pomocą `for` i `foreach` | 15 min |
| Proste algorytmy na tablicach | 15 min |
| `List<T>` i zmienny rozmiar kolekcji | 20 min |
| Tablica czy lista, błędy i podsumowanie | 15 min |

**Laboratorium:** obecny tytuł „Game loop” częściowo powtarza tydzień 4, a placeholder błędnie wprowadza tablice 2D i ruch. Laboratorium powinno utrwalić kolekcje wewnątrz istniejącej pętli gry, np. listę przedmiotów, historię wykonanych akcji, tablicę nazw przeciwników oraz ręczne wyszukiwanie wartości. Nie należy jeszcze używać mapy 2D, słowników ani metod definiowanych przez studenta.

**Ryzyko:** `List<T>` wymaga krótkiego wyjaśnienia typów generycznych, ale bez wykładu o generykach jako osobnym mechanizmie.

### Tydzień 6 — metody i organizacja kodu

**Ocena:** bardzo dobry temat na 90 minut i konieczny przed dalszym rozrostem projektu.

**Rekomendacja programowa:** przenieść tutaj obecny wykład tygodnia 7.

**Zakres na wykład:**

- problem powtarzającego się i zbyt długiego kodu,
- deklaracja oraz wywołanie metody,
- metody `void`,
- parametry i argumenty,
- wartości zwracane oraz `return`,
- zasięg zmiennych lokalnych,
- przepływ danych do metody i z metody,
- rozbijanie zadania na mniejsze operacje,
- różnica między metodą wykonującą obliczenie a metodą obsługującą konsolę.

**Proponowany rozkład 90 minut:**

| Część | Czas |
|---|---:|
| Po co wydzielać metody | 10 min |
| Definicja, wywołanie i `void` | 15 min |
| Parametry i argumenty | 15 min |
| Zwracanie wartości | 15 min |
| Zasięg i przepływ danych | 15 min |
| Refaktoryzacja fragmentu gry na żywo | 15 min |
| Podsumowanie | 5 min |

**Laboratorium:** tytuł „Porządkowanie gry” pasuje bardzo dobrze. Należy wydzielić między innymi `ShowStatus`, `ShowMenu`, `ReadCommand`, `Attack` i `Heal`. Nie należy wprowadzać `ref`, `out`, delegatów, lambd ani callbacków. Dla początkujących zaciemniłyby podstawowy model parametrów i wartości zwracanych.

**Ryzyko:** refaktoryzacja całej gry może przekroczyć 90 minut. Trzeba dostarczyć działający kod startowy i jasno wskazać 4–5 fragmentów do wydzielenia.

### Tydzień 7 — losowość i mechanika walki

**Ocena:** materiał wystarczy na 90 minut, jeśli losowość zostanie połączona z projektowaniem i testowaniem reguł, a nie ograniczona do składni `Random.Next`.

**Rekomendacja programowa:** przenieść tutaj obecny wykład tygodnia 8.

**Zakres na wykład:**

- wartości pseudolosowe i jeden współdzielony obiekt `Random`,
- zakres dolny włącznie i górny wyłącznie,
- losowanie elementu tablicy lub listy,
- modelowanie prawdopodobieństwa,
- zakres obrażeń, trafienie krytyczne i unik,
- kolejność jednej tury walki,
- oddzielenie obliczeń od komunikatów,
- testowanie mechaniki zależnej od losowości,
- granice statystyk, np. zdrowie nie mniejsze niż zero.

**Proponowany rozkład 90 minut:**

| Część | Czas |
|---|---:|
| Czym jest pseudolosowość | 10 min |
| `Random` i zakresy losowania | 15 min |
| Losowanie elementów i zdarzeń | 15 min |
| Projekt algorytmu walki | 20 min |
| Krytyki, uniki i balans wartości | 15 min |
| Testowanie oraz typowe błędy | 10 min |
| Podsumowanie | 5 min |

**Laboratorium:** „Walka i zdarzenia losowe” jest naturalnym zastosowaniem. Studenci mogą dodać przeciwnika, obrażenia z zakresu, szansę na krytyk, losowy skarb oraz pełną pętlę walki opartą na metodach z tygodnia 6.

**Ryzyko:** nie należy wprowadzać systemu zdarzeń C#, delegatów ani wyrażeń lambda. Słowo „zdarzenie” oznacza tutaj zdarzenie w świecie gry, a nie mechanizm języka `event`.

### Tydzień 8 — słowniki i przetwarzanie kolekcji

**Ocena:** temat wystarczy na 90 minut, ale powinien koncentrować się na podstawowych algorytmach, bez LINQ.

**Rekomendacja programowa:** przenieść tutaj obecny wykład tygodnia 6.

**Zakres na wykład:**

- kiedy indeks liczbowy przestaje wystarczać,
- para klucz–wartość,
- tworzenie `Dictionary<TKey, TValue>`,
- dodawanie, odczyt i aktualizacja,
- unikalność kluczy,
- `ContainsKey` i `TryGetValue`,
- iterowanie po parach,
- zliczanie wystąpień,
- ręczne filtrowanie listy,
- porównanie tablicy, listy i słownika.

**Proponowany rozkład 90 minut:**

| Część | Czas |
|---|---:|
| Motywacja i model klucz–wartość | 10 min |
| Tworzenie i modyfikacja słownika | 20 min |
| Bezpieczny odczyt wartości | 15 min |
| Iterowanie po słowniku | 10 min |
| Zliczanie oraz filtrowanie danych | 15 min |
| Dobór właściwej kolekcji | 15 min |
| Podsumowanie | 5 min |

**Laboratorium:** „Ekwipunek bohatera” pasuje do list i słowników. Lista może przechowywać posiadane przedmioty, a słownik opisy przedmiotów, ceny albo siłę leczenia. Zadania powinny obejmować dodawanie, używanie, usuwanie i bezpieczne wyszukiwanie przedmiotów.

**Ryzyko:** obecny placeholder o rekurencji należy usunąć. Rekurencja, pathfinding, flood fill i głębokość stosu nie są potrzebne do osiągnięcia celów tego kursu.

### Tydzień 9 — tablice dwuwymiarowe i reprezentacja świata gry

**Ocena:** temat wypełni 90 minut, lecz tylko jako połączenie struktury danych z konkretnym modelem mapy. Same deklaracje tablic 2D zajęłyby około 30–40 minut.

**Zakres na wykład:**

- przejście od tablicy 1D do siatki,
- deklarowanie i inicjalizowanie `char[,]`,
- pierwszy oraz drugi wymiar,
- `GetLength(0)` i `GetLength(1)`,
- zagnieżdżone pętle,
- rozróżnienie `wiersz/kolumna` oraz `x/y`,
- symbole mapy i ich znaczenie,
- renderowanie mapy w konsoli,
- modyfikacja wybranego pola,
- sprawdzanie granic przed odczytem,
- rozdzielenie danych mapy od sposobu ich wyświetlania.

**Proponowany rozkład 90 minut:**

| Część | Czas |
|---|---:|
| Od listy do planszy | 10 min |
| Deklarowanie i indeksowanie tablicy 2D | 15 min |
| Wymiary i zagnieżdżone pętle | 15 min |
| Układ współrzędnych i typowe pomyłki | 15 min |
| Mapa z symboli i jej renderowanie | 20 min |
| Modyfikowanie pól i kontrola granic | 10 min |
| Podsumowanie | 5 min |

**Laboratorium:** należy rzeczywiście zbudować „Pierwszą mapę lochu”: utworzyć `char[,]`, wyświetlić legendę, znaleźć pozycję startową, zmienić wybrane pola i przygotować mapę do ruchu w kolejnym tygodniu. Nie należy jeszcze implementować pełnego sterowania ani kolizji.

**Ryzyko:** konsekwentnie trzeba ustalić jedną konwencję, np. `mapa[y, x]`. Mieszanie `x/y` z `wiersz/kolumna` jest jednym z najbardziej prawdopodobnych źródeł błędów.

### Tydzień 10 — ruch, wejście i kolizje

**Ocena:** temat jest wystarczający, a nawet szeroki. W 90 minut zmieści się ruch i podstawowe kolizje; rozbudowane interakcje trzeba ograniczyć.

**Zakres na wykład:**

- `Console.ReadKey(true)` i rozpoznawanie klawiszy,
- pozycja bieżąca oraz pozycja proponowana,
- zamiana kierunku na zmianę współrzędnych,
- sprawdzanie granic przed dostępem do tablicy,
- pola przechodnie i blokujące,
- zatwierdzanie albo odrzucanie ruchu,
- proste interakcje po wejściu na pole,
- pętla: renderowanie → wejście → aktualizacja → sprawdzenie końca,
- oddzielenie wejścia, reguł i renderowania.

**Proponowany rozkład 90 minut:**

| Część | Czas |
|---|---:|
| Odczyt klawisza i kierunki | 15 min |
| Aktualna i proponowana pozycja | 15 min |
| Granice mapy | 15 min |
| Kolizje ze ścianami | 15 min |
| Interakcje oraz warunek wygranej | 15 min |
| Złożenie pełnej iteracji gry | 10 min |
| Podsumowanie | 5 min |

**Laboratorium:** obecne „Sterowanie WASD” należy połączyć z podstawowymi ścianami i przeszkodami, ponieważ wynikają bezpośrednio z tego wykładu. Student powinien poruszać `@`, nie wychodzić poza planszę, nie przechodzić przez `#` i móc dotrzeć do wyjścia.

**Ryzyko:** czyszczenie i ponowne rysowanie całej konsoli może migotać, ale optymalizacja renderowania nie powinna stać się tematem kursu podstaw programowania.

### Tydzień 11 — klasy i obiekty

**Ocena:** bardzo dobry zakres na 90 minut. Trzeba utrzymać praktyczne, ograniczone wprowadzenie do programowania obiektowego.

**Zakres na wykład:**

- problem wielu luźnych zmiennych opisujących jeden byt,
- klasa jako opis, obiekt jako konkretna instancja,
- tworzenie klasy i obiektu,
- pola a właściwości,
- konstruktor w podstawowym zakresie,
- metody instancji,
- `Player` i `Enemy`,
- lista obiektów przeciwników,
- przenoszenie danych i zachowań do klasy,
- typ referencyjny pokazany na przykładzie, bez rozbudowanej teorii pamięci.

**Proponowany rozkład 90 minut:**

| Część | Czas |
|---|---:|
| Motywacja: dane opisujące jeden obiekt | 10 min |
| Klasa i tworzenie obiektu | 15 min |
| Pola, właściwości i konstruktor | 20 min |
| Metody instancji | 15 min |
| Klasy `Player` i `Enemy` | 15 min |
| Refaktoryzacja istniejącego fragmentu | 10 min |
| Podsumowanie | 5 min |

**Laboratorium:** obecne „Ściany, drzwi i przeszkody” nie ćwiczy klas. Kolizje powinny być ukończone w tygodniu 10. Laboratorium 11 powinno przekształcić dane bohatera i przeciwników w obiekty, utworzyć kilku przeciwników i używać ich właściwości oraz metod w walce.

**Ryzyko:** nie należy dokładać dziedziczenia, interfejsów, klas abstrakcyjnych ani polimorfizmu. Na tym etapie ważniejsze jest dobre zrozumienie obiektu i jego stanu.

### Tydzień 12 — stan gry i przepływ rozgrywki

**Ocena:** temat może wypełnić 90 minut, ale wymaga precyzyjnego określenia, czym różni się od pętli gry z tygodnia 4.

**Zakres na wykład:**

- rozproszony stan a jeden model stanu gry,
- dane gracza, mapy i bieżącego poziomu,
- fazy: menu, rozgrywka, zwycięstwo, porażka,
- `enum` jako czytelna reprezentacja skończonego zestawu stanów,
- przejścia między stanami,
- rozpoczęcie nowej gry i reset danych,
- przejście do następnego poziomu,
- warunki zakończenia,
- interfejs konsolowy jako widok aktualnego stanu.

**Proponowany rozkład 90 minut:**

| Część | Czas |
|---|---:|
| Co składa się na stan gry | 10 min |
| Fazy rozgrywki i `enum` | 15 min |
| Przejścia między stanami | 20 min |
| Nowa gra, reset i kolejny poziom | 15 min |
| Warunki zwycięstwa i porażki | 10 min |
| Interfejs odzwierciedlający stan | 15 min |
| Podsumowanie | 5 min |

**Laboratorium:** „Interfejs gry” powinno łączyć czytelny ekran z rzeczywistym stanem: mapa, HP, złoto, ekwipunek, komunikat ostatniej akcji oraz osobne ekrany menu, gry, zwycięstwa i porażki. Można dodać drugi poziom, aby przećwiczyć przejście stanu.

**Ryzyko:** „prosty automat stanów” trzeba wyjaśnić jako model przepływu, bez formalnej teorii automatów. `enum` powinien zostać wprowadzony tutaj albo wcześniej jawnie zaplanowany.

### Tydzień 13 — operacje na plikach i zapis gry

**Ocena:** temat dobrze wypełnia 90 minut. Podstawowa obsługa błędów jest potrzebna, ale pełny wykład o wyjątkach pozostaje w tygodniu 14.

**Zakres na wykład:**

- trwałość danych po zakończeniu programu,
- ścieżki względne i miejsce zapisu pliku,
- `File.WriteAllText`, `ReadAllText`, `WriteAllLines`, `ReadAllLines`,
- projekt prostego tekstowego formatu zapisu,
- serializacja stanu do tekstu bez wprowadzania rozbudowanych bibliotek,
- odtwarzanie liczb, pozycji i mapy,
- sprawdzanie istnienia pliku,
- walidacja liczby i kolejności pól,
- ranking wyników,
- ograniczone wprowadzenie do błędów plikowych.

**Proponowany rozkład 90 minut:**

| Część | Czas |
|---|---:|
| Dlaczego potrzebujemy plików | 10 min |
| Zapis i odczyt tekstu | 15 min |
| Ścieżki oraz istnienie pliku | 10 min |
| Projekt formatu zapisu gry | 20 min |
| Odtwarzanie stanu z tekstu | 20 min |
| Niepełne lub niepoprawne dane | 10 min |
| Podsumowanie | 5 min |

**Laboratorium:** placeholder należy całkowicie zastąpić. Zadanie powinno zapisywać i odczytywać co najmniej pozycję, HP, złoto, numer poziomu oraz mapę. Warto dostarczyć specyfikację formatu pliku, aby laboratorium nie zamieniło się w projektowanie serializatora.

**Ryzyko:** zapis całej mapy wraz z kolekcją obiektów może być zbyt obszerny. Najpierw należy zapewnić minimalny zapis, a ekwipunek i wielu przeciwników pozostawić jako rozszerzenie.

### Tydzień 14 — debugowanie i obsługa błędów

**Ocena:** temat bez problemu wypełni 90 minut, szczególnie w formie demonstracji na celowo uszkodzonej grze.

**Zakres na wykład:**

- błędy kompilacji, wykonania i logiki,
- czytanie komunikatu i lokalizowanie wskazanej linii,
- breakpoint, krok do następnej instrukcji i wejście do metody,
- obserwowanie zmiennych,
- stos wywołań w podstawowym zakresie,
- wyjątek i przepływ do `catch`,
- kiedy stosować `try-catch`, a kiedy warunek lub `TryParse`,
- walidacja danych wejściowych i pliku zapisu,
- odtwarzanie błędu za pomocą małego przypadku testowego.

**Proponowany rozkład 90 minut:**

| Część | Czas |
|---|---:|
| Rodzaje błędów i strategia diagnozy | 10 min |
| Komunikaty błędów i stos wywołań | 10 min |
| Breakpointy i wykonywanie krokowe | 20 min |
| Obserwowanie wartości zmiennych | 10 min |
| Wyjątki i `try-catch` | 15 min |
| Walidacja oraz defensywne sprawdzanie danych | 15 min |
| Demonstracja naprawy błędu | 5 min |
| Podsumowanie | 5 min |

**Laboratorium:** „Rogue 0.9” powinno rozpoczynać się od zintegrowanej, ale zawierającej znane usterki wersji gry. Studenci realizują scenariusze testowe, dokumentują znalezione problemy, używają debuggera i doprowadzają grę do stabilnej wersji 0.9.

**Ryzyko:** profilowanie, FPS, object pooling, LOD i optymalizacja AI z obecnego placeholdera są nieadekwatne do poziomu oraz konsolowego projektu. Należy je usunąć.

### Tydzień 15 — integracja programu i dobre praktyki

**Ocena:** odpowiedni temat na 90 minut podsumowania. Nie powinien wprowadzać dużej nowej konstrukcji języka.

**Zakres na wykład:**

- przegląd architektury ukończonego programu,
- odpowiedzialności metod i klas,
- rozpoznawanie powtórzeń,
- czytelne nazwy oraz małe metody,
- refaktoryzacja bez zmiany zachowania,
- usuwanie martwego kodu,
- małe testy manualne i lista regresji,
- kryteria uznania funkcji za ukończoną,
- dalsza droga: OOP, testy automatyczne, Git, Unity lub aplikacje .NET.

**Proponowany rozkład 90 minut:**

| Część | Czas |
|---|---:|
| Co obecnie tworzy kompletną grę | 10 min |
| Odpowiedzialności i struktura programu | 15 min |
| Nazwy, powtórzenia i małe metody | 15 min |
| Refaktoryzacja przykładu na żywo | 20 min |
| Test regresji po zmianie kodu | 10 min |
| Podsumowanie całego kursu | 10 min |
| Dalsze kierunki nauki | 10 min |

**Laboratorium:** „Rogue 1.0” może obejmować wykonanie listy testów, naprawę ostatnich błędów, jedną niewielką funkcję dodatkową, uporządkowanie kodu oraz krótką prezentację. Funkcje obowiązkowe muszą być wcześniej jednoznacznie określone.

**Ryzyko:** określenia „kod jest czysty” i „gra jest zabawna” nie są mierzalnymi kryteriami zaliczenia. Należy zastąpić je obserwowalnymi wymaganiami, np. brak awarii w podanych scenariuszach, działający zapis, osiągalne zwycięstwo i czytelne nazwy głównych elementów.

## Zależności między tematami

Rekomendowana sekwencja buduje wiedzę w następujący sposób:

```text
pętle
  ↓
tablice i listy
  ↓
metody
  ↓
losowość i walka
  ↓
słowniki i ekwipunek
  ↓
tablice 2D i mapa
  ↓
ruch i kolizje
  ↓
klasy i obiekty
  ↓
stan gry i poziomy
  ↓
pliki i zapis
  ↓
debugowanie
  ↓
integracja i finalizacja
```

Każde laboratorium wykorzystuje dzięki temu konstrukcje wyjaśnione wcześniej lub w tym samym tygodniu.

## Tematy świadomie pominięte

W placeholderach pojawiają się zagadnienia, które nie są potrzebne do realizacji celu kursu i znacząco zwiększyłyby obciążenie początkujących:

- delegaty, callbacki i zdarzenia języka C#,
- wyrażenia lambda i LINQ,
- rekurencja, Fibonacci i silnia,
- pathfinding i flood fill,
- dziedziczenie i polimorfizm,
- profilowanie wydajności, object pooling, LOD i cache,
- chmurowe zapisy, replay oraz rozbudowana telemetria.

Nie są to złe tematy, ale należą do dalszego kursu. W tym programie zabierałyby czas potrzebny na utrwalenie podstaw: zmiennych, warunków, pętli, kolekcji, metod, klas, plików i debugowania.

## Ostateczna rekomendacja

Po korekcie kolejności tygodni 6–8 wszystkie wykłady 5–15 mogą naturalnie wypełnić po 90 minut. Nie ma potrzeby usuwać wykładu o tablicach dwuwymiarowych. Trzeba jedynie prowadzić go jako wykład o **modelowaniu i wyświetlaniu świata gry za pomocą tablicy 2D**, a nie jako 90 minut samej składni.

Największej przebudowy wymagają obecne szkice laboratoriów. Ich tytuły i opisy ogólne najczęściej pasują do docelowej ścieżki, ale listy zadań powinny zostać stworzone od nowa i zsynchronizowane z wykładami.
