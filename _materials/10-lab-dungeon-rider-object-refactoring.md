---
layout: material
title: "Laboratorium 10 — DungeonRider: refaktoryzacja obiektowa"
kind: lab
week: 10
summary: "Przekształcenie rozwiązania Lab09 w DungeonRider oparty na klasach, obiektach, metodach i konstruktorach."
published: true
content_ready: true
---

<aside class="material-callout callout-note">
<strong>Kod startowy</strong>
<p>Kod startowy do laboratorium zostanie przekazany przez prowadzącego w ramach assignmentu na platformie <code>classroom50.org</code>. Otwórz udostępnione zadanie, zaakceptuj je i pracuj we własnym repozytorium utworzonym przez platformę.</p>
</aside>

## Cel laboratorium

Kod z Lab09 działa, ale stan gry jest rozproszony między tablicą `char[,]`, zmiennymi
`playerX`, `playerY` i metodami statycznymi. Nie tworzymy gry od nowa. Zachowujemy jej
zachowanie i **refaktoryzujemy** kod tak, aby mapa, gracz i rozgrywka stały się
współpracującymi obiektami.

```text
działający kod z Lab09 → klasy → konstruktory → obiekty → hermetyzacja → współpraca obiektów
```

Po laboratorium potrafisz rozpoznać dane i zachowania jednego obiektu, utworzyć klasę,
konstruktor i obiekt, zastąpić luźne zmienne właściwościami, przenieść metody statyczne
do właściwych obiektów oraz ukryć szczegóły implementacji.

<aside class="material-callout callout-note">
<strong>Refaktoryzacja</strong>
<p>To zmiana budowy kodu bez celowej zmiany jego dotychczasowego zachowania. Po każdym kroku projekt powinien się kompilować i wyświetlać tę samą mapę.</p>
</aside>

---

# Wprowadzenie teoretyczne — co oznacza `static`?

Zanim rozpoczniemy refaktoryzację, trzeba zrozumieć słowo kluczowe `static`, które pojawia
się w rozwiązaniu Lab09. `static` oznacza, że dany element **należy do klasy jako całości,
a nie do konkretnego obiektu tej klasy**.

## Metoda statyczna

W starterze `MapRenderer.Print` jest metodą statyczną:

```csharp
public static class MapRenderer
{
    public static void Print(char[,] map, int playerX, int playerY)
    {
        // Wyświetlanie mapy.
    }
}
```

Do jej wywołania nie tworzymy obiektu `MapRenderer`. Używamy nazwy klasy:

```csharp
MapRenderer.Print(map, playerX, playerY);
```

Ogólny zapis wywołania metody statycznej wygląda tak:

```text
NazwaKlasy.NazwaMetody(argumenty)
```

Metoda statyczna nie jest przypisana do konkretnego obiektu. Dlatego wszystkie dane,
których potrzebuje, zazwyczaj otrzymuje jako parametry. `Print` otrzymuje mapę oraz dwie
współrzędne gracza, ponieważ sam `MapRenderer` ich nie przechowuje.

## Klasa statyczna

Jeżeli cała klasa jest oznaczona jako `static`, nie można utworzyć jej obiektu za pomocą
`new`:

```csharp
public static class DungeonMap
{
    public static bool IsInside(char[,] map, int x, int y)
    {
        return x >= 0 && x < map.GetLength(1) &&
               y >= 0 && y < map.GetLength(0);
    }
}
```

Poprawne użycie:

```csharp
bool result = DungeonMap.IsInside(map, 2, 3);
```

Tego zapisu nie można użyć:

```csharp
// DungeonMap dungeonMap = new DungeonMap();
```

Klasa statyczna jest więc zbiorem metod dostępnych przez nazwę klasy. W Lab09 było to
wygodne, ale klasa nie reprezentowała konkretnej mapy — właściwe dane nadal znajdowały
się w osobnej tablicy `char[,]`.

## Pole statyczne

`static` można zastosować również do pola:

```csharp
public class GameStatistics
{
    public static int StartedGames = 0;
}
```

Do pola odwołujemy się przez nazwę klasy:

```csharp
GameStatistics.StartedGames++;
Console.WriteLine(GameStatistics.StartedGames);
```

Istnieje tylko jedna wspólna wartość `StartedGames`, niezależnie od liczby utworzonych
obiektów `GameStatistics`. Pola statyczne nie nadają się więc do przechowywania stanu
konkretnego gracza albo konkretnej mapy — różni gracze i różne mapy powinni mieć własne
dane.

## Element statyczny a obiekt

Porównaj dwa sposoby sprawdzania pola mapy.

Wersja statyczna z Lab09:

```csharp
char[,] map = DungeonMap.Create(12, 7);
bool canEnter = DungeonMap.IsWalkable(map, 2, 2);
```

Tablicę trzeba przekazać do metody, ponieważ klasa statyczna nie przechowuje konkretnej
mapy.

Wersja obiektowa, do której dojdziemy podczas tego laboratorium:

```csharp
DungeonMap map = new DungeonMap(12, 7);
bool canEnter = map.IsWalkable(2, 2);
```

Tutaj `map` jest obiektem i przechowuje własne pola. Metoda `IsWalkable` nie jest
statyczna — działa na danych tego konkretnego obiektu.

| Pytanie | Element statyczny | Element obiektu |
|---|---|---|
| Do czego należy? | do klasy | do konkretnego obiektu |
| Jak go wywołujemy? | `NazwaKlasy.Metoda()` | `obiekt.Metoda()` |
| Czy potrzebujemy `new`? | nie | tak, aby utworzyć obiekt |
| Gdzie są dane? | wspólne albo przekazywane jako parametry | wewnątrz konkretnego obiektu |
| Przykład | `DungeonMap.Create(...)` | `map.IsWalkable(...)` |

<aside class="material-callout callout-note">
<strong>Ważne</strong>
<p><code>static</code> nie oznacza „źle”. Metody, które nie potrzebują stanu konkretnego obiektu, mogą pozostać statyczne. W tym laboratorium usuniemy <code>static</code> tam, gdzie mapa lub gracz powinny posiadać własne dane i zachowania.</p>
</aside>

## Krótkie sprawdzenie

1. Czy do wywołania metody statycznej potrzebny jest obiekt?
2. Dlaczego statyczna metoda `IsWalkable` otrzymuje tablicę jako parametr?
3. Czy dwóch graczy powinno współdzielić statyczne pola `X` i `Y`?
4. Czym różnią się wywołania `DungeonMap.IsWalkable(...)` i `map.IsWalkable(...)`?
5. Które metody mogą pozostać statyczne, jeśli nie korzystają ze stanu obiektu?

---

# Część 1. Punkt wyjścia — rozwiązanie Lab09

## Starter

Kod startowy zostanie przekazany przez prowadzącego za pomocą assignmentu na platformie
`classroom50.org`. Po zaakceptowaniu zadania otrzymasz własne repozytorium zawierające
**gotowe, działające rozwiązanie Lab09**, przemianowane na `DungeonRider`.

Po sklonowaniu otrzymanego repozytorium przejdź do jego katalogu głównego i uruchom:

```powershell
dotnet build .\src\DungeonRider\DungeonRider.slnx
dotnet run --project .\src\DungeonRider\DungeonRider.App\DungeonRider.App.csproj
```

```text
DungeonRider/
└── src/
    └── DungeonRider/
        ├── DungeonRider.slnx
        ├── DungeonRider.App/
        │   ├── Program.cs
        │   └── UI/MapRenderer.cs
        └── DungeonRider.Core/
            └── Maps/DungeonMap.cs
```

Mapa jest tablicą przekazywaną do statycznych metod:

```csharp
char[,] map = DungeonMap.CreateSample();
int playerX = 2;
int playerY = 2;

MapRenderer.Print(map, playerX, playerY);
Console.WriteLine(DungeonMap.CountSymbol(map, '$'));
```

`DungeonMap` nie reprezentuje jeszcze konkretnej mapy. Jest pojemnikiem na operacje,
a tablicę trzeba przekazywać do każdej z nich:

```csharp
public static bool IsWalkable(char[,] map, int x, int y)
{
    return IsInside(map, x, y) && map[y, x] != '#';
}
```

Kod jest poprawny, lecz dane jednego pojęcia są rozdzielone. Celem nie jest usunięcie
tablicy, ale ukrycie jej wewnątrz obiektu, który będzie pilnował własnych reguł.

### Analiza przed zmianami

1. Które dane opisują mapę?
2. Które dane opisują gracza?
3. Które metody potrzebują tablicy `map`?
4. Dlaczego `playerX` i `playerY` powinny zawsze zmieniać się razem?

---

# Część 2. Refaktoryzacja krok po kroku

## Krok 1. `DungeonMap` staje się klasą obiektów

> **Maciej:** Przecież już mamy klasę `DungeonMap`. Co tu zmieniać?
>
> **Jan:** Mamy klasę statyczną, ale nie mamy obiektu mapy. Każda metoda nadal prosi o tablicę. Niech konkretny obiekt przechowuje własne pola.

```csharp
public class DungeonMap
{
    private readonly char[,] fields;
}
```

