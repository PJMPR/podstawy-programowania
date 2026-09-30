---
layout: material
title: "Hello Adventurer"
kind: lab
week: 1
summary: "Ćwiczymy wyświetlanie i pobieranie danych, zmienne, podstawowe typy oraz proste obliczenia, a następnie samodzielnie tworzymy kartę bohatera."
published: true
content_ready: true
---

## Cel laboratorium

Podczas tego laboratorium przećwiczysz podstawy poznane na wykładzie: uruchamianie programu konsolowego, wykonywanie instrukcji w odpowiedniej kolejności, pracę z `Console.Write`, `Console.WriteLine` i `Console.ReadLine`, przechowywanie wartości w zmiennych oraz wykonywanie prostych obliczeń.

Na końcu samodzielnie wykonasz pierwszy element projektu rozwijanego podczas kolejnych laboratoriów — program **„Hello Adventurer”** wyświetlający kartę bohatera.

> **Ważne:** zadania nie wymagają jeszcze instrukcji warunkowych, pętli ani funkcji. Jeśli użytkownik poda nieprawidłową wartość liczbową, program może zakończyć się błędem. Bezpieczną obsługę takich sytuacji poznamy później.

---

## Przygotowanie

1. Utwórz nowy projekt aplikacji konsolowej C#.
2. Otwórz plik `Program.cs`.
3. Uruchom program i upewnij się, że w konsoli pojawia się komunikat.
4. Po każdym zadaniu ponownie uruchom program i sprawdź jego wynik.

Możesz pracować w jednym projekcie, zastępując kod po ukończeniu zadania, albo utworzyć osobny projekt dla każdego ćwiczenia.

---

## Poziom łatwy

Te zadania są przeznaczone dla osób, które wcześniej nie programowały. Wykonuj je kolejno.

### Zadanie 1. Pierwsze komunikaty

Napisz program, który wyświetli w osobnych wierszach powitanie, Twoje imię, nazwę kierunku studiów oraz zdanie opisujące, czego chcesz nauczyć się na kursie. Użyj co najmniej raz `Console.Write` i co najmniej raz `Console.WriteLine`.

### Zadanie 2. Konsolowa wizytówka

Zapisz imię, wiek i ulubioną grę w trzech zmiennych o odpowiednich typach. Następnie wyświetl estetyczną wizytówkę, korzystając z interpolacji tekstu.

Przykładowy efekt:

```text
+--------------------------+
|       WIZYTÓWKA          |
+--------------------------+
| Imię: Lena               |
| Wiek: 19                 |
| Gra: Stardew Valley      |
+--------------------------+
```

### Zadanie 3. Powitanie użytkownika

Zapytaj użytkownika o imię i ulubiony kolor. Zapisz obie odpowiedzi w zmiennych, a potem wyświetl spersonalizowane powitanie w jednym zdaniu.

```text
Jak masz na imię? Amir
Jaki jest Twój ulubiony kolor? zielony

Cześć, Amir! Zielony to świetny kolor na płaszcz poszukiwacza przygód.
```

### Zadanie 4. Rok później

Pobierz od użytkownika jego wiek jako liczbę całkowitą. Oblicz i wyświetl, ile lat będzie miał za rok oraz za pięć lat.

---

## Poziom średni

W tych zadaniach trzeba samodzielnie połączyć pobieranie danych, zmienne, konwersję typów i obliczenia.

### Zadanie 5. Kalkulator podróży

Zapytaj o liczbę kilometrów do celu oraz liczbę kilometrów pokonywanych każdego dnia. Oblicz, przez ile dni trwałaby podróż, zakładając, że obie liczby dzielą się bez reszty. Wyświetl podsumowanie zawierające dane i wynik.

### Zadanie 6. Sakiewka podróżnika

Pobierz liczbę złotych, srebrnych i miedzianych monet. Przyjmij, że jedna złota moneta jest warta 100 miedzianych, a jedna srebrna — 10 miedzianych. Oblicz łączną wartość sakiewki wyrażoną w miedzianych monetach.

### Zadanie 7. Proporcje mikstury

Jedna mikstura wymaga 3 kryształów i 2 ziół. Pobierz liczbę mikstur, które chce przygotować użytkownik, a następnie oblicz łączną liczbę potrzebnych kryształów i ziół. Wynik przedstaw jako czytelną listę składników.

### Zadanie 8. Rachunek w gospodzie

Pobierz cenę noclegu oraz liczbę nocy. Oblicz koszt całego pobytu. Cenę przechowuj w zmiennej typu `decimal`, a liczbę nocy w zmiennej typu `int`.

---

## Poziom trudny

Te zadania nadal wykorzystują wyłącznie materiał z wykładu, ale wymagają zaplanowania większej liczby zmiennych i obliczeń.

### Zadanie 9. Zamiana czasu

Pobierz całkowitą liczbę sekund, a następnie przedstaw ten czas jako liczbę pełnych minut i pozostałych sekund.

Przykład: dla `154` sekund program powinien wyświetlić `2 minuty i 34 sekundy`.

> **Wskazówka:** operator `/` wykonuje dzielenie, a operator `%` zwraca resztę z dzielenia.

### Zadanie 10. Podział łupu

Drużyna zdobyła skarb składający się ze złotych monet. Pobierz liczbę monet oraz liczbę bohaterów. Oblicz, ile pełnych monet otrzyma każdy bohater oraz ile monet pozostanie po równym podziale. Program nie musi obsługiwać sytuacji, w której liczba bohaterów wynosi zero.

