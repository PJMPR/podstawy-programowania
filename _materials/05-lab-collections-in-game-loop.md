---
layout: material
title: "Kolekcje w pętli gry"
kind: lab
week: 5
summary: "Ćwiczymy tablice, listy i słowniki oraz wykorzystujemy je w pętli gry."
published: true
content_ready: true
---

## Cel laboratorium

Podczas tego laboratorium wykorzystasz tablice, listy i słowniki do przechowywania wielu danych. Nauczysz się bezpiecznie pracować z indeksami i kluczami, obliczać statystyki kolekcji oraz dodawać i usuwać elementy. Zadania projektowe wykorzystują kolekcje w pętli gry.

Do wykonania jest **9 zadań**:

- 3 łatwe,
- 3 średnie,
- 3 trudne.

> **Ważne:** używaj wyłącznie poznanych elementów. Nie używaj jeszcze własnych metod, LINQ, tablic 2D ani klas tworzonych przez siebie.

---

## Przygotowanie

1. Otwórz projekt konsolowy C# z poprzedniego laboratorium albo utwórz nowy.
2. Jeżeli projekt nie rozpoznaje `List<T>` lub `Dictionary<TKey, TValue>`, dodaj na początku pliku `using System.Collections.Generic;`.
3. Po każdej zmianie skompiluj i uruchom program.
4. Dla każdego indeksu sprawdź, skąd pochodzi i czy jego zakres został zweryfikowany.
5. Przetestuj kolekcję pustą, jednoelementową oraz zawierającą kilka elementów.

Możesz wykonywać zadania w osobnych projektach albo kolejno zastępować kod w jednym projekcie.

---

## Poziom łatwy

### Zadanie 1. Raport z pięciu tur

Utwórz tablicę:

    int[] zlotoWTurach = { 5, 12, 0, 8, 15 };

Program powinien:

1. wyświetlić wszystkie wyniki w formacie `Tura 1: 5 sztuk złota`,
2. obliczyć łączną ilość złota,
3. obliczyć średnią jako liczbę typu `double`,
4. policzyć tury, w których zdobyto co najmniej 10 sztuk złota,
5. wyświetlić wyniki od ostatniej tury do pierwszej.

Użyj co najmniej jednej pętli `for` i jednej pętli `foreach`. Nie wpisuj długości `5` w warunkach pętli — pobierz ją z `Length`.

Przykładowy fragment wyniku:

    Tura 1: 5 sztuk złota
    Tura 2: 12 sztuk złota
    Tura 3: 0 sztuk złota
    Tura 4: 8 sztuk złota
    Tura 5: 15 sztuk złota

    Łącznie: 40
    Średnio na turę: 8,00
    Tury z wynikiem co najmniej 10: 2
    Od końca: 15 8 0 12 5

Po wykonaniu odpowiedz:

- Jaki jest ostatni poprawny indeks tej tablicy?
- Dlaczego warunek pętli ma postać `i < zlotoWTurach.Length`?
- Która część zadania wymaga indeksu, a którą wygodnie wykonać przez `foreach`?

### Zadanie 2. Lista ekwipunku

Utwórz listę z początkowym wyposażeniem:

    List<string> plecak = new List<string>
    {
        "Miecz",
        "Mikstura",
        "Pochodnia"
    };

Następnie:

1. wyświetl liczbę przedmiotów,
2. pokaż wszystkie przedmioty z numerami od 1,
3. pobierz nazwę nowego przedmiotu i dodaj go przez `Add`,
4. sprawdź przez `Contains`, czy w plecaku jest `"Mikstura"`,
5. spróbuj usunąć `"Mikstura"` przez `Remove`,
6. na podstawie wyniku `Remove` wyświetl informację, czy operacja się udała,
7. ponownie pokaż zawartość oraz liczbę elementów.

Przykład:

    Plecak (3/6):
    1. Miecz
    2. Mikstura
    3. Pochodnia

    Znaleziony przedmiot: Klucz
    Dodano: Klucz
    Użyto mikstury.

    Plecak (3/6):
    1. Miecz
    2. Pochodnia
    3. Klucz

Limit `6` jest na razie tylko informacją w nagłówku. Ograniczenie pojemności dodasz w późniejszym zadaniu.

### Zadanie 3. Cennik kupca

Utwórz słownik cen:

    Dictionary<string, int> ceny = new Dictionary<string, int>
    {
        { "Mikstura", 15 },
        { "Pochodnia", 5 },
        { "Miecz", 40 }
    };

Program powinien:

