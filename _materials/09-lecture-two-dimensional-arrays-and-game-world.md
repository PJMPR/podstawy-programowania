---
layout: material
title: "Tablice dwuwymiarowe i reprezentacja świata gry"
kind: lecture
week: 9
summary: "Tablice 2D, współrzędne, pętle zagnieżdżone oraz tworzenie i wyświetlanie planszy."
published: false
content_ready: false
---

## Cel wykładu

Tablica dwuwymiarowa pozwala opisać planszę jako wiersze i kolumny. Tematem nie jest sama składnia `[,]`, lecz przełożenie danych na działający model świata gry.

## Zakres wykładu — 90 minut

| Część | Czas |
|---|---:|
| Od tablicy 1D do planszy | 10 min |
| Deklarowanie i indeksowanie `char[,]` | 15 min |
| `GetLength` i pętle zagnieżdżone | 15 min |
| Wiersz/kolumna a `x/y` | 15 min |
| Mapa z symboli i renderowanie | 20 min |
| Modyfikowanie pól i kontrola granic | 10 min |
| Podsumowanie | 5 min |

## Zagadnienia do rozwinięcia

- inicjalizowanie tablicy 2D,
- różnica między długością całej tablicy i wymiaru,
- konwencja `mapa[y, x]`,
- symbole podłogi, ściany, wyjścia i przedmiotu,
- generowanie ścian na krawędziach,
- renderowanie zagnieżdżonymi pętlami,
- rozdzielenie mapy od pozycji gracza,
- sprawdzanie granic przed odczytem pola.

## Pytania kontrolne

1. Co zwracają `GetLength(0)` i `GetLength(1)`?
2. Dlaczego jedna pętla nie wystarcza do przejścia po wierszach i kolumnach?
3. Jak sprawdzić współrzędne przed użyciem ich jako indeksów?

