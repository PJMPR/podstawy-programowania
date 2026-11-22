# Pierwsza mapa lochu — starter

Kompilowalna baza dla studentów do laboratorium 09. Solucja zawiera aplikację konsolową i bibliotekę logiki mapy. Miejsca wymagające implementacji oznaczono komentarzem `TODO`.

```text
FirstDungeonMap.Starter.slnx
├── FirstDungeonMap.App  — menu, konsola i renderowanie
└── FirstDungeonMap.Core — tworzenie i analiza mapy
```

```powershell
dotnet build .\examples\09-first-dungeon-map-starter\FirstDungeonMap.Starter.slnx
dotnet run --project .\examples\09-first-dungeon-map-starter\FirstDungeonMap.App\FirstDungeonMap.App.csproj
```

Zachowuj konwencję `map[y, x]`: `y` oznacza wiersz, a `x` kolumnę. Nie dodawaj obsługi konsoli do `Core` i nie dodawaj zależności `Core → App`.
