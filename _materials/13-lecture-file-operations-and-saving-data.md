---
layout: material
title: "Operacje na plikach i zapisywanie danych"
kind: lecture
week: 13
summary: "Pliki tekstowe, ścieżki, format zapisu oraz odtwarzanie stanu gry."
published: false
content_ready: false
---

## Cel wykładu

Dane w pamięci znikają po zakończeniu programu. Nauczymy się zapisywać minimalny stan gry w czytelnym formacie tekstowym i bezpiecznie go odtwarzać.

## Zakres wykładu — 90 minut

| Część | Czas |
|---|---:|
| Trwałość danych | 10 min |
| Odczyt i zapis tekstu | 15 min |
| Ścieżki i istnienie pliku | 10 min |
| Projekt formatu zapisu | 20 min |
| Odtwarzanie stanu | 20 min |
| Niepełne i niepoprawne dane | 10 min |
| Podsumowanie | 5 min |

## Zagadnienia do rozwinięcia

- `File.WriteAllText`, `ReadAllText`, `WriteAllLines` i `ReadAllLines`,
- ścieżki względne,
- `File.Exists`,
- wersja formatu zapisu,
- zamiana liczb i współrzędnych na tekst,
- odtwarzanie wszystkich danych przed zmianą bieżącego stanu,
- zapis mapy w kolejnych wierszach,
- komunikat dla braku albo wadliwego pliku.

> Pełną konstrukcję `try-catch` omawiamy w następnym tygodniu; tutaj preferujemy sprawdzanie przewidywalnych warunków i `TryParse`.

