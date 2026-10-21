---
layout: material
title: "Menu gry w pętli"
kind: lab
week: 4
summary: "Ćwiczymy pętle while, do-while i for, walidujemy dane oraz budujemy powtarzane menu gry."
published: true
content_ready: true
---

## Cel laboratorium

Podczas tego laboratorium nauczysz się wielokrotnie wykonywać instrukcje, kontrolować liczbę iteracji i bezpiecznie kończyć pętle. Ostatnie zadanie rozbuduje projekt **„Hello Adventurer”** o menu działające aż do zakończenia gry.


Do wykonania jest **6 zadań**:

- 2 łatwe,
- 2 średnie,
- 2 trudne.

> **Ważne:** w zadaniach używaj wyłącznie poznanych elementów: zmiennych, operatorów, instrukcji warunkowych, `switch-case` i pętli. Nie używaj jeszcze tablic, list ani własnych metod.

---

## Przygotowanie

1. Otwórz projekt konsolowy C# z poprzedniego laboratorium albo utwórz nowy.
2. Przed napisaniem pętli określ jej stan początkowy, warunek i zmianę stanu.
3. Uruchamiaj program po każdym ukończonym fragmencie.
4. Testuj pierwszą i ostatnią iterację oraz wartości spoza dozwolonego zakresu.
5. Jeżeli program nie kończy działania, zatrzymaj go i sprawdź, czy warunek może stać się fałszywy.

Możesz wykonywać zadania w osobnych projektach albo kolejno zastępować kod w jednym projekcie.

---

## Poziom łatwy

### Zadanie 1. Trzy sposoby odliczania

Wyświetl liczby od 1 do 10 na trzy sposoby:

1. za pomocą `while`,
2. za pomocą `do-while`,
3. za pomocą `for`.

Następnie za pomocą `for`:

- wyświetl liczby od 10 do 1,
- wyświetl liczby parzyste od 0 do 20,
- na końcu wypisz komunikat „Start!”.

Przykładowy fragment wyniku:

    Rosnąco: 1 2 3 4 5 6 7 8 9 10
    Malejąco: 10 9 8 7 6 5 4 3 2 1
    Parzyste: 0 2 4 6 8 10 12 14 16 18 20
    Start!

Po wykonaniu odpowiedz:

- Która pętla najczytelniej opisuje znaną liczbę powtórzeń?
- Ile razy wykona się `while`, jeśli jej warunek od początku jest fałszywy?
- Ile razy w tej samej sytuacji wykona się `do-while`?

### Zadanie 2. Suma wyprawy

Pobierz od użytkownika liczbę dni wyprawy od 1 do 7. Następnie dla każdego dnia pobierz liczbę znalezionych sztuk złota.

Program powinien:

1. użyć pętli `for`,
2. wyświetlić numer aktualnego dnia,
3. sumować znalezione złoto,
4. policzyć dni, w których znaleziono więcej niż 10 sztuk złota,
5. po zakończeniu wyświetlić łączny wynik i liczbę udanych dni.

Przykład:

    Ile dni trwa wyprawa? 3
    Złoto w dniu 1: 5
    Złoto w dniu 2: 14
    Złoto w dniu 3: 8

    Łącznie znaleziono: 27 sztuk złota.
    Dni z wynikiem powyżej 10: 1.

Na tym etapie możesz założyć, że użytkownik wpisuje liczby w poprawnym formacie.

---

## Poziom średni

### Zadanie 3. Choinka z gwiazdek

Pobierz od użytkownika wysokość choinki od 2 do 10. Za pomocą zagnieżdżonych pętli `for` wyświetl wyśrodkowaną choinkę złożoną ze znaków `*`.

W każdym kolejnym wierszu korony powinny znaleźć się:

- odpowiednia liczba spacji, aby wyśrodkować choinkę,
- nieparzysta liczba gwiazdek: 1, 3, 5, 7 i tak dalej.

Po narysowaniu korony dodaj pień: pojedynczą gwiazdkę wyśrodkowaną względem choinki.

Dla wysokości 5 wynik powinien wyglądać tak:

        *
       ***
      *****
     *******
    *********
        *

Program powinien używać osobnych pętli do wyświetlania spacji i gwiazdek. Nie używaj metody `PadLeft`, `PadRight` ani `Repeat`.

Wyjaśnij, jak zmienia się liczba spacji i gwiazdek w kolejnych wierszach oraz ile gwiazdek znajduje się w ostatnim wierszu korony.

### Zadanie 4. Poprawna liczba tur

Pobieraj od użytkownika liczbę tur aż poda liczbę całkowitą od 1 do 10.

Program powinien osobno obsłużyć:

- tekst, którego nie można zamienić na liczbę,
- liczbę mniejszą niż 1,
- liczbę większą niż 10,
- poprawną wartość.

Użyj:

- pętli `while` albo `do-while`,
- `int.TryParse`,
- co najmniej jednej instrukcji `continue`,
- `break` po uzyskaniu poprawnej wartości.

Przykład:

    Podaj liczbę tur od 1 do 10: pięć
    Wpisz liczbę całkowitą.
    Podaj liczbę tur od 1 do 10: 15
    Liczba musi należeć do zakresu 1–10.
    Podaj liczbę tur od 1 do 10: 5
    Rozpoczynam grę na 5 tur.

Po pobraniu poprawnej liczby wykonaj odliczanie tur za pomocą `for`.

---

## Poziom trudny

### Zadanie 5. Symulacja walki turowej

Zbuduj prostą walkę bohatera z przeciwnikiem. Na początku ustaw:

    int zdrowieBohatera = 60;
    int zdrowiePrzeciwnika = 45;
    int liczbaMikstur = 2;
    int numerTury = 1;

Walka trwa, dopóki obie postacie mają więcej niż 0 punktów życia. W każdej turze:

1. wyświetl numer tury i stan obu postaci,
2. pokaż menu: 1 — atak, 2 — mikstura, 3 — ucieczka,
3. pobierz akcję gracza,
4. obsłuż ją za pomocą `switch-case`,
5. po poprawnej akcji przeciwnik zadaje bohaterowi 7 punktów obrażeń,
6. zwiększ numer tury.

Reguły akcji:

- atak odbiera przeciwnikowi 12 punktów życia,
- mikstura przywraca bohaterowi 15 punktów życia i zmniejsza liczbę mikstur o 1,
- nie można użyć mikstury, gdy żadna nie została,
- ucieczka natychmiast kończy walkę,
- nieznana opcja nie zużywa tury i nie uruchamia ataku przeciwnika,
- pokonany przeciwnik nie może już zaatakować.

Po pętli wyświetl jeden z komunikatów: zwycięstwo, porażka albo ucieczka.

> **Wskazówka:** przyda się zmienna logiczna `ucieczka`. Warunek walki może sprawdzać zdrowie obu postaci oraz to, czy gracz nie uciekł.

Przetestuj co najmniej cztery scenariusze: zwycięstwo przez atak, przegraną, użycie wszystkich mikstur oraz ucieczkę.

#### Dla chętnych: losowe obrażenia

Wzbogać walkę o losowość. Zamiast stałej wartości obrażeń możesz losować siłę każdego ataku, na przykład:

- bohater zadaje od 8 do 15 punktów obrażeń,
- przeciwnik zadaje od 4 do 9 punktów obrażeń.

Na początku programu utwórz jeden obiekt `Random`, a następnie używaj go podczas całej walki:

    Random losowanie = new Random();

    int obrazeniaBohatera = losowanie.Next(8, 16);
    int obrazeniaPrzeciwnika = losowanie.Next(4, 10);

    Console.WriteLine($"Bohater zadaje {obrazeniaBohatera} punktów obrażeń.");

Metoda `Next(min, max)` losuje liczbę całkowitą od `min` włącznie do `max` wyłącznie. Dlatego `Next(8, 16)` może zwrócić wartości od 8 do 15.

Po każdej turze wyświetl wylosowaną wartość obrażeń, aby gracz wiedział, jaki był efekt ataku. Pamiętaj, że pokonany przeciwnik nadal nie może zaatakować.

### Zadanie 6. Projekt — „Hello Adventurer 4.0: menu gry”

Rozbuduj projekt z poprzednich tygodni. Program ma pobrać dane bohatera, a następnie uruchomić główną pętlę gry. Menu ma być wyświetlane ponownie po każdej akcji aż do wybrania wyjścia albo utraty wszystkich punktów życia.

#### Stan początkowy

Pobierz imię bohatera i utwórz co najmniej następujące zmienne:

- `punktyZycia` — wartość od 1 do 100,
- `maksymalneZdrowie` — 100,
- `zloto` — wartość nieujemna,
- `liczbaMikstur` — wartość nieujemna,
- `numerTury` — początkowo 1,
- `graDziala` — początkowo `true`.

Punkty życia, złoto i liczbę mikstur pobierz w pętlach walidujących. Nie pozwól rozpocząć gry z wartością spoza podanego zakresu ani z tekstem zamiast liczby.

#### Menu główne

W każdej iteracji wyświetl:

    === HELLO ADVENTURER ===
    Tura: 1
    Bohater: Nela
    Zdrowie: 75/100 | Złoto: 20 | Mikstury: 2

    1 - Eksploruj loch
    2 - Użyj mikstury
    3 - Odpocznij
    4 - Pokaż statystyki
    5 - Zakończ grę

Obsłuż wybór za pomocą `switch-case`.

#### Reguły gry