1. wyświetlić liczbę pozycji za pomocą `Count`,
2. wyświetlić wszystkie nazwy i ceny pętlą `foreach`, korzystając z `Key` i `Value`,
3. pobrać od użytkownika nazwę przedmiotu,
4. sprawdzić ją przez `ContainsKey`,
5. wyświetlić cenę albo komunikat, że przedmiotu nie ma,
6. zmienić cenę mikstury na 12 przez `ceny["Mikstura"] = 12`,
7. ponownie wyświetlić cały cennik.

Przetestuj nazwę istniejącą i nieistniejącą. Wyjaśnij, dlaczego odczyt `ceny[nazwa]` bez sprawdzenia może zakończyć program błędem.

---

## Poziom średni

### Zadanie 4. Najlepsza i najgorsza wyprawa

Pobierz od użytkownika liczbę tur od 1 do 10. Utwórz tablicę o podanej długości, a następnie wczytaj ilość złota zdobytą w każdej turze. Nie pozwalaj podać wyniku ujemnego.

Po zebraniu danych samodzielnie, bez `Min`, `Max`, `Sum` i LINQ:

1. oblicz sumę,
2. znajdź wartość najmniejszą i największą,
3. znajdź numer **pierwszej** tury z największym wynikiem,
4. policz, ile tur miało wynik równy maksimum,
5. znajdź pierwszą turę z wynikiem 0; jeśli jej nie ma, wyświetl odpowiedni komunikat.

Przykład dla danych `{ 8, 15, 3, 15, 0 }`:

    Suma: 41
    Minimum: 0
    Maksimum: 15
    Pierwszy najlepszy wynik: tura 2
    Liczba tur z maksimum: 2
    Pierwsza tura bez złota: 5

> **Wskazówka:** minimum i maksimum rozpocznij od elementu o indeksie 0. Do oznaczenia braku znalezionego indeksu możesz użyć wartości `-1`.

Przetestuj co najmniej:

- jedną turę,
- wszystkie wartości jednakowe,
- maksimum występujące kilka razy,
- dane bez wartości 0.

### Zadanie 5. Bezpieczny wybór i usuwanie

Utwórz listę:

    List<string> przedmioty = new List<string>
    {
        "Miecz",
        "Tarcza",
        "Mikstura",
        "Klucz"
    };

Wyświetl listę z numerami od 1. Następnie pobieraj numer przedmiotu do usunięcia, dopóki użytkownik nie poda poprawnej wartości.

Program powinien osobno obsłużyć:

- tekst, którego nie można zamienić na liczbę,
- numer mniejszy niż 1,
- numer większy niż liczba elementów,
- pustą listę,
- poprawny wybór.

Po poprawnym wyborze:

1. przelicz numer użytkownika na indeks,
2. zapamiętaj nazwę usuwanego przedmiotu,
3. usuń go za pomocą `RemoveAt`,
4. wyświetl nazwę usuniętego przedmiotu,
5. pokaż zaktualizowaną listę.

Przykład:

    1. Miecz
    2. Tarcza
    3. Mikstura
    4. Klucz
    Wybierz przedmiot do usunięcia: 0
    Numer musi należeć do zakresu 1–4.
    Wybierz przedmiot do usunięcia: trzy
    Wpisz liczbę całkowitą.
    Wybierz przedmiot do usunięcia: 3
    Usunięto: Mikstura

Wyjaśnij, dlaczego sprawdzenie powinno używać `przedmioty.Count`, a nie liczby wpisanej na stałe.

### Zadanie 6. Magazyn przedmiotów

Utwórz słownik stanów magazynowych:

    Dictionary<string, int> magazyn = new Dictionary<string, int>
    {
        { "Mikstura", 3 },
        { "Pochodnia", 2 },
        { "Klucz", 1 }
    };

Zbuduj menu działające w pętli: pokaż magazyn, przyjmij dostawę, wydaj przedmiot, usuń pustą pozycję, zakończ.

Wymagania:

1. dostawa istniejącego przedmiotu zwiększa jego stan, a nowego dodaje parę przez `Add`,
2. liczba przyjmowanych lub wydawanych sztuk musi być dodatnia,
3. wydanie jest możliwe tylko dla istniejącego klucza i wystarczającego stanu,
4. wartość nigdy nie może spaść poniżej 0,
5. pozycję można usunąć przez `Remove` tylko wtedy, gdy jej wartość wynosi 0,
6. każda operacja wyświetla komunikat o powodzeniu albo przyczynie odmowy,
7. wyświetlanie magazynu obsługuje pusty słownik.

