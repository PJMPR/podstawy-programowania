---
layout: material
title: "Zmienne, typy i operatory"
kind: lecture
week: 2
summary: "Zmienne i stałe, typy liczbowe, operatory arytmetyczne i logiczne, kolejność działań oraz konwersje typów."
published: true
content_ready: true
---

## Cel wykładu

Na poprzednim wykładzie używaliśmy zmiennych do zapisywania danych. Teraz przyjrzymy się im dokładniej: nauczymy się dobierać typ do przechowywanej wartości, budować wyrażenia, przewidywać wyniki obliczeń i świadomie konwertować dane między typami.

Po tym wykładzie będziesz potrafić opisać **stan prostego programu**, na przykład punkty życia, liczbę monet i gotowość bohatera do wyprawy, a następnie obliczać nowe wartości na podstawie tego stanu.

> **Ważne:** na tym etapie program nadal wykonuje wszystkie instrukcje kolejno. Wartości logiczne będziemy obliczać i wyświetlać, ale dopiero na następnym wykładzie użyjemy ich do podejmowania decyzji za pomocą `if`.

---

## 1. Zmienna: typ, nazwa i wartość

**Zmienna** to nazwane miejsce przechowujące wartość określonego typu.

```csharp
int punktyZycia = 100;
```

W tej deklaracji:

- `int` jest typem,
- `punktyZycia` jest nazwą zmiennej,
- `100` jest jej początkową wartością,
- `=` jest operatorem przypisania.

### Deklaracja, inicjalizacja i przypisanie

```csharp
int zloto;       // deklaracja zmiennej
zloto = 25;      // pierwsze przypisanie wartości
zloto = 40;      // zmiana wartości
```

Najczęściej deklarujemy zmienną i od razu ją inicjalizujemy:

```csharp
int zloto = 25;
```

Z prawej strony operatora `=` może znajdować się całe wyrażenie. Najpierw zostanie ono obliczone, a dopiero potem wynik trafi do zmiennej po lewej stronie.

```csharp
int sila = 12;
int premiaBroni = 5;
int obrazenia = sila + premiaBroni;
```

> **Pytanie do sali:** Jaka wartość znajdzie się w zmiennej `obrazenia`? Czy późniejsza zmiana `sila` automatycznie zmieni zapamiętane `obrazenia`?

### Zmiana wartości krok po kroku

```csharp
int punkty = 10;
punkty = punkty + 5;
punkty = punkty * 2;

Console.WriteLine(punkty); // 30
```

Instrukcję `punkty = punkty + 5` czytamy od prawej strony:

1. pobierz dotychczasową wartość `punkty`,
2. dodaj `5`,
3. zapisz wynik z powrotem w `punkty`.

### Dobre nazwy

Nazwy zmiennych powinny opisywać znaczenie danych:

```csharp
int x = 80;                      // mało czytelne
int maksymalnePunktyZycia = 80; // jasne znaczenie
```

W C# dla zmiennych używamy zwykle zapisu **camelCase**. Nazwa zaczyna się małą literą, a każde kolejne słowo wielką, np. `liczbaGraczy`.

Nazwy:

- nie mogą zaczynać się cyfrą,
- nie mogą zawierać spacji ani myślników,
- mogą zawierać litery, cyfry i znak `_`,
- rozróżniają wielkie i małe litery.

---

## 2. Wnioskowanie typu i stałe

### Słowo kluczowe `var`

Jeżeli wartość początkowa jednoznacznie wskazuje typ, kompilator może go wywnioskować:

```csharp
var poziom = 3;            // int
var cena = 19.99m;        // decimal
var nazwa = "Mikstura";   // string
var aktywny = true;       // bool
```

`var` nie oznacza „dowolnego typu”. Typ zostaje ustalony podczas kompilacji i później nie może się zmienić.

```csharp
var poziom = 3;
// poziom = "trzeci"; // błąd: zmienna ma typ int
```