1. **Eksploracja** — bohater otrzymuje 10 sztuk złota i traci 8 punktów życia.
2. **Mikstura** — jeżeli jest dostępna, przywraca 20 punktów życia i znika z ekwipunku. Zdrowie nie może przekroczyć `maksymalneZdrowie`.
3. **Odpoczynek** — przywraca 5 punktów życia, ale kosztuje 3 sztuki złota. Akcja jest możliwa tylko wtedy, gdy bohater ma wystarczająco dużo złota.
4. **Statystyki** — pokazują aktualny stan oraz łączną liczbę wykonanych eksploracji; ta opcja nie zużywa tury.
5. **Wyjście** — zmienia `graDziala` na `false`.
6. **Nieznana opcja** — wyświetla błąd i nie zużywa tury.

Pętla gry powinna zakończyć się, gdy `graDziala` ma wartość `false` albo `punktyZycia` spadną do 0 lub mniej.

#### Wymagania techniczne

Program powinien:

1. używać co najmniej jednej pętli `while` albo `do-while` do walidacji danych,
2. używać pętli `while` jako głównej pętli gry,
3. używać `switch-case` do obsługi menu,
4. używać `int.TryParse` przy wczytywaniu wartości liczbowych,
5. używać `break` lub zmiennej logicznej do zakończenia gry,
6. używać `continue`, aby błędna opcja nie zwiększała numeru tury,
7. nie pozwalać, aby zdrowie przekroczyło 100,
8. nie pozwalać, aby liczba mikstur lub złota spadła poniżej 0,
9. zliczać wykonane eksploracje,
10. po zakończeniu wyświetlić podsumowanie gry,
11. nie używać tablic, list ani własnych metod.

#### Kolory konsoli

Zastosuj kolory zgodnie ze znaczeniem komunikatu:

- zielony — udana akcja lub dobre zdrowie,
- żółty — ostrzeżenie albo niski poziom zdrowia,
- czerwony — błąd lub utrata wszystkich punktów życia,
- cyjan — nagłówek i informacje neutralne.

Po kolorowanym fragmencie wywołaj `Console.ResetColor()`. Informacja nie może być przekazywana wyłącznie kolorem — zawsze dodaj czytelny tekst.

#### Przykładowe podsumowanie

    === KONIEC GRY ===
    Bohater: Nela
    Rozegrane tury: 7
    Eksploracje: 3
    Zdrowie: 66/100
    Złoto: 47
    Mikstury: 1
    Powód zakończenia: gracz wybrał wyjście.

#### Kryteria ukończenia

- [ ] Program kompiluje się i uruchamia bez błędów.
- [ ] Dane początkowe są walidowane w pętli.
- [ ] Menu jest wyświetlane wielokrotnie.
- [ ] Każda opcja menu ma widoczny efekt albo jasny komunikat.
- [ ] Błędny wybór nie kończy programu i nie zużywa tury.
- [ ] Mikstury i złoto nie przyjmują wartości ujemnych.
- [ ] Punkty życia nie przekraczają wartości maksymalnej.
- [ ] Gra kończy się po wyborze wyjścia albo utracie zdrowia.
- [ ] Podsumowanie zawiera końcowy stan i powód zakończenia.
- [ ] Kolory są stosowane konsekwentnie i resetowane.
- [ ] Kod nie używa tablic, list ani własnych metod.

#### Dla chętnych

- Dodaj limit 20 tur i osobny komunikat po jego osiągnięciu.
- Pozwól kupić miksturę za 25 sztuk złota.
- Dodaj mnożnik leczenia zależny od wybranego poziomu trudności.
- Dodaj potwierdzenie wyjścia za pomocą pętli `do-while`.
- Po każdej turze wyświetl pasek zdrowia złożony ze znaków `#` i `-`.
- Dodaj osiągnięcie przyznawane po pięciu eksploracjach.

---

## Pytania kontrolne

1. Czym różni się `while` od `do-while`?
2. Kiedy pętla `for` jest czytelniejsza od `while`?
3. Co musi się zmieniać, aby pętla warunkowa mogła się zakończyć?
4. Jaka jest różnica między `break` i `continue`?
5. Dlaczego po błędnym wyborze w menu warto użyć `continue`?
6. Co zwraca `int.TryParse` i gdzie trafia przekonwertowana liczba?
7. Którą pętlę kończy `break` w pętlach zagnieżdżonych?
8. Jak sprawić, aby leczenie nie zwiększyło zdrowia powyżej maksimum?

---

## Podsumowanie

Po ukończeniu laboratorium potrafisz:

- wykonywać kod określoną liczbę razy za pomocą `for`,
- powtarzać kod zależnie od warunku za pomocą `while` i `do-while`,
- budować zagnieżdżone pętle,
- tworzyć liczniki i akumulatory,
- sterować iteracjami za pomocą `break` i `continue`,
- walidować liczby za pomocą `int.TryParse`,
- zapobiegać pętlom nieskończonym,
- zbudować menu oraz prostą główną pętlę gry,
- aktualizować stan gry po kolejnych decyzjach użytkownika.
