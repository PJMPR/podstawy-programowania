---
layout: material
title: "Karta bohatera"
kind: lab
week: 2
summary: "Ćwiczymy dobór typów, operatory, konwersje i wartości logiczne, a następnie rozbudowujemy kartę bohatera."
published: false
unlock_week: 2
content_ready: true
---

## Cel laboratorium

Podczas tego laboratorium przećwiczysz świadome dobieranie typów danych, aktualizowanie zmiennych, obliczenia z użyciem operatorów arytmetycznych, dzielenie całkowite i resztę z dzielenia, konwersje oraz budowanie wyrażeń logicznych.

Do wykonania jest **6 zadań**:

- 2 łatwe,
- 2 średnie,
- 2 trudne.

Ostatnie zadanie rozwija projekt z poprzedniego tygodnia — program **„Hello Adventurer”** otrzyma dokładniejsze statystyki i raport gotowości bohatera.

> **Ważne:** zadania nie wymagają instrukcji `if`, pętli ani własnych funkcji. Program może obliczyć i wyświetlić wartość `true` albo `false`, ale nie musi jeszcze wykonywać na jej podstawie różnych instrukcji. Możesz założyć, że użytkownik podaje dane w poprawnym formacie.

---

## Przygotowanie

1. Utwórz nowy projekt konsolowy C# albo otwórz projekt z poprzedniego laboratorium.
2. W osobnych zadaniach używaj nazw zmiennych opisujących przechowywane dane.
3. Po każdym większym fragmencie uruchom program i porównaj wynik z własnymi obliczeniami.
4. Zwracaj uwagę na ostrzeżenia i błędy kompilatora — nie poprawiaj kodu metodą losowych zmian.

Możesz utworzyć osobny projekt dla każdego zadania. Zadanie 6 najlepiej wykonać jako rozwinięcie projektu z tygodnia 1.

---

## Poziom łatwy

### Zadanie 1. Ekwipunek bohatera

Zadeklaruj i zainicjalizuj zmienne przechowujące:

- imię bohatera,
- symbol bohatera na mapie,
- poziom doświadczenia,
- liczbę sztuk złota,
- wagę plecaka w kilogramach,
- informację, czy bohater ma mapę.

Dobierz do nich odpowiednie typy spośród `string`, `char`, `int`, `double` i `bool`. Następnie wyświetl wszystkie dane jako czytelny raport. W raporcie pokaż również nazwę typu, którego użyłeś przy każdej wartości — wpisz ją jako zwykły tekst.

Przykładowy efekt:

```text
=== EKWIPUNEK ===
Imię (string): Mira
Symbol (char): @
Poziom (int): 2
Złoto (int): 35
Waga (double): 7,5 kg
Ma mapę (bool): True
```

Na końcu zmień przynajmniej dwie wartości przez ponowne przypisanie i jeszcze raz wyświetl raport. Imienia bohatera nie deklaruj ponownie.

### Zadanie 2. Trening na arenie

Bohater rozpoczyna trening z określoną liczbą punktów doświadczenia i złota. Zapisz wartości początkowe w zmiennych typu `int`, a potem wykonaj kolejno następujące operacje:

1. dodaj `25` punktów doświadczenia,
2. podwój łączną liczbę punktów doświadczenia,
3. odejmij `8` sztuk złota za wejście na arenę,
4. dodaj `15` sztuk złota jako nagrodę,
5. zwiększ numer treningu o jeden.

Użyj co najmniej trzech skróconych operatorów przypisania, np. `+=`, `-=`, `*=`, oraz operatora `++`. Wyświetl stan początkowy i końcowy.

> **Sprawdź przed uruchomieniem:** jeśli bohater zaczyna z `40` punktami doświadczenia, ile będzie ich miał po dodaniu `25` i podwojeniu wyniku? Kolejność instrukcji ma znaczenie.

---

## Poziom średni

### Zadanie 3. Podział zapasów

Pobierz od użytkownika:

- liczbę racji żywnościowych,
- liczbę członków drużyny,
- liczbę dni wyprawy.

Oblicz i wyświetl:

1. ile pełnych racji otrzyma każdy członek drużyny,
2. ile racji pozostanie po równym podziale,
3. ile racji dziennie przypadnie na całą drużynę,
4. ile racji dziennie przypadnie średnio na jedną osobę.

Pierwsze dwa wyniki mają wykorzystywać dzielenie całkowite i operator `%`. Dwa wyniki dzienne powinny być typu `double` i zostać wyświetlone z dwoma miejscami po przecinku.

Dla danych:

```text
Racje: 53
Członkowie drużyny: 4
Dni wyprawy: 5
```

program powinien między innymi pokazać, że po jednorazowym równym podziale każdy otrzyma `13` pełnych racji, a `1` racja pozostanie.

> **Wskazówka:** wykonaj rzutowanie przed dzieleniem, jeżeli wynik ma zachować część ułamkową. Możesz założyć, że liczba członków drużyny i dni jest większa od zera.

### Zadanie 4. Czy bohater jest gotowy?

Pobierz od użytkownika:

- punkty życia,
- liczbę mikstur,
- informację, czy ma klucz (`true` albo `false`),
- informację, czy ma mapę (`true` albo `false`).

Następnie utwórz zmienne typu `bool` opisujące:

- `zyje` — punkty życia są większe od zera,
- `maPelneZdrowie` — punkty życia są równe `100`,
- `maZaopatrzenie` — bohater ma co najmniej jedną miksturę,
- `maPrzedmiotNawigacyjny` — ma klucz lub mapę,
- `gotowyDoWyprawy` — żyje, ma zaopatrzenie oraz klucz lub mapę.

Wyświetl nazwy i wartości wszystkich zmiennych logicznych. Użyj operatorów porównania oraz operatorów `&&` i `||`. Co najmniej raz zastosuj operator `!`, tworząc dodatkową wartość `wymagaLeczenia` jako negację `maPelneZdrowie`.

Przykładowy fragment wyniku:

```text
Żyje: True
Ma pełne zdrowie: False
Wymaga leczenia: True
Ma zaopatrzenie: True
Ma klucz lub mapę: True
Gotowy do wyprawy: True
```

Program ma jedynie obliczyć i wyświetlić te wartości — nie używaj jeszcze instrukcji `if`.

---

## Poziom trudny

### Zadanie 5. Raport z walki

Napisz program obliczający wynik jednej rundy walki. Pobierz:

- imię bohatera,
- maksymalne punkty życia,
- aktualne punkty życia przed walką,
- podstawowe obrażenia broni,
- premię do siły,
- mnożnik ataku specjalnego jako `double`,
- liczbę wykonanych zwykłych ataków.

Oblicz:

1. obrażenia jednego zwykłego ataku jako sumę obrażeń broni i premii do siły,
2. obrażenia ataku specjalnego jako zwykłe obrażenia pomnożone przez mnożnik; wynik po mnożeniu jawnie przekształć na `int`,
3. łączne obrażenia zadane przez podaną liczbę zwykłych ataków i jeden atak specjalny,
4. procent pozostałego zdrowia bohatera jako `double`,
5. wartości logiczne `zyje` i `maPelneZdrowie`.

Wyświetl wielowierszowy raport. Procent zdrowia pokaż z dwoma miejscami po przecinku.

```text
========== RAPORT Z WALKI ==========
Bohater: Kael
Zdrowie: 72/100 (72,00%)
Zwykły atak: 17
Atak specjalny: 25
Łączne zadane obrażenia: 76
Żyje: True
Pełne zdrowie: False
====================================
```

Raport powinien działać dla innych danych niż w przykładzie. Możesz założyć, że maksymalne punkty życia są większe od zera.

> **Zwróć uwagę:** rzutowanie wyniku ataku specjalnego na `int` odrzuci część ułamkową. Zastanów się także, w którym miejscu trzeba wykonać rzutowanie podczas obliczania procentu zdrowia.