Przetestuj dodanie nowego klucza, aktualizację istniejącego, próbę wydania zbyt wielu sztuk oraz usunięcie pustej i niepustej pozycji.

---

## Poziom trudny

### Zadanie 7. Historia akcji z filtrowaniem

Zbuduj menu działające w pętli:

    1 - Eksploruj
    2 - Odpocznij
    3 - Znajdź przedmiot
    4 - Pokaż całą historię
    5 - Pokaż ostatnie trzy wpisy
    6 - Policz wybraną akcję
    7 - Wyczyść historię
    8 - Zakończ

Przed pętlą utwórz `List<string> historia`. Po wykonaniu opcji 1–3 dodaj do niej dokładnie jeden z napisów: `"Eksploracja"`, `"Odpoczynek"` albo `"Znaleziono przedmiot"`.

Wymagania:

1. historia istnieje przez cały czas działania programu,
2. cała historia jest wyświetlana od najstarszego do najnowszego wpisu,
3. pusta historia powoduje wyświetlenie komunikatu zamiast pustego wyniku,
4. opcja 5 pokazuje najwyżej trzy ostatnie wpisy, nadal w kolejności od starszego do nowszego,
5. opcja 6 pobiera nazwę akcji i zlicza jej wystąpienia pętlą,
6. opcja 7 wymaga potwierdzenia `t` albo `n`, a następnie używa `Clear`,
7. wyświetlanie historii, błędna komenda i anulowanie czyszczenia nie dodają wpisu,
8. nie twórz osobnej kopii listy.

> **Wskazówka do ostatnich trzech wpisów:** jeśli `Count` jest większe od 3, zacznij od `Count - 3`; w przeciwnym razie zacznij od 0.

Przetestuj pustą historię, historię z 1, 3 i 5 wpisami oraz czyszczenie potwierdzone i anulowane.

### Zadanie 8. Projekt — „Hello Adventurer 5.0: ekwipunek i dziennik”

Rozbuduj projekt z tygodnia 4. Zachowaj główną pętlę gry, zdrowie, złoto i numer tury. Zastąp licznik mikstur listą przedmiotów i dodaj historię wydarzeń.

#### Stan początkowy

Pobierz imię bohatera i utwórz:

    int punktyZycia = 80;
    int maksymalneZdrowie = 100;
    int zloto = 10;
    int numerTury = 1;
    int liczbaEksploracji = 0;
    bool graDziala = true;

    string[] znaleziska =
    {
        "Mikstura",
        "Klucz",
        "Pochodnia",
        "Zwój"
    };

    List<string> plecak = new List<string>
    {
        "Miecz",
        "Mikstura"
    };

    List<string> historia = new List<string>();

Tablica `znaleziska` jest katalogiem czterech możliwych nagród i nie zmienia rozmiaru. `plecak` oraz `historia` są listami, ponieważ będą rosnąć i maleć.

#### Menu główne

W każdej iteracji pokaż:

    === HELLO ADVENTURER 5.0 ===
    Tura: 1
    Bohater: Nela
    Zdrowie: 80/100 | Złoto: 10 | Plecak: 2/6

    1 - Eksploruj loch
    2 - Pokaż plecak
    3 - Użyj przedmiotu
    4 - Dodaj znalezisko
    5 - Wyrzuć przedmiot
    6 - Pokaż historię
    7 - Pokaż statystyki wyprawy
    8 - Zakończ grę

Obsłuż wybór przez `switch-case`.

#### Reguły kolekcji

1. Plecak ma pojemność 6 elementów. Nie można dodać przedmiotu, gdy `Count` wynosi 6.
2. Wyświetlenie plecaka pokazuje elementy z numerami od 1 albo komunikat „Plecak jest pusty”.
3. Każdy numer podany przez gracza trzeba zamienić na indeks i sprawdzić przed użyciem.
4. Historia przechowuje krótkie, czytelne opisy udanych akcji.
5. Historia jest wyświetlana od najstarszego do najnowszego wpisu.
6. Próba wykonania niemożliwej akcji i błędna komenda nie zużywają tury.

#### Eksploracja

Opcja 1:

- odbiera 8 punktów życia,
- dodaje 10 sztuk złota,
- zwiększa `liczbaEksploracji`,
- dodaje wpis do historii zawierający numer tury,
- zużywa turę.

Punkty życia nie mogą spaść poniżej 0.

#### Dodawanie znaleziska

Opcja 4 wyświetla zawartość tablicy `znaleziska` z numerami od 1. Gracz wybiera nagrodę, a program:

