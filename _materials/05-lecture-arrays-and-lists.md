---
layout: material
title: "Tablice i listy — przechowywanie wielu wartości"
kind: lecture
week: 5
summary: "Tablice jednowymiarowe, listy, indeksowanie, iterowanie oraz podstawowe algorytmy operujące na kolekcjach."
published: false
content_ready: false
---

## Cel wykładu

Po poznaniu pętli możemy przetwarzać wiele danych, ale nie umiemy jeszcze wygodnie przechowywać ich jako jednej całości. Na tym wykładzie poznamy tablice i listy oraz wykorzystamy je do zapisywania przedmiotów, wyników i historii akcji gracza.

Po tym wykładzie będziesz potrafić:

- utworzyć i zainicjalizować tablicę jednowymiarową,
- bezpiecznie odczytywać i zmieniać jej elementy,
- iterować za pomocą `for` i `foreach`,
- samodzielnie obliczyć sumę, minimum i maksimum,
- dodawać, wyszukiwać i usuwać elementy `List<T>`,
- wybrać tablicę albo listę odpowiednio do problemu.

## Zakres wykładu — 90 minut

| Część | Czas |
|---|---:|
| Dlaczego jedna zmienna nie wystarcza | 10 min |
| Tworzenie, indeksowanie i zmiana tablic | 15 min |
| `Length`, `for` i `foreach` | 15 min |
| Suma, minimum, maksimum i wyszukiwanie | 15 min |
| `List<T>` oraz operacje na liście | 20 min |
| Tablica czy lista, typowe błędy | 10 min |
| Podsumowanie | 5 min |

## Zagadnienia do rozwinięcia

1. Tablica jako kolekcja elementów jednego typu.
2. Indeksy od zera i zakres poprawnych indeksów.
3. Deklarowanie, inicjalizowanie, odczyt i modyfikacja.
4. Różnice między `for` i `foreach`.
5. Ręczne przetwarzanie danych bez LINQ.
6. Stały rozmiar tablicy i zmienny rozmiar listy.
7. `Count`, `Add`, `Contains`, `IndexOf`, `Remove` i `RemoveAt`.
8. Błędy `IndexOutOfRangeException` i modyfikowanie listy podczas `foreach`.

> **Granica materiału:** nie używamy jeszcze tablic dwuwymiarowych, słowników ani LINQ.

## Przykład przewodni

W trakcie wykładu powstaje prosty ekwipunek gracza oraz historia zdobytego złota. Przykład powinien pokazać tablicę o stałym rozmiarze, listę zmieniającą rozmiar i ręczne wyszukiwanie elementu.

## Pytania kontrolne

1. Jaki jest ostatni poprawny indeks tablicy o długości 5?
2. Kiedy `foreach` jest czytelniejszy od `for`?
3. Dlaczego nie można dodać elementu do istniejącej tablicy?
4. Czym różnią się `Remove` i `RemoveAt`?

