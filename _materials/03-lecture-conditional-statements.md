---
layout: material
title: "Instrukcje warunkowe"
kind: lecture
week: 3
summary: "Podejmowanie decyzji za pomocą if, else if, else i switch-case oraz budowanie warunków z operatorów porównania i logiki."
published: true
content_ready: true
---

## Cel wykładu

Do tej pory program wykonywał wszystkie instrukcje po kolei. Teraz nauczymy się sprawdzać warunki i wykonywać różne instrukcje zależnie od sytuacji.

Po tym wykładzie będziesz potrafić:

- użyć instrukcji if, else if i else,
- łączyć warunki operatorami &&, || i !,
- budować zagnieżdżone decyzje,
- wybrać między wariantami za pomocą switch-case,
- przewidzieć, które instrukcje zostaną wykonane.

> **Ważne:** warunek w C# musi mieć typ bool, czyli wartość true albo false.

---

## 1. Pierwsza decyzja — if

Instrukcja warunkowa odpowiada na pytanie: **czy spełniony jest określony warunek?**

    int punktyZycia = 75;

    if (punktyZycia > 0)
    {
        Console.WriteLine("Bohater żyje.");
    }

Program oblicza wyrażenie punktyZycia > 0. Ponieważ 75 > 0 jest prawdą, wykonuje kod wewnątrz klamr. Dla wartości 0 blok zostałby pominięty.

Klamry {} wyznaczają blok instrukcji. Warto je stosować również wtedy, gdy blok zawiera tylko jedną instrukcję.

### Operatory porównania

| Operator | Znaczenie | Przykład |
|---|---|---|
| == | równe | poziom == 3 |
| != | różne | poziom != 3 |
| < | mniejsze niż | poziom < 5 |
| > | większe niż | poziom > 5 |
| <= | mniejsze lub równe | poziom <= 3 |
| >= | większe lub równe | poziom >= 3 |

Nie myl przypisania = z porównaniem ==:

    int punkty = 10;
    punkty = 20;       // przypisanie

    if (punkty == 20)  // porównanie
    {
        Console.WriteLine("Punkty wynoszą 20.");
    }

Porównanie tekstu również wykonuje się przez == i jest wrażliwe na wielkość liter.

> **Pytanie do sali:** Co pojawi się na ekranie dla punktyZycia = 0, a co dla punktyZycia = -10?

---

## 2. Dwa warianty — if i else

Jeżeli chcemy opisać dwa wzajemnie wykluczające się przypadki, dodajemy else:

    Console.Write("Podaj liczbę punktów życia: ");
    int punktyZycia = int.Parse(Console.ReadLine()!);

    if (punktyZycia > 0)
    {
        Console.WriteLine("Bohater żyje.");
    }
    else
    {
        Console.WriteLine("Bohater nie żyje.");
    }

Wykona się dokładnie jeden blok: if albo else.

### else i zagnieżdżony if

    if (maKlucz)
    {
        if (drzwiOtwarte)
        {
            Console.WriteLine("Możesz przejść.");
        }
        else
        {
            Console.WriteLine("Masz klucz, ale drzwi są zamknięte.");
        }
    }
    else
    {
        Console.WriteLine("Nie masz klucza.");
    }

Wewnętrzne else należy do if (drzwiOtwarte), a zewnętrzne do if (maKlucz). Klamry sprawiają, że relacja jest jednoznaczna.

---

## 3. Kilka wariantów — else if

Program sprawdza warunki od góry do dołu i wykonuje pierwszy prawdziwy blok:

    int punkty = 82;

    if (punkty >= 90)
    {
        Console.WriteLine("Ocena: bardzo dobry.");
    }
    else if (punkty >= 75)
    {
        Console.WriteLine("Ocena: dobry.");
    }
    else if (punkty >= 50)
    {
        Console.WriteLine("Ocena: dostateczny.");
    }
    else
    {
        Console.WriteLine("Ocena: niedostateczny.");
    }

Kolejność ma znaczenie. Warunek szczegółowy powinien być przed ogólnym:

    // Dla 95 pierwszy blok zakończy sprawdzanie.
    if (punkty >= 50)
    {
        Console.WriteLine("Zaliczenie.");
    }
    else if (punkty >= 90)
    {
        Console.WriteLine("Bardzo dobry wynik.");
    }

> **Minićwiczenie:** Napisz klasyfikację wieku: dziecko poniżej 13, nastolatek od 13 do 17, dorosły od 18 do 64, senior od 65.

---

## 4. Łączenie warunków