### Zadanie 11. Obrażenia bohatera

Pobierz wartość podstawowych obrażeń broni i premię do siły. Oblicz obrażenia zwykłego ataku jako sumę obu wartości, obrażenia ataku specjalnego jako dwukrotność zwykłego ataku oraz łączne obrażenia trzech zwykłych ataków i jednego specjalnego. Wyświetl wszystkie etapy obliczeń w czytelnym raporcie.

### Zadanie 12. Dziennik wyprawy

Pobierz nazwę bohatera, nazwę krainy, liczbę dni wyprawy, liczbę zdobytych punktów doświadczenia i ilość zebranego złota. Oblicz średnią liczbę punktów doświadczenia oraz złota zdobytych jednego dnia. Dobierz typy pozwalające wyświetlić wyniki z częścią ułamkową, a następnie pokaż dane w formie kilkulinijkowego wpisu do dziennika.

---

## Zadanie projektowe — „Hello Adventurer”

Wykonaj to zadanie **samodzielnie od początku do końca**. Poniżej znajduje się specyfikacja programu, a nie instrukcja jego budowy. Samodzielnie zaplanuj kolejność instrukcji, nazwy zmiennych, obliczenia oraz wygląd wyniku.

### Cel

Utwórz konsolowy program wyświetlający spersonalizowaną kartę bohatera rozpoczynającego przygodę.

### Wymagania

Program powinien:

1. wyświetlić tytuł gry,
2. zapytać użytkownika o imię gracza,
3. zapisać w zmiennych co najmniej cztery statystyki bohatera, np. punkty życia, siłę, złoto i poziom doświadczenia,
4. użyć co najmniej trzech różnych typów danych,
5. wykonać jedno lub dwa proste obliczenia związane z bohaterem,
6. wyświetlić imię, statystyki i wyniki obliczeń jako czytelną kartę postaci,
7. wykorzystać interpolację tekstu przynajmniej w jednym miejscu.

Wartości statystyk mogą być ustalone w kodzie albo pobrane od użytkownika. Obliczenia powinny mieć sens w świecie gry, np. wyznaczać maksymalne obrażenia, łączną moc, pozostałe miejsce w plecaku lub koszt ekwipunku.

### Inspiracje wizualne

Poniższe makiety pokazują różne sposoby rozmieszczenia informacji. Nie musisz ich kopiować — możesz zaprojektować własną kartę.

#### Wariant klasyczny

```text
+================================+
|       HELLO ADVENTURER         |
+================================+
| Bohater: Aria                  |
| Klasa:   Odkrywczyni           |
+--------------------------------+
| HP       100                   |
| Siła      12                   |
| Złoto     35                   |
+--------------------------------+
| Łączna moc: 112                |
+================================+
```

#### Wariant z ikonami

```text
╔════════════════════════════════╗
║       KARTA POSZUKIWACZA       ║
╠════════════════════════════════╣
║  ⚔  Kael                       ║
║  ♥  Życie ............... 90   ║
║  ◆  Siła ................ 14   ║
║  ●  Złoto ............... 27   ║
╠════════════════════════════════╣
║  Atak specjalny: 28            ║
╚════════════════════════════════╝
```

> Symbole mogą wyglądać inaczej w zależności od używanej konsoli. Zwykłe znaki, takie jak `+`, `-`, `|`, `=` i `*`, są równie dobrym wyborem.

#### Wariant kompaktowy

```text
┌─[ MIRA / POZIOM 1 ]───────────┐
│ HP: 80     SIŁA: 11           │
│ ZŁOTO: 40  EKWIPUNEK: 3/10    │
├───────────────────────────────┤
│ Wolne miejsce w plecaku: 7    │
└───────────────────────────────┘
```

#### Wariant dziennika podróży

```text
* * * GUILD RECORD #001 * * *

Imię bohatera : Nela
Gotowy do drogi: True
Punkty życia  : 120
Siła          : 9
Złoto         : 18

Przewidywane obrażenia: 27
* * * * * * * * * * * * * *
```

### Kryteria ukończenia

- [ ] Program kompiluje się i uruchamia bez błędów.
- [ ] Tytuł gry jest widoczny.
- [ ] Program pobiera imię użytkownika.
- [ ] Statystyki są zapisane w zmiennych o odpowiednich typach.
- [ ] Program wykonuje co najmniej jedno poprawne obliczenie.
- [ ] Karta bohatera jest czytelna i zawiera wymagane informacje.
- [ ] Nazwy zmiennych opisują przechowywane wartości.
- [ ] Kod wykorzystuje wyłącznie zagadnienia poznane na wykładzie.

### Dla chętnych

Rozbuduj wygląd karty o własną ramkę, motto bohatera albo dodatkową statystykę. Nie używaj jeszcze instrukcji warunkowych ani pętli — ich zastosowanie poznamy na kolejnych zajęciach.

---

## Podsumowanie

Po ukończeniu laboratorium potrafisz:

- utworzyć i uruchomić prosty program konsolowy,
- wyświetlać i pobierać dane w konsoli,
- przechowywać wartości w zmiennych,
- dobrać podstawowy typ danych do wartości,
- zamienić tekst wprowadzony przez użytkownika na liczbę,
- wykonać proste obliczenia,
- przedstawić wynik programu w czytelnej formie.
