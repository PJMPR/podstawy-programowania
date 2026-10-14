---
layout: material
title: "Pierwsze decyzje"
kind: lab
week: 3
summary: "Ćwiczymy instrukcje if, else if, else i switch-case, a następnie rozbudowujemy kartę bohatera o decyzje i wybór akcji."
published: true
content_ready: true
---

## Cel laboratorium

Podczas tego laboratorium przećwiczysz podejmowanie decyzji w programie. Nauczysz się reagować na wartości podane przez użytkownika, wybierać jeden z kilku wariantów oraz łączyć warunki za pomocą operatorów logicznych.

Do wykonania jest **6 zadań**:

- 2 łatwe,
- 2 średnie,
- 2 trudne.

Ostatnie zadanie rozwija projekt z poprzednich tygodni — program **„Hello Adventurer”** otrzyma informacje o stanie bohatera, decyzje związane z wyprawą oraz menu wyboru akcji.

> **Ważne:** zadania nie wymagają jeszcze pętli, tablic ani własnych funkcji. Zakładamy, że użytkownik wpisuje dane w poprawnym formacie. Niepoprawny tekst przekazany do konwersji liczby może zakończyć program błędem.

---

## Przygotowanie

1. Otwórz projekt konsolowy C# z poprzednich zajęć albo utwórz nowy.
2. W każdym zadaniu używaj nazw zmiennych opisujących przechowywane dane.
3. Przed uruchomieniem spróbuj przewidzieć wynik dla kilku zestawów danych.
4. Testuj przypadki graniczne, np. 0, wartości ujemne oraz pierwszy i ostatni element przedziału.
5. Po każdym większym fragmencie uruchom program i porównaj wynik z założeniami.

Możesz pracować w jednym projekcie, zastępując kod po ukończeniu zadania, albo utworzyć osobny projekt dla każdego ćwiczenia.

---

## Kolorowanie tekstu i tła konsoli

Kolor może ułatwić odczytywanie komunikatów programu. W C# kolor tekstu zmieniamy za pomocą właściwości Console.ForegroundColor, a kolor tła za pomocą Console.BackgroundColor.

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Bohater żyje.");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Bohater nie żyje.");

    Console.ResetColor();

Console.ResetColor() przywraca domyślne kolory konsoli. Warto wywołać tę metodę po kolorowanym komunikacie, aby następne teksty nie odziedziczyły przypadkowego koloru.

Kolor tła ustawiamy podobnie:

    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Clear();
    Console.WriteLine("Raport bohatera");
    Console.ResetColor();

Console.Clear() czyści ekran i pozwala od razu zobaczyć efekt zmiany tła. Dostępne kolory znajdują się w wyliczeniu ConsoleColor, np. Red, Green, Yellow, Blue, Cyan, White, DarkGray i DarkBlue.

Kolor można wybrać również warunkowo:

    if (punktyZycia > 0)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Bohater żyje.");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Bohater nie żyje.");
    }

    Console.ResetColor();

> **Ważne:** kolory są elementem wyglądu programu. Nie powinny być jedynym sposobem przekazywania informacji — komunikat tekstowy nadal musi jasno opisywać wynik.

### Ćwiczenie kolorystyczne

Rozbuduj zadanie 1 albo zadanie 4:

1. wyświetl pozytywny wynik na zielono,
2. wyświetl ostrzeżenie na żółto,
3. wyświetl błąd lub przegraną na czerwono,
4. po każdym komunikacie przywróć domyślny kolor,
5. w raporcie użyj innego koloru tła niż domyślny, a następnie przywróć ustawienia.

Nie koloruj całego programu jednym kolorem. Dobierz kolor do znaczenia komunikatu.

---

## Poziom łatwy

### Zadanie 1. Czy liczba jest parzysta?

Pobierz od użytkownika liczbę całkowitą. Sprawdź, czy jest parzysta, wykorzystując operator reszty z dzielenia.

Program powinien:

1. wyświetlić komunikat „Liczba jest parzysta.” albo „Liczba jest nieparzysta.”,
2. zadziałać dla liczb dodatnich, zera i liczb ujemnych,
3. wykorzystać instrukcję if oraz operator procentu.

Przykładowe wyniki:

    Podaj liczbę: 24
    Liczba jest parzysta.

    Podaj liczbę: 17
    Liczba jest nieparzysta.

### Zadanie 2. Kierunek wyprawy

Pobierz od użytkownika jedno słowo opisujące kierunek: północ, południe, wschód albo zachód.

Za pomocą switch-case wyświetl odpowiedni opis:

- północ — „Wyruszasz w stronę gór.”
- południe — „Wyruszasz w stronę pustyni.”
- wschód — „Wyruszasz w stronę lasu.”
- zachód — „Wyruszasz w stronę morza.”

Dla innej wartości wyświetl „Nieznany kierunek.” Pamiętaj o break i default.

---

## Poziom średni

### Zadanie 3. Klasyfikacja wieku

Pobierz wiek użytkownika jako liczbę całkowitą i przypisz go do jednej z kategorii:

- wartość mniejsza od 0 — niepoprawny wiek,
- od 0 do 12 — dziecko,
- od 13 do 17 — nastolatek,
- od 18 do 64 — osoba dorosła,
- 65 i więcej — senior.

Użyj if, else if i else. Sprawdź szczególnie wartości graniczne: 0, 12, 13, 17, 18, 64 i 65.

### Zadanie 4. Czy bohater może wejść do lochu?

Pobierz:

- punkty życia,
- informację, czy bohater ma klucz,
- informację, czy zna hasło.

Następnie wyświetl decyzję zgodnie z regułami:

1. Jeśli punkty życia są mniejsze lub równe 0, bohater nie może wejść, ponieważ nie żyje.
2. Jeśli żyje i ma klucz albo zna hasło, może wejść.
3. W przeciwnym przypadku nie może wejść, ponieważ nie ma sposobu otwarcia drzwi.

Użyj operatorów porównania, &&, || oraz instrukcji if, else if i else.

Przykładowe scenariusze:

    Punkty życia: 80
    Ma klucz: false
    Zna hasło: true
    Bohater może wejść do lochu.

    Punkty życia: 0
    Ma klucz: true
    Zna hasło: true
    Bohater nie może wejść — nie żyje.

---

## Poziom trudny

### Krótkie ćwiczenie. Operator warunkowy

Zanim przejdziesz do trudniejszych zadań, wykonaj dwa krótkie przykłady z operatorem ?:.

1. Pobierz punkty życia i utwórz zmienną tekstową stan, która otrzyma wartość „żyje” albo „nie żyje”.
2. Pobierz liczbę złota i utwórz zmienną tekstową informacja, która będzie zawierać komunikat „Możesz kupić miksturę.” albo „Brakuje złota.”. Przyjmij cenę mikstury równą 30.

W obu przykładach użyj operatora warunkowego zamiast pełnego if i else.

Następnie przepisz jeden z przykładów za pomocą pełnego if i else. Porównaj oba zapisy i odpowiedz, który jest czytelniejszy w tym konkretnym przypadku.

### Zadanie 5. Raport z walki

Napisz program opisujący wynik jednej decyzji podczas walki. Pobierz:

- aktualne punkty życia bohatera,
- podstawowe obrażenia broni,
- informację, czy bohater ma miksturę,
- wybraną akcję: 1 — atak, 2 — leczenie, 3 — ucieczka.

Program powinien działać według reguł:

- jeśli bohater ma 0 lub mniej punktów życia, wyświetl informację o przegranej i nie wykonuj akcji,
- dla akcji 1 wyświetl obrażenia,
- dla akcji 2 wyświetl informację o leczeniu, ale tylko gdy bohater ma miksturę,
- dla akcji 3 wyświetl informację o ucieczce,
- dla innej akcji wyświetl „Nieznana akcja.”,
- jeśli bohater żyje, ale ma mniej niż 20 punktów życia, dodaj ostrzeżenie o niskim zdrowiu.

Do wyboru akcji użyj switch-case, a do sprawdzenia stanu bohatera i mikstury użyj instrukcji warunkowych.

### Zadanie 6. Projekt — „Karta bohatera 3.0”

Rozbuduj program **„Hello Adventurer”** z poprzednich laboratoriów. Karta bohatera ma tym razem nie tylko przechowywać dane, ale również podejmować decyzje na podstawie stanu postaci.

#### Wymagania

Program powinien:

1. pobrać imię bohatera,
2. pobrać co najmniej cztery wartości opisujące bohatera, np. punkty życia, poziom, złoto, siłę, liczbę mikstur i informację o posiadaniu mapy,
3. obliczyć co najmniej trzy wartości logiczne, np. zyje, maNiskiPoziomZdrowia, mozeWyruszyc i jestBogaty,
4. wyświetlić kartę bohatera z danymi oraz wynikami sprawdzeń,
5. użyć if, else if lub else do opisania stanu bohatera,
6. użyć switch-case do wyboru jednej z akcji,
7. obsłużyć nieznaną akcję za pomocą default,
8. wykorzystać co najmniej jedno połączenie operatorów && i ||,
9. wykorzystać operator ?: do utworzenia co najmniej jednej krótkiej informacji tekstowej,
10. pokolorować wynik programu za pomocą Console.ForegroundColor lub Console.BackgroundColor,
11. przywrócić domyślne kolory za pomocą Console.ResetColor(),
12. nie używać pętli, tablic ani własnych funkcji.

#### Proponowane reguły

Bohater:

- żyje, gdy ma więcej niż 0 punktów życia,
- ma niski poziom zdrowia, gdy żyje i ma mniej niż 25 punktów,
- może wyruszyć, gdy żyje oraz ma mapę albo kompas,
- jest bogaty, gdy ma co najmniej 100 sztuk złota,
- jest gotowy do walki, gdy żyje i ma co najmniej jedną miksturę.

Na podstawie punktów życia wyświetl jeden z komunikatów:

- „Bohater nie żyje.”
- „Bohater jest ranny.”
- „Bohater jest w dobrej formie.”

Następnie wyświetl menu:

1. sprawdź stan,
2. rozpocznij wyprawę,
3. przygotuj miksturę,
4. odpocznij.

