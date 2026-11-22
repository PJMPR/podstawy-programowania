# Pierwsza mapa lochu — rozwiązanie prowadzącego

Przykładowe kompletne rozwiązanie siedmiu zadań z laboratorium 09. Solucja rozdziela logikę mapy od konsolowej prezentacji.

```text
FirstDungeonMap.Solution.slnx
├── FirstDungeonMap.App  — FirstDungeonMap.App i FirstDungeonMap.App.UI
└── FirstDungeonMap.Core — FirstDungeonMap.Core.Maps
```

```powershell
dotnet build .\examples\09-first-dungeon-map-solution\FirstDungeonMap.Solution.slnx
dotnet run --project .\examples\09-first-dungeon-map-solution\FirstDungeonMap.App\FirstDungeonMap.App.csproj
```

Rozwiązanie pokazuje jeden poprawny wariant. Inne implementacje są prawidłowe, jeśli zachowują konwencję `map[y, x]`, bezpiecznie sprawdzają granice i oddzielają dane mapy od pozycji gracza.