### Zadanie 6. Projekt — „Karta bohatera 2.0”

Rozbuduj program **„Hello Adventurer”** z poprzedniego laboratorium. Tym razem karta ma nie tylko przechowywać dane, ale również pokazywać wyniki obliczeń i stan przygotowania postaci.

#### Wymagania

Program powinien:

1. pobrać imię bohatera oraz co najmniej cztery wartości liczbowe opisujące postać,
2. używać typów `string`, `char`, `int`, `double` lub `decimal` oraz `bool` — łącznie co najmniej czterech różnych typów,
3. zawierać co najmniej jedną stałą zadeklarowaną za pomocą `const`,
4. użyć operatorów arytmetycznych `+`, `-`, `*`, `/` i `%` przynajmniej po jednym razie,
5. wykorzystać co najmniej dwa skrócone operatory przypisania,
6. wykonać co najmniej jedną jawną konwersję typu,
7. obliczyć minimum trzy statystyki pochodne, np. obrażenia, procent zdrowia, wolne miejsce w plecaku albo wartość ekwipunku,
8. utworzyć co najmniej trzy wartości logiczne za pomocą porównań i operatorów logicznych,
9. wyświetlić liczby ułamkowe z dwoma miejscami po przecinku,
10. przedstawić wszystkie dane w czytelnej karcie postaci.

Nie używaj jeszcze instrukcji warunkowych, pętli, tablic ani własnych funkcji.

#### Przykładowy kierunek

```text
+====================================+
|          HELLO ADVENTURER          |
+====================================+
| Bohater: Mira                  @    |
| Poziom: 2                           |
+------------------------------------+
| Zdrowie: 75/100 (75,00%)            |
| Siła: 12                            |
| Premia broni: 5                     |
| Obrażenia: 17                       |
| Złoto: 43                           |
| Plecak: 6/10                        |
| Wolne miejsca: 4                    |
+------------------------------------+
| Żyje: True                          |
| Ma miejsce w plecaku: True          |
| Gotowy do wyprawy: True             |
+====================================+
```

Nie musisz kopiować układu ani wartości. Zaprojektuj własną kartę i dobierz statystyki pasujące do bohatera.

#### Kryteria ukończenia

- [ ] Program kompiluje się i uruchamia bez błędów.
- [ ] Każda zmienna ma czytelną nazwę i odpowiedni typ.
- [ ] W programie występuje co najmniej jedna stała.
- [ ] Wszystkie wymagane operatory zostały użyte w sensownych obliczeniach.
- [ ] Dzielenie wymagające części ułamkowej nie jest dzieleniem całkowitym.
- [ ] Jawna konwersja jest wykonana świadomie i ma widoczny cel.
- [ ] Wartości logiczne są wynikiem porównań lub połączenia innych wartości `bool`.
- [ ] Karta pokazuje dane wejściowe i co najmniej trzy statystyki pochodne.
- [ ] Wynik jest czytelny dla osoby, która nie widzi kodu programu.
- [ ] Kod nie używa zagadnień z kolejnych tygodni.

#### Dla chętnych

Dodaj do karty informację o podziale złota między członków drużyny: liczbę monet przypadających każdej osobie oraz resztę pozostającą w skarbcu. Nadal nie używaj `if` ani pętli.

---

## Podsumowanie

Po ukończeniu laboratorium potrafisz:

- dobrać typ danych do znaczenia wartości,
- deklarować zmienne i stałe oraz aktualizować ich wartości,
- stosować operatory arytmetyczne i skrócone operatory przypisania,
- odróżnić dzielenie całkowite od zmiennoprzecinkowego,
- używać reszty z dzielenia,
- wykonywać jawne konwersje typów,
- budować i łączyć wyrażenia logiczne,
- formatować wyniki liczbowe,
- przedstawić stan programu jako czytelny raport.

---