Pobierz numer akcji i obsłuż go przez switch-case. Dla nieznanego numeru wyświetl odpowiedni komunikat.

#### Trzy warianty prezentacji wyniku

Wybierz jeden z poniższych wariantów. W każdym z nich wyświetl te same dane, ale zaprojektuj inny układ i zastosuj kolory zgodnie z opisem.

##### Wariant A. Klasyczna karta bohatera

Użyj ramki złożonej ze znaków +, - i |.

    +======================================+
    |           KARTA BOHATERA             |
    +======================================+
    | Bohater: Nela                        |
    | Zdrowie: 75                          |
    | Mikstury: 2                          |
    | Złoto: 120                           |
    | Ma mapę: True                        |
    +--------------------------------------+
    | Żyje: True                           |
    | Niski poziom zdrowia: False          |
    | Może wyruszyć: True                  |
    | Jest bogata: True                    |
    | Gotowa do walki: True                |
    +======================================+

Pokoloruj nagłówek na jasny kolor na ciemnym tle. Wartość zdrowia pokaż na zielono, żółto albo czerwono zależnie od stanu bohatera.

##### Wariant B. Panel statusu

Przedstaw informacje jako krótkie sekcje raportu:

    ===== STATUS BOHATERA =====
    Nela

    ZDROWIE       75
    MIKSTURY       2
    ZŁOTO        120
    MAPA         TAK

    GOTOWOŚĆ DO WYPRAWY: TAK
    =========================

Użyj osobnego koloru dla nagłówka, osobnego dla danych oraz koloru sygnalizującego wynik decyzji. Dla wartości logicznych możesz wyświetlać komunikaty TAK/NIE zamiast True/False.

##### Wariant C. Dziennik wyprawy

Przedstaw wynik jako wpis narracyjny:

    * * * DZIENNIK WYPRAWY * * *
    Bohaterka Nela rozpoczyna dzień z 75 punktami zdrowia.
    W plecaku ma 2 mikstury i mapę.
    Posiada 120 sztuk złota.

    Status: GOTOWA DO WYPRAWY
    Wybrana akcja: rozpocznij wyprawę
    * * * * * * * * * * * * * *

Kolorem wyróżnij tytuł, status oraz ostrzeżenia. Jeśli bohater nie może działać, użyj koloru czerwonego dla komunikatu o przyczynie.

Niezależnie od wybranego wariantu wynik powinien być czytelny dla osoby, która nie widzi kodu programu. Po każdym kolorowanym fragmencie przywróć ustawienia za pomocą Console.ResetColor().

#### Kryteria ukończenia

- [ ] Program kompiluje się i uruchamia bez błędów dla poprawnych danych.
- [ ] Program pobiera dane bohatera.
- [ ] Wartości logiczne są wynikiem porównań lub operatorów logicznych.
- [ ] Obsłużony jest stan bohatera niezdolnego do działania.
- [ ] Menu akcji działa za pomocą switch-case.
- [ ] Istnieje przypadek default.
- [ ] Wynik zawiera dane wejściowe, stan bohatera i komunikat podjętej decyzji.
- [ ] Wynik jest przedstawiony w jednym z trzech wariantów prezentacji.
- [ ] Co najmniej nagłówek, status i jeden komunikat decyzji są odpowiednio pokolorowane.
- [ ] Kolory są resetowane po zakończeniu kolorowanych fragmentów.
- [ ] Testowane były wartości graniczne, np. 0, 1, 24, 25 i 100 punktów życia lub złota.
- [ ] Kod nie używa pętli, tablic ani własnych funkcji.

#### Dla chętnych

- Dodaj osobne komunikaty dla bohatera bez mapy i bez kompasu.
- Dodaj wybór poziomu trudności przez switch-case.
- Dodaj informację, czy bohater może kupić miksturę za 30 sztuk złota.
- Dodaj do karty krótkie komunikaty utworzone operatorem ?:, np. informację o mapie, złocie lub gotowości do wyprawy.
- Pokoloruj kartę bohatera: zdrowie na zielono, niski poziom zdrowia na żółto, a przegraną na czerwono.
- Ustaw ciemne tło dla nagłówka karty i wywołaj ResetColor po jego wyświetleniu.
- Rozróżnij akcję leczenia, gdy mikstura jest dostępna, od próby leczenia bez mikstury.

---

## Podsumowanie

Po ukończeniu laboratorium potrafisz:

- stosować if, else if i else,
- porównywać liczby i teksty,
- łączyć warunki za pomocą &&, || i !,
- stosować operator warunkowy ?: do prostego wyboru jednej z dwóch wartości,
- zmieniać kolor tekstu za pomocą Console.ForegroundColor,
- zmieniać kolor tła za pomocą Console.BackgroundColor i przywracać ustawienia przez Console.ResetColor,
- sprawdzać przedziały i wartości graniczne,
- używać zagnieżdżonych instrukcji warunkowych,
- wybierać wariant za pomocą switch-case,
- stosować break i default,
- reagować na dane użytkownika,
- budować decyzje opisujące stan bohatera.