Jawny typ jest często czytelniejszy dla początkujących. `var` warto stosować wtedy, gdy typ wynika bezpośrednio z prawej strony.

### Stałe

Jeżeli wartość nie powinna zmieniać się podczas działania programu, możemy zadeklarować **stałą** za pomocą `const`:

```csharp
const int MaksymalnyPoziom = 20;
const decimal CenaMikstury = 12.50m;
```

Próba ponownego przypisania wartości spowoduje błąd kompilacji:

```csharp
// MaksymalnyPoziom = 25;
```

Nazwy stałych zapisujemy w tych materiałach stylem **PascalCase**.

---

## 3. Typy danych i literały

Typ określa zbiór dozwolonych wartości, zajmowaną pamięć i możliwe operacje.

| Typ | Rozmiar | Przykład | Typowe zastosowanie |
|---|---:|---:|---|
| `sbyte` | 8 bitów | `-100` | bardzo małe liczby całkowite ze znakiem (`-128`–`127`) |
| `byte` | 8 bitów | `255` | surowe dane, składowe kolorów (`0`–`255`) |
| `short` | 16 bitów | `-30_000` | małe liczby całkowite ze znakiem |
| `ushort` | 16 bitów | `60_000` | małe nieujemne liczby całkowite |
| `int` | 32 bity | `120` | najczęściej używany typ całkowity: poziom, licznik, punkty życia |
| `uint` | 32 bity | `4_000_000_000U` | duże nieujemne liczby całkowite |
| `long` | 64 bity | `8_000_000_000L` | bardzo duże liczby całkowite ze znakiem |
| `ulong` | 64 bity | `16_000_000_000UL` | bardzo duże nieujemne liczby całkowite |
| `float` | 32 bity | `1.75f` | grafika i obliczenia przybliżone, gdy wystarcza około 6–9 cyfr precyzji |
| `double` | 64 bity | `1.75` | pomiary i obliczenia przybliżone; około 15–17 cyfr precyzji |
| `decimal` | 128 bitów | `49.99m` | kwoty i obliczenia dziesiętne; około 28–29 cyfr precyzji |
| `bool` | — | `true` | wartość logiczna: prawda albo fałsz |
| `char` | 16 bitów | `'A'` | pojedynczy znak |
| `string` | zależny od tekstu | `"Alicja"` | tekst złożony z dowolnej liczby znaków |

Typy rozpoczynające się literą `u`, na przykład `uint`, są **bez znaku** (ang. *unsigned*), dlatego przechowują tylko zero i liczby dodatnie. Dzięki temu ich maksymalna wartość jest większa niż w odpowiadających im typach ze znakiem.

### Literał i zmienna

**Literał** to wartość zapisana bezpośrednio w kodzie:

```csharp
int liczbaStrzal = 12;
short temperatura = -15;
uint liczbaMieszkancow = 4_000_000U;
float wysokoscSkoku = 1.75f;
double czasPrzejscia = 4.5;
decimal cena = 29.99m;
char symbolGracza = '@';
string nazwaGracza = "Nela";
bool maKlucz = false;
```

Warto zwrócić uwagę na zapis:

- tekst umieszczamy w cudzysłowie: `"Nela"`,
- pojedynczy znak w apostrofach: `'N'`,
- literał `float` kończymy literą `f`,
- literał `decimal` kończymy literą `m`,
- literał typu bez znaku możemy zakończyć literą `U`,
- literał `long`, który nie mieści się w `int`, kończymy literą `L`,
- dla literału `ulong` łączymy oba oznaczenia: `UL`,
- znak `_` może poprawić czytelność dużych liczb: `1_000_000`.

### `float`, `double` czy `decimal`?

