# RogueSemesterGame

Przykładowy efekt końcowy kursu podstaw programowania w C#. Jest to kompletna, ale celowo niewielka gra konsolowa typu roguelike.

## Uruchomienie

W katalogu projektu wykonaj:

    dotnet run

## Sterowanie

- `W`, `A`, `S`, `D` — ruch,
- `E` — użycie mikstury,
- `P` — zapis do `savegame.txt`,
- `Q` — powrót do menu.

## Zakres gry

- menu, instrukcja i zakończenie programu,
- dwie mapy zapisane jako `char[,]`,
- ściany, przedmioty, przeciwnicy i wyjście,
- turowa walka z losowymi obrażeniami,
- ekwipunek oparty na `List<string>`,
- proste klasy `Player` i `Enemy`,
- stany menu, gry, zwycięstwa i porażki,
- tekstowy zapis i wczytywanie pełnego stanu.

## Powiązanie z programem kursu

| Element kodu | Temat kursu |
|---|---|
| zmienne, operatory i konwersje | tygodnie 1–2 |
| `if`, `else`, pętla gry | tygodnie 3–4 |
| tablice, listy i ręczne zliczanie | tydzień 5 |
| podział programu na metody | tydzień 6 |
| `Random` i mechanika walki | tydzień 7 |
| słownik legendy | tydzień 8 |
| mapa `char[,]` | tydzień 9 |
| WASD, granice i kolizje | tydzień 10 |
| klasy `Player` i `Enemy` | tydzień 11 |
| `enum GameState` i poziomy | tydzień 12 |
| `File`, format zapisu i odczyt | tydzień 13 |
| walidacja, `TryParse` i `try-catch` | tydzień 14 |
| integracja i refaktoryzacja | tydzień 15 |

## Świadome ograniczenia

Kod nie używa LINQ, dziedziczenia, interfejsów, delegatów, zdarzeń, programowania asynchronicznego, zewnętrznych pakietów ani silnika gry. Nie są one potrzebne do osiągnięcia celów tego kursu.