| Operator | Znaczenie | Kiedy wynik jest true |
|---|---|---|
| && | i | oba warunki są prawdziwe |
| || | lub | przynajmniej jeden warunek jest prawdziwy |
| ! | nie | wartość po odwróceniu jest prawdziwa |

    int punktyZycia = 80;
    bool maMape = true;

    if (punktyZycia > 0 && maMape)
    {
        Console.WriteLine("Bohater może wyruszyć.");
    }

Operator && wymaga obu warunków, a || co najmniej jednego:

    bool maKlucz = false;
    bool znaHaslo = true;

    if (maKlucz || znaHaslo)
    {
        Console.WriteLine("Możesz otworzyć drzwi.");
    }

Negacja odwraca wartość:

    bool drzwiOtwarte = false;

    if (!drzwiOtwarte)
    {
        Console.WriteLine("Drzwi są zamknięte.");
    }

Nawiasy pomagają pokazać sens złożonego warunku:

    bool gotowy = (punktyZycia > 0) && (maMape || maKlucz);

Operatory && i || stosują krótkie wartościowanie:

    if (tekst != null && tekst.Length > 0)
    {
        Console.WriteLine("Tekst nie jest pusty.");
    }

Jeżeli tekst != null jest fałszywe, C# nie sprawdzi drugiej części.

---

## 5. Zagnieżdżenia i wartości pomocnicze

Instrukcję warunkową można umieścić wewnątrz innej:

    int punktyZycia = 60;
    bool maBron = true;

    if (punktyZycia > 0)
    {
        if (maBron)
        {
            Console.WriteLine("Bohater może walczyć.");
        }
        else
        {
            Console.WriteLine("Bohater nie ma broni.");
        }
    }
    else
    {
        Console.WriteLine("Bohater nie może walczyć.");
    }

Czasem czytelniejsza jest pomocnicza wartość logiczna:

    bool zyje = punktyZycia > 0;
    bool mozeWalczyc = zyje && maBron;

    if (mozeWalczyc)
    {
        Console.WriteLine("Bohater może walczyć.");
    }
    else
    {
        Console.WriteLine("Bohater nie może walczyć.");
    }

---

## 6. Wielowariantowy wybór — switch-case

switch wybiera jeden wariant na podstawie jednej wartości. Jest szczególnie czytelny, gdy porównujemy ją z konkretnymi wartościami:

    int numerDnia = 2;

    switch (numerDnia)
    {
        case 1:
            Console.WriteLine("Poniedziałek");
            break;
        case 2:
            Console.WriteLine("Wtorek");
            break;
        case 3:
            Console.WriteLine("Środa");
            break;
        default:
            Console.WriteLine("Nieznany numer dnia.");
            break;
    }

Elementy:

- switch (numerDnia) — wartość sprawdzana,
- case 2: — jeden możliwy przypadek,
- instrukcje pod case — kod danego wariantu,
- break — wyjście z switch,
- default — obsługa wartości bez pasującego case.

### switch na tekście

    Console.Write("Wybierz kierunek: ");
    string kierunek = Console.ReadLine()!;

    switch (kierunek)
    {
        case "północ":
            Console.WriteLine("Idziesz w stronę gór.");
            break;
        case "południe":
            Console.WriteLine("Idziesz w stronę pustyni.");
            break;
        case "wschód":
            Console.WriteLine("Idziesz w stronę lasu.");
            break;
        case "zachód":
            Console.WriteLine("Idziesz w stronę morza.");
            break;
        default:
            Console.WriteLine("Nieznany kierunek.");
            break;
    }

### Kilka wartości w jednym przypadku

    char ruch = 'w';

    switch (ruch)
    {
        case 'w':
        case 'W':
            Console.WriteLine("Ruch do przodu.");
            break;
        case 's':
        case 'S':
            Console.WriteLine("Ruch do tyłu.");
            break;
        default:
            Console.WriteLine("Nieobsługiwany klawisz.");
            break;
    }

Użyj switch, gdy porównujesz jedną wartość z konkretnymi wariantami, na przykład numerem menu. Użyj if, gdy sprawdzasz zakresy, nierówności lub złożone warunki. W klasycznym switch-case nie pomijaj break.

---

## 7. Walidacja i proste menu

    Console.Write("Podaj wiek: ");
    int wiek = int.Parse(Console.ReadLine()!);

    if (wiek < 0)
    {
        Console.WriteLine("Wiek nie może być ujemny.");
    }
    else if (wiek < 13)
    {
        Console.WriteLine("Kategoria: dziecko.");
    }
    else if (wiek < 18)
    {
        Console.WriteLine("Kategoria: nastolatek.");
    }
    else
    {
        Console.WriteLine("Kategoria: osoba dorosła.");
    }