Zarówno `float`, jak i `double` zapisują liczby w systemie binarnym. Działają według tej samej zasady, ale `float` zajmuje mniej pamięci i ma mniejszą precyzję. W zwykłych obliczeniach zmiennoprzecinkowych najczęściej używamy `double`; `float` jest często spotykany na przykład w grafice komputerowej, gdzie oszczędność pamięci może mieć znaczenie.

`double` przechowuje liczbę w systemie binarnym. Jej część ułamkowa jest budowana z potęg liczby `2`, na przykład `1/2`, `1/4`, `1/8` i `1/16`. Dlatego niektóre wartości można zapisać dokładnie:

```text
0,5 = 1/2
0,75 = 1/2 + 1/4
```

Nie da się jednak w ten sposób zapisać dokładnie wielu prostych ułamków dziesiętnych, między innymi `0.1` i `0.2`. Ich zapis binarny ma nieskończenie wiele cyfr — podobnie jak `1 / 3` ma nieskończony zapis `0,333...` w systemie dziesiętnym.

`double` ma ograniczoną liczbę bitów, dlatego zapisuje najbliższą możliwą wartość. W pamięci znajduje się więc liczba minimalnie różniąca się od tej zapisanej w kodzie. Jest to **błąd reprezentacji**. Zwykle jest bardzo mały, ale może stać się widoczny po wykonaniu obliczeń. Nie jest to usterka typu `double`, lecz skutek zaokrąglenia nieskończonego rozwinięcia do dostępnej precyzji.

```csharp
double wynik = 0.1 + 0.2;
Console.WriteLine(wynik); // może pokazać 0,30000000000000004
```

Typ `decimal` działa inaczej: przechowuje cyfry liczby oraz informację o liczbie miejsc po przecinku w systemie dziesiętnym. Można go w uproszczeniu wyobrazić sobie jako liczbę całkowitą pomnożoną przez potęgę `10`. Na przykład `0.1m` jest przechowywane jako `1 × 10⁻¹`, a `12.34m` jako `1234 × 10⁻²`. Te wartości są więc reprezentowane dokładnie:

```csharp
decimal cena = 0.1m;
decimal podatek = 0.2m;
Console.WriteLine(cena + podatek); // 0,3
```

Nie oznacza to, że `decimal` potrafi dokładnie zapisać każdy wynik. On również ma ograniczoną precyzję, więc na przykład rozwinięcie `1 / 3` musi zostać zaokrąglone. Nie występuje w nim jednak problem z dokładnym zapisem typowych skończonych ułamków dziesiętnych, takich jak `0.1`, `19.99` czy `0.01`. Z tego powodu `decimal` zwykle wybieramy do obliczeń finansowych, a `double` do pomiarów i obliczeń naukowych, w których niewielki błąd przybliżenia jest akceptowalny.

---

## 4. Operatory arytmetyczne

Operatory arytmetyczne tworzą wyrażenia liczbowe.

| Operator | Działanie | Przykład | Wynik |
|---|---|---|---:|
| `+` | dodawanie | `7 + 3` | `10` |
| `-` | odejmowanie | `7 - 3` | `4` |
| `*` | mnożenie | `7 * 3` | `21` |
| `/` | dzielenie | `7 / 3` | `2` dla dwóch `int` |
| `%` | reszta z dzielenia | `7 % 3` | `1` |

```csharp
int zloto = 40;
int nagroda = 15;
int zakupy = 12;

int stanSakiewki = zloto + nagroda - zakupy;
Console.WriteLine(stanSakiewki); // 43
```

### Dzielenie całkowite

Gdy oba argumenty dzielenia są typu całkowitego, wynik również jest całkowity. Część ułamkowa zostaje odrzucona.

```csharp
int wynikCalkowity = 7 / 2;
double wynikDokladny = 7.0 / 2.0;

Console.WriteLine(wynikCalkowity); // 3
Console.WriteLine(wynikDokladny);  // 3,5
```

Wystarczy, aby jeden z argumentów był typu `double`:

```csharp
double srednia = 7 / 2.0;
```

### Reszta z dzielenia