`private` chroni tablicę przed dowolną zmianą spoza klasy. `readonly` oznacza, że po
utworzeniu obiektu pole nie zacznie wskazywać innej tablicy.

## Krok 2. Konstruktor tworzy poprawny obiekt

> **Maciej:** Najpierw utworzę pusty obiekt, a potem osobno ustawię szerokość, wysokość i tablicę.
>
> **Jan:** Wtedy przez chwilę istnieje niepoprawna mapa. Konstruktor powinien od razu przygotować obiekt gotowy do użycia.

```csharp
public int Width => fields.GetLength(1);
public int Height => fields.GetLength(0);

public DungeonMap(int width, int height)
{
    width = Math.Max(width, 3);
    height = Math.Max(height, 3);

    fields = new char[height, width];

    for (int y = 0; y < Height; y++)
    for (int x = 0; x < Width; x++)
        fields[y, x] = IsEdge(x, y) ? '#' : '.';
}
```

```csharp
DungeonMap map = new DungeonMap(12, 7);
```

Konstruktor ma nazwę klasy, nie podaje typu zwracanego i wykonuje się przy `new`.
`Math.Max` pilnuje tutaj minimalnego rozmiaru bez przerywania programu: dla wartości
mniejszej niż `3` zostanie użyte `3`.

## Krok 3. Metody pracują na stanie obiektu

> **Maciej:** Zostawię parametr `char[,] map`, bo wcześniej działał.
>
> **Jan:** Metoda obiektu zna już swoje `fields`. Parametr byłby dwiema odpowiedziami na pytanie „którą mapę sprawdzamy?”.

```csharp
public bool IsInside(int x, int y)
{
    return x >= 0 && x < Width && y >= 0 && y < Height;
}

public bool IsWalkable(int x, int y)
{
    return IsInside(x, y) && fields[y, x] != '#';
}
```

Wywołanie zmienia się z `DungeonMap.IsWalkable(map, x, y)` na
`map.IsWalkable(x, y)`. Tak samo przenieś `CountSymbol` do `Count` oraz
`TryFindSymbol` do `TryFind`.

## Krok 4. Kontrolowany odczyt i zapis pól

```csharp
public char GetField(int x, int y)
{
    return IsInside(x, y) ? fields[y, x] : '#';
}

public void SetField(int x, int y, char symbol)
{
    if (IsInside(x, y))
        fields[y, x] = symbol;
}
```

> **Maciej:** Publiczna tablica byłaby krótsza.
>
> **Jan:** Krótsza przy pierwszym zapisie, droższa przy każdym błędzie. Teraz wszystkie odczyty i zapisy przechodzą przez jedną kontrolowaną drogę.

Przy odczycie pola spoza mapy metoda zwraca `#`, czyli pole niedostępne. Próba zapisu
poza mapą niczego nie zmienia, a program może działać dalej.

## Krok 5. Gracz jako obiekt

```csharp
public class Player
{
    public string Name { get; }
    public int X { get; private set; }
    public int Y { get; private set; }

    public Player(string name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }
}
```

```csharp
Player player = new Player("Ada", 2, 2);
```

`private set` pozwala odczytać pozycję z zewnątrz, lecz zmieniać ją tylko metodom klasy.

## Krok 6. Zachowanie gracza trafia do `Player`

> **Maciej:** W `Program` ustawię osobno `player.X` i `player.Y`.
>
> **Jan:** Właśnie temu zapobiega `private set`. Gracz ma sam sprawdzić ruch i zmienić obie współrzędne jako jedną operację.

```csharp
public bool TryMove(int dx, int dy, DungeonMap map)
{
    int nextX = X + dx;
    int nextY = Y + dy;

    if (!map.IsWalkable(nextX, nextY))
        return false;

    X = nextX;
    Y = nextY;
    return true;
}
```

`Player` odpowiada za swoją pozycję, a o regułę dostępności pyta `DungeonMap`.

## Krok 7. `DungeonGame` łączy obiekty

```csharp
public class DungeonGame
{
    public DungeonMap Map { get; }
    public Player Player { get; }

    public DungeonGame(DungeonMap map, Player player)
    {
        Map = map;
        Player = player;
    }
}
```

> **Maciej:** Czy `DungeonGame` nie jest tylko dodatkowym pudełkiem?
>
> **Jan:** Jest miejscem dla reguł całej rozgrywki. Mapa pilnuje pól, gracz pozycji, a gra ich poprawnej współpracy.

Renderer przyjmuje jeden spójny obiekt:

```csharp
public static void Print(DungeonGame game)
{
    for (int y = 0; y < game.Map.Height; y++)
    {
        for (int x = 0; x < game.Map.Width; x++)
        {
            bool isPlayer = x == game.Player.X && y == game.Player.Y;
            Console.Write(isPlayer ? '@' : game.Map.GetField(x, y));
        }
        Console.WriteLine();
    }
}
```