- sprawdza format i zakres numeru,
- sprawdza pojemność plecaka,
- dodaje wybrany element do `plecak`,
- dopisuje wydarzenie do historii,
- zużywa turę tylko po udanym dodaniu.

Nie używaj jeszcze `Random` — wybór wykonuje użytkownik.

#### Używanie przedmiotu

Opcja 3 pokazuje plecak i pozwala wskazać przedmiot numerem.

- `Mikstura` przywraca 20 punktów życia, ale nie więcej niż do `maksymalneZdrowie`, a następnie znika z plecaka.
- `Pochodnia` dodaje wpis „Rozświetlono korytarz” i znika z plecaka.
- `Zwój` dodaje 15 sztuk złota i znika z plecaka.
- `Klucz` i `Miecz` nie są w tej wersji zużywane; program wyświetla jasny komunikat.
- nieznany przedmiot również pozostaje w plecaku.

Tylko skuteczne użycie przedmiotu zużywa turę i tworzy wpis w historii.

#### Wyrzucanie przedmiotu

Opcja 5 pozwala wybrać poprawny numer elementu i usuwa go przez `RemoveAt`. Przed usunięciem zapamiętaj jego nazwę, aby wyświetlić komunikat i dodać wpis do historii. Błędny numer nie zmienia listy ani numeru tury.

#### Statystyki wyprawy

Utwórz tablicę o stałej długości 20:

    int[] zlotoZdobyteWTurach = new int[20];

Gdy eksploracja kończy się zdobyciem 10 sztuk złota, zapisz tę wartość pod indeksem `numerTury - 1`, ale tylko jeśli indeks mieści się w tablicy. Przy wyświetlaniu statystyk przeanalizuj tylko rozegrane tury i pokaż:

- liczbę eksploracji,
- łączne złoto zdobyte podczas eksploracji,
- największą ilość złota zdobytą w jednej turze,
- liczbę tur bez zdobytego złota.

W tej wersji zakończ grę najpóźniej po 20 rozegranych turach, aby tablica była wystarczająca.

#### Zakończenie gry

Gra kończy się, gdy:

- gracz wybierze opcję 8,
- punkty życia spadną do 0,
- rozegrano 20 tur.

Po zakończeniu wyświetl:

    === PODSUMOWANIE ===
    Bohater: Nela
    Rozegrane tury: 7
    Eksploracje: 3
    Zdrowie: 56/100
    Złoto: 55
    Przedmioty w plecaku: 4
    Wpisy w historii: 6
    Powód zakończenia: gracz wybrał wyjście.

Na końcu pokaż również ostateczną zawartość plecaka i ostatnie trzy wpisy historii. Jeśli elementów jest mniej, wyświetl wszystkie.

#### Wymagania techniczne

Program powinien:

1. używać co najmniej jednej tablicy i dwóch list,
2. używać `Length` dla tablic i `Count` dla list,
3. używać `for` oraz `foreach`,
4. dodawać elementy przez `Add`,
5. usuwać element po poprawnie sprawdzonym indeksie przez `RemoveAt`,
6. użyć `Contains` albo `IndexOf` co najmniej raz,
7. samodzielnie obliczać statystyki bez LINQ,
8. zabezpieczać każdy indeks pochodzący od użytkownika,
9. poprawnie obsługiwać puste listy,
10. nie modyfikować listy wewnątrz `foreach`,
11. nie tworzyć kolekcji przechowujących stan wewnątrz głównej pętli,
12. nie używać własnych metod, tablic 2D ani LINQ.

#### Kryteria ukończenia

- [ ] Program kompiluje się i uruchamia bez błędów.
- [ ] Tablica znalezisk jest wyświetlana i bezpiecznie indeksowana.
- [ ] Plecak poprawnie dodaje, pokazuje, zużywa i usuwa przedmioty.
- [ ] Nie można przekroczyć pojemności plecaka.
- [ ] Pusta lista jest obsługiwana czytelnym komunikatem.
- [ ] Błędny format i indeks nie kończą programu.
- [ ] Mikstura nie podnosi zdrowia powyżej maksimum.
- [ ] Historia zachowuje wpisy między turami.
- [ ] Nieudana akcja nie zwiększa numeru tury.
- [ ] Statystyki są obliczane pętlą, bez LINQ.
- [ ] Gra kończy się dla każdego z trzech warunków.
- [ ] Podsumowanie pokazuje końcowy stan kolekcji.

#### Scenariusze testowe

Sprawdź co najmniej:

1. wyświetlenie pustego plecaka lub pustej historii,
2. wybór numeru 0, liczby za dużej i tekstu zamiast liczby,
3. użycie mikstury przy pełnym zdrowiu i przy zdrowiu 90,
4. próbę dodania siódmego przedmiotu,
5. usunięcie pierwszego i ostatniego elementu,
6. kilka identycznych mikstur w plecaku,
7. dotarcie do limitu 20 tur,
8. zakończenie przez utratę zdrowia i przez opcję menu.

#### Dla chętnych

- Dodaj wyszukiwanie przedmiotu po nazwie za pomocą `IndexOf`.
- Policz wszystkie mikstury ręczną pętlą.
- Dodaj osobną listę odkrytych lokacji i nie pozwalaj dodawać duplikatów.
- Pozwól wyświetlić historię od najnowszego do najstarszego wpisu.
- Dodaj potwierdzenie przed wyrzuceniem przedmiotu.

### Zadanie 9. Projekt — bestiariusz i statystyki walk

Zbuduj program zarządzający bestiariuszem. Użyj dwóch słowników o tych samych kluczach:

    Dictionary<string, int> punktyZycia = new Dictionary<string, int>();
    Dictionary<string, int> liczbaPokonanych = new Dictionary<string, int>();

Kluczem jest unikalna nazwa gatunku przeciwnika. Pierwszy słownik przechowuje bazowe punkty życia, a drugi liczbę pokonanych przeciwników danego gatunku.

Menu powinno umożliwiać dodanie gatunku, wyświetlenie bestiariusza, zarejestrowanie zwycięstwa, zmianę punktów życia, usunięcie gatunku z obu słowników, wyszukanie gatunku, pokazanie raportu i zakończenie programu.

Raport oblicz samodzielnie pętlą, bez LINQ. Pokaż:

- liczbę gatunków,
- łączną liczbę pokonanych przeciwników,
- nazwę i wynik najczęściej pokonywanego gatunku,
- średnią liczbę punktów życia jako `double`,
- gatunki, których jeszcze nie pokonano.

Wymagania dodatkowe:

- oba słowniki przez cały czas zawierają ten sam zestaw kluczy,
- duplikat nazwy jest odrzucany,
- nie odczytuj wartości przed sprawdzeniem `ContainsKey`,
- obsłuż pusty bestiariusz i pusty raport,
- nie dodawaj ani nie usuwaj par podczas iterowania po słowniku,
- błędna komenda lub liczba nie kończy programu.

Przetestuj pusty bestiariusz, duplikat nazwy, nieistniejący gatunek, remisujące maksima oraz usunięcie gatunku z obu słowników.

---

## Pytania kontrolne

1. Jaki jest pierwszy i ostatni poprawny indeks tablicy o długości 5?
2. Czym różni się `Length` od `Count`?
3. Kiedy lepiej użyć tablicy, a kiedy listy?
4. Kiedy `foreach` jest czytelniejsze od `for`?
5. Dlaczego do zmiany elementów tablicy wygodniejsza jest pętla `for`?
6. Co zwraca `IndexOf`, gdy elementu nie znaleziono?
7. Czym różnią się `Remove` i `RemoveAt`?
8. Dlaczego nie należy usuwać elementów listy podczas `foreach`?
9. Jak przeliczyć numer 1 widoczny w menu na indeks kolekcji?
10. Dlaczego minimum warto rozpocząć od pierwszego elementu zamiast od 0?
11. Czym różni się klucz słownika od indeksu listy?
12. Dlaczego klucze słownika muszą być unikalne?
13. Co może się stać po odczycie `slownik[klucz]`, jeśli klucz nie istnieje?
14. Kiedy użyć `ContainsKey`, a kiedy `Count`?

---

## Podsumowanie

Po ukończeniu laboratorium potrafisz:

- tworzyć i wypełniać tablice jednowymiarowe,
- odczytywać i modyfikować elementy przez indeks,
- kontrolować poprawność indeksu przed jego użyciem,
- przechodzić po kolekcjach za pomocą `for` i `foreach`,
- ręcznie obliczać sumę, średnią, minimum i maksimum,
- wyszukiwać oraz zliczać elementy,
- dodawać i usuwać elementy `List<T>`,
- tworzyć słowniki i przechowywać pary klucz–wartość,
- bezpiecznie sprawdzać klucze przez `ContainsKey`,
- dodawać, aktualizować, usuwać i wyświetlać elementy słownika,
- poprawnie obsługiwać pustą kolekcję,
- przechowywać ekwipunek i historię akcji w pętli gry,
- dobrać tablicę, listę albo słownik do charakteru danych.