Operator `%` przydaje się między innymi do podziału zasobów i rozpoznawania liczb parzystych.

```csharp
int monety = 17;
int bohaterowie = 4;

int dlaKazdego = monety / bohaterowie;
int pozostalo = monety % bohaterowie;

Console.WriteLine($"Każdy otrzyma {dlaKazdego}, pozostanie {pozostalo}.");
```

> **Minićwiczenie:** Zapisz `367` sekund jako liczbę pełnych minut i pozostałych sekund.

### Kolejność działań

C# zachowuje matematyczną kolejność działań: najpierw nawiasy, potem mnożenie, dzielenie i reszta, a na końcu dodawanie i odejmowanie.

```csharp
int pierwszyWynik = 2 + 3 * 4;   // 14
int drugiWynik = (2 + 3) * 4;    // 20
```

Nawiasy warto stosować także wtedy, gdy jedynie poprawiają czytelność.

---

## 5. Skrócone operatory przypisania

Aktualizowanie zmiennej można zapisać krócej:

| Pełny zapis | Skrócony zapis |
|---|---|
| `punkty = punkty + 10;` | `punkty += 10;` |
| `punkty = punkty - 5;` | `punkty -= 5;` |
| `punkty = punkty * 2;` | `punkty *= 2;` |
| `punkty = punkty / 3;` | `punkty /= 3;` |
| `punkty = punkty % 4;` | `punkty %= 4;` |

```csharp
int punktyZycia = 100;
punktyZycia -= 25; // otrzymane obrażenia
punktyZycia += 10; // leczenie

Console.WriteLine(punktyZycia); // 85
```

Zwiększenie lub zmniejszenie wartości o jeden ma własny zapis:

```csharp
int numerTury = 1;
numerTury++;
numerTury--;
```

Na tym etapie używamy `++` i `--` jako osobnych instrukcji. Ich umieszczanie wewnątrz większych wyrażeń może prowadzić do mało czytelnego kodu.

---

## 6. Tekst i znaki

Typ `char` przechowuje dokładnie jeden znak, a `string` — cały napis.

```csharp
char symbolBohatera = '@';
string imieBohatera = "Aria";
string pustaWiadomosc = "";
```

Operator `+` łączy napisy:

```csharp
string tytul = "Strażniczka";
string podpis = imieBohatera + " — " + tytul;
```

Zwykle czytelniejsza jest interpolacja:

```csharp
int poziom = 2;
Console.WriteLine($"{imieBohatera}, poziom {poziom}");
```

Uwaga na różne znaczenie operatora `+`:

```csharp
Console.WriteLine(2 + 3);              // 5
Console.WriteLine("2" + "3");          // 23
Console.WriteLine("Wynik: " + 2 + 3); // Wynik: 23
Console.WriteLine($"Wynik: {2 + 3}"); // Wynik: 5
```

> **Pytanie do sali:** Dlaczego trzeci przykład nie wyświetla liczby `5`?

---

## 7. Wartości logiczne i operatory logiczne

Typ `bool` ma tylko dwie możliwe wartości: `true` i `false`.

```csharp
bool maMape = true;
bool drzwiOtwarte = false;
```

Porównanie dwóch wartości również daje wynik typu `bool`:

```csharp
int punktyZycia = 45;
int zloto = 30;

bool zyje = punktyZycia > 0;
bool stacNaMiksture = zloto >= 20;
bool maDokladniePelneZdrowie = punktyZycia == 100;
bool maZloto = zloto != 0;
```

| Operator | Znaczenie |
|---|---|
| `==` | równe |
| `!=` | różne |
| `<` | mniejsze niż |
| `>` | większe niż |
| `<=` | mniejsze lub równe |
| `>=` | większe lub równe |

Nie myl `=` z `==`: pierwszy operator przypisuje wartość, a drugi porównuje dwie wartości.

Operatory logiczne pozwalają łączyć lub odwracać wartości `bool`:

| Operator | Nazwa | Wynik jest `true`, gdy… |
|---|---|---|
| `&&` | i | oba warunki są prawdziwe |
| `||` | lub | przynajmniej jeden warunek jest prawdziwy |
| `!` | negacja | podana wartość była fałszywa |

```csharp
bool maKlucz = true;
bool maLatarnie = false;

bool mozeWejscDoLochu = maKlucz && maLatarnie;
bool maJakiesWyposazenie = maKlucz || maLatarnie;
bool nieMaLatarni = !maLatarnie;

Console.WriteLine(mozeWejscDoLochu);    // False
Console.WriteLine(maJakiesWyposazenie); // True
Console.WriteLine(nieMaLatarni);        // True
```

Nawiasy pomagają jednoznacznie pokazać sens złożonego wyrażenia:

```csharp
bool gotowy = (punktyZycia > 0) && (maKlucz || maLatarnie);
```

Na następnym wykładzie użyjemy takich wyników w instrukcjach warunkowych.

---

## 8. Konwersje typów

**Konwersja** zmienia sposób reprezentowania wartości. Może odbywać się automatycznie albo wymagać jawnej decyzji programisty.

### Konwersja niejawna

Konwersja z typu o mniejszym zakresie do większego jest zwykle bezpieczna:

```csharp
int liczbaPokonanychWrogow = 12;
long lacznaLiczbaWrogow = liczbaPokonanychWrogow;
double wynik = liczbaPokonanychWrogow;
```

Nie trzeba dopisywać żadnego operatora, ponieważ wartość `int` mieści się w `long` i może zostać przedstawiona jako `double`.

### Rzutowanie jawne

Konwersja w drugą stronę może utracić część danych, dlatego wymaga zapisu typu w nawiasach:

```csharp
double odleglosc = 12.8;
int pelneKilometry = (int)odleglosc;

Console.WriteLine(pelneKilometry); // 12
```

Rzutowanie do `int` odrzuca część ułamkową — nie zaokrągla wyniku.

```csharp
double temperatura = -2.9;
int caleStopnie = (int)temperatura;
Console.WriteLine(caleStopnie); // -2
```

Do zaokrąglania służą osobne operacje, na przykład `Math.Round`:

```csharp
double srednia = 4.6;
double zaokraglona = Math.Round(srednia);
Console.WriteLine(zaokraglona); // 5
```

### Tekst a liczba

Tekstu nie można przekształcić w liczbę przez zwykłe rzutowanie. Korzystamy z `Parse`:

```csharp
string tekst = "125";
int punkty = int.Parse(tekst);

double dystans = double.Parse("12,5");
decimal cena = decimal.Parse("19,99");
bool maKlucz = bool.Parse("true");
```

Zapis liczby dziesiętnej wczytywanej z tekstu zależy od ustawień regionalnych systemu. W polskiej konfiguracji separatorem jest zwykle przecinek. `bool.Parse` przyjmuje tekst `"true"` albo `"false"` bez względu na wielkość liter.

W drugą stronę każdą wartość można przedstawić jako tekst metodą `ToString` albo przez interpolację:

```csharp
int poziom = 4;
string tekstPoziomu = poziom.ToString();
string komunikat = $"Poziom: {poziom}";
```

> **Ważne:** `Parse` zakończy program błędem, jeżeli tekst nie przedstawia oczekiwanej liczby. Bezpieczne reagowanie na błędne dane poznamy po wprowadzeniu instrukcji warunkowych.

### Pułapka przy obliczaniu średniej

Samo przypisanie wyniku do `double` nie cofnie wcześniej wykonanego dzielenia całkowitego:

```csharp
int sumaPunktow = 7;
int liczbaGier = 2;

double zlaSrednia = sumaPunktow / liczbaGier;           // 3
double dobraSrednia = (double)sumaPunktow / liczbaGier; // 3,5
```