switch dobrze pasuje do prostego menu:

    Console.WriteLine("1 - Sprawdź zdrowie");
    Console.WriteLine("2 - Otwórz mapę");
    Console.WriteLine("3 - Zakończ grę");
    Console.Write("Wybierz opcję: ");
    int opcja = int.Parse(Console.ReadLine()!);

    switch (opcja)
    {
        case 1:
            Console.WriteLine("Punkty życia: 85.");
            break;
        case 2:
            Console.WriteLine("Mapa została otwarta.");
            break;
        case 3:
            Console.WriteLine("Koniec gry.");
            break;
        default:
            Console.WriteLine("Nie ma takiej opcji.");
            break;
    }

Program nie powtarza jeszcze menu — pętle poznamy później.

---

## 8. Warunek jednolinijkowy — operator ?:

Jeśli chcemy wybrać jedną z dwóch wartości, możemy użyć operatora warunkowego ?:. Jest to skrócony zapis prostego if i else.

Ogólna składnia wygląda tak:

    warunek ? wartośćDlaPrawdy : wartośćDlaFałszu

Przykład:

    int punktyZycia = 75;
    string stan = punktyZycia > 0 ? "żyje" : "nie żyje";

    Console.WriteLine($"Bohater {stan}.");

Najpierw program sprawdza warunek przed znakiem zapytania. Jeśli jest prawdziwy, wybiera wartość między ? a :. Jeśli jest fałszywy, wybiera wartość znajdującą się po :.

Ten zapis jest równoważny:

    string stan;

    if (punktyZycia > 0)
    {
        stan = "żyje";
    }
    else
    {
        stan = "nie żyje";
    }

Operator ?: najlepiej stosować wtedy, gdy każda gałąź tylko wybiera wartość. Jeżeli w gałęziach znajduje się kilka instrukcji albo wykonywane są różne działania, czytelniejszy będzie pełny if i else.

Można go użyć również do wyświetlenia krótkiego komunikatu:

    bool maMape = true;
    Console.WriteLine(maMape ? "Mapa jest w plecaku." : "Brakuje mapy.");

Operator ?: nie zastępuje switch-case. Służy do wyboru jednej z dwóch wartości, a switch pozwala obsłużyć wiele konkretnych wariantów.

### Zagnieżdżony operator warunkowy

Technicznie można połączyć kilka operatorów ?:, ale taki zapis szybko staje się nieczytelny:

    string opis = punktyZycia <= 0
        ? "nie żyje"
        : punktyZycia < 25
            ? "jest ranny"
            : "jest w dobrej formie";

Przy większej liczbie wariantów lepiej użyć if i else if.

---

## 9. Najczęstsze błędy

### Średnik po warunku

    // Błąd logiczny — blok wykona się zawsze.
    if (punktyZycia > 0);
    {
        Console.WriteLine("Ten komunikat pojawi się zawsze.");
    }

### Brak klamer

    if (maKlucz)
        Console.WriteLine("Masz klucz.");
        Console.WriteLine("Ten komunikat wykona się zawsze.");

Bez klamer tylko pierwsza instrukcja należy do if. Pamiętaj też, że warunek ogólny przed szczegółowym może zasłonić else if, a brak default pozostawi nieoczekiwaną wartość bez komunikatu.

---

## Podsumowanie

- if wykonuje blok, gdy warunek ma wartość true,
- else opisuje alternatywny wariant,
- else if pozwala sprawdzić kilka wariantów w ustalonej kolejności,
- warunek musi mieć typ bool,
- operatory ==, !=, <, >, <= i >= tworzą porównania,
- && wymaga obu warunków, || co najmniej jednego, a ! odwraca wynik,
- switch-case służy do wyboru na podstawie jednej wartości,
- break kończy przypadek switch, a default obsługuje pozostałe wartości,
- operator ?: jest krótkim zapisem wyboru jednej z dwóch wartości,
- if pasuje do zakresów i złożonych warunków, a switch do konkretnych wariantów.

## Ściąga

    if (punktyZycia > 0)
    {
        Console.WriteLine("Bohater żyje.");
    }
    else
    {
        Console.WriteLine("Bohater nie żyje.");
    }

    bool gotowy = (punktyZycia > 0) && (maMape || maKlucz);

    string stan = punktyZycia > 0 ? "żyje" : "nie żyje";

    switch (opcja)
    {
        case 1:
            Console.WriteLine("Wybrano pierwszą opcję.");
            break;
        default:
            Console.WriteLine("Nieznana opcja.");
            break;
    }
