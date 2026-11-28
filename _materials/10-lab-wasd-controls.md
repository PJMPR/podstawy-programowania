---
layout: material
title: "Laboratorium 10 — refaktoryzacja do kodu obiektowego"
kind: lab
week: 10
summary: "Refaktoryzacja działającego DungeonRidera z Lab09 do klas, obiektów, metod i konstruktorów."
published: true
content_ready: true
---

<aside class="material-callout callout-note">
<strong>Kod startowy</strong>
<p>Kod startowy do laboratorium zostanie dostarczony przez assignment na platformie <code>classroom50.ord</code>. Otwórz udostępnione zadanie, zaakceptuj je i pracuj we własnym repozytorium utworzonym przez platformę.</p>
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

# Część 1. Punkt wyjścia — rozwiązanie Lab09

## Starter

Starter znajduje się w `examples/10-dungeon-rider-starter`. Jest to **gotowe,
działające rozwiązanie Lab09**, przemianowane na `DungeonRider`. Nie zawiera luk `TODO`.

```powershell
cd .\examples\10-dungeon-rider-starter
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
    if (width < 3 || height < 3)
        throw new ArgumentException("Mapa musi mieć co najmniej 3 × 3 pola.");

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
    EnsureInside(x, y);
    return fields[y, x];
}

public void SetField(int x, int y, char symbol)
{
    EnsureInside(x, y);
    fields[y, x] = symbol;
}

private void EnsureInside(int x, int y)
{
    if (!IsInside(x, y))
        throw new ArgumentOutOfRangeException($"Pole ({x}, {y}) leży poza mapą.");
}
```

> **Maciej:** Publiczna tablica byłaby krótsza.
>
> **Jan:** Krótsza przy pierwszym zapisie, droższa przy każdym błędzie. Teraz wszystkie odczyty i zapisy przechodzą przez jedną kontrolowaną drogę.

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
        if (!map.IsWalkable(player.X, player.Y))
            throw new ArgumentException("Gracz musi rozpocząć na dostępnym polu.");

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

Dodaj do `Player` imię przekazywane przez konstruktor. Imię nie może być puste ani składać
się wyłącznie z białych znaków. Renderer ma wyświetlać je pod mapą.

### Kryteria ukończenia

- [ ] `Name` można odczytać, ale nie zmienić po utworzeniu gracza.
- [ ] Konstruktor odrzuca puste imię czytelnym wyjątkiem.
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