Rzutowanie jednego argumentu przed dzieleniem powoduje wykonanie dzielenia zmiennoprzecinkowego.

---

## 9. Formatowanie wyników

W interpolowanym napisie możemy określić sposób wyświetlania liczby:

```csharp
double srednia = 12.34567;
decimal cena = 19.9m;

Console.WriteLine($"Średnia: {srednia:F2}"); // dwa miejsca po przecinku
Console.WriteLine($"Cena: {cena:F2} zł");    // 19,90 zł
```

Formatowanie zmienia wygląd wyniku, ale nie wartość przechowywaną w zmiennej.

> **Minićwiczenie:** Dla `7` zdobytych punktów w `3` grach oblicz średnią jako `double` i wyświetl ją z dwoma miejscami po przecinku.

---

## 10. Przykład łączący zagadnienia

```csharp
Console.Write("Podaj imię bohatera: ");
string imie = Console.ReadLine()!;

Console.Write("Podaj punkty życia: ");
int punktyZycia = int.Parse(Console.ReadLine()!);

Console.Write("Podaj siłę: ");
int sila = int.Parse(Console.ReadLine()!);

Console.Write("Podaj premię broni: ");
int premiaBroni = int.Parse(Console.ReadLine()!);

int obrazenia = sila + premiaBroni;
double srednieObrazenia = obrazenia / 2.0;
bool zyje = punktyZycia > 0;

Console.WriteLine();
Console.WriteLine("=== RAPORT BOHATERA ===");
Console.WriteLine($"Imię: {imie}");
Console.WriteLine($"Punkty życia: {punktyZycia}");
Console.WriteLine($"Obrażenia: {obrazenia}");
Console.WriteLine($"Połowa obrażeń: {srednieObrazenia:F2}");
Console.WriteLine($"Bohater żyje: {zyje}");
```

Program pobiera dane, konwertuje tekst na liczby, wykonuje działania arytmetyczne i porównanie, a na końcu formatuje raport.

---

## Podsumowanie

- zmienna ma typ, nazwę i wartość, którą można zmieniać,
- `const` oznacza wartość, której nie można ponownie przypisać,
- `var` prosi kompilator o wywnioskowanie typu z wartości początkowej,
- `int` i `long` przechowują liczby całkowite, `double` wartości przybliżone, a `decimal` dobrze nadaje się do pieniędzy,
- dzielenie dwóch liczb całkowitych daje wynik całkowity,
- operator `%` zwraca resztę z dzielenia,
- operatory `+=`, `-=`, `*=`, `/=` i `%=` skracają aktualizowanie zmiennej,
- porównania tworzą wartości typu `bool`, które można łączyć operatorami `&&`, `||` i `!`,
- bezpieczna konwersja może być niejawna, a konwersja grożąca utratą danych wymaga rzutowania,
- `Parse` zamienia poprawnie zapisany tekst na liczbę,
- rzutowanie do `int` odrzuca część ułamkową, a nie zaokrągla.

## Ściąga

```csharp
// Zmienne, wnioskowanie typu i stałe
int punkty = 10;
var imie = "Aria";          // string
const int Maksimum = 100;

// Arytmetyka
int suma = 7 + 3;
int iloraz = 7 / 3;         // 2
int reszta = 7 % 3;         // 1
double dokladny = 7.0 / 3;  // 2,333...

// Aktualizacja wartości
punkty += 5;
punkty--;

// Wartości logiczne
bool dodatnie = punkty > 0;
bool wZakresie = (punkty >= 0) && (punkty <= Maksimum);
bool pozaZakresem = !wZakresie;

// Konwersje
double szerokosc = 12;                 // niejawna
int pelnaSzerokosc = (int)szerokosc;   // jawna
int liczba = int.Parse("42");
string tekst = liczba.ToString();

// Formatowanie
Console.WriteLine($"Wynik: {dokladny:F2}");
```

---