### Sprawdzenie refaktoryzacji

- [ ] Projekt buduje się po każdym kroku.
- [ ] Mapa ma te same wymiary i symbole co wcześniej.
- [ ] `char[,]` jest prywatnym szczegółem `DungeonMap`.
- [ ] Nie istnieją luźne zmienne `playerX` i `playerY`.
- [ ] Nie przekazujesz tablicy do metod mapy.
- [ ] Pozycji gracza nie można zmienić poza `Player`.
- [ ] `Program` tworzy obiekty, ale nie przejmuje ich odpowiedzialności.

---

# Część 3. Zadania do samodzielnego wykonania

Wykonuj je na zrefaktoryzowanym kodzie. Wersja dla prowadzącego znajduje się w
`examples/10-dungeon-rider-solution`.

## Zadanie 1 — łatwe: imię gracza

Dodaj do `Player` imię przekazywane przez konstruktor. Jeśli przekazane imię jest puste
albo składa się wyłącznie z białych znaków, użyj wartości `"Gracz"`. Renderer ma
wyświetlać imię pod mapą.

### Kryteria ukończenia

- [ ] `Name` można odczytać, ale nie zmienić po utworzeniu gracza.
- [ ] Dla pustego imienia konstruktor ustawia wartość `"Gracz"`.
- [ ] `Program` tworzy gracza z imieniem.
- [ ] Renderer nie otrzymuje osobnego parametru `string`.

## Zadanie 2 — średnie: bezpieczny ruch

Dodaj `Player.TryMove(int dx, int dy, DungeonMap map)`. Metoda oblicza proponowaną
pozycję, pyta mapę o dostępność i zmienia `X` oraz `Y` tylko dla poprawnego ruchu.
W `Program` obsłuż `W`, `A`, `S`, `D` oraz wyjście klawiszem `Q`.

### Kryteria ukończenia

- [ ] Gracz nie wychodzi poza mapę i nie przechodzi przez `#`.
- [ ] Zablokowany ruch nie zmienia żadnej współrzędnej.
- [ ] Sterowanie nie odczytuje prywatnej tablicy mapy.
- [ ] `Q` kończy program.
- [ ] Odpowiedzialność za zmianę pozycji pozostaje w `Player`.

## Zadanie 3 — trudniejsze: skarby i koniec gry

Dodaj do `Player` licznik `CollectedTreasures`. Po poprawnym wejściu na `$` gracz zwiększa
licznik, a mapa zamienia pole na `.`. Ponowne odwiedzenie pola nie daje punktu. Dodaj do
`DungeonGame` właściwość `IsFinished`, która zwraca `true`, gdy gracz stoi na wyjściu `>`.

### Kryteria ukończenia

- [ ] Licznika nie można ustawić spoza `Player`.
- [ ] Skarb jest zbierany dopiero po poprawnym ruchu.
- [ ] Jedno pole zwiększa licznik najwyżej raz.
- [ ] Mapa odpowiada za zmianę własnego pola.
- [ ] Wejście na `>` kończy pętlę komunikatem zwycięstwa.
- [ ] Renderer pokazuje aktualny licznik.

## Pytania kontrolne

1. Czym różni się klasa od obiektu tej klasy?
2. Po co obiektowi konstruktor?
3. Dlaczego tablica `fields` jest `private`?
4. Kiedy metoda powinna być metodą obiektu, a nie `static`?
5. Co daje `private set` przy `X` i `Y`?
6. Dlaczego `TryMove` zmienia obie współrzędne dopiero po walidacji?
7. Za co odpowiada `DungeonMap`, za co `Player`, a za co `DungeonGame`?
8. Po czym poznasz, że refaktoryzacja nie zmieniła wcześniejszego zachowania?

## Co oddać

- zrefaktoryzowaną solucję `DungeonRider`,
- klasy `DungeonMap`, `Player` i `DungeonGame`,
- rozwiązania trzech zadań,
- działającą pętlę demonstracyjną,
- krótką odpowiedź: „Która zmiana najbardziej ograniczyła możliwość utworzenia niepoprawnego stanu i dlaczego?”.

## Podsumowanie

Zaczęliśmy od poprawnego kodu proceduralnego. Tablica nadal istnieje, lecz stała się
szczegółem obiektu mapy. Współrzędne nadal są liczbami, lecz należą do gracza i są
zmieniane przez jego metodę. Klasy nadają danym właścicieli i skupiają reguły w miejscach,
które potrafią ich pilnować.
