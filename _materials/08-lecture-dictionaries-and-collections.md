---
layout: material
title: "Słowniki i przetwarzanie kolekcji"
kind: lecture
week: 8
summary: "Słowniki, pary klucz–wartość oraz wyszukiwanie, zliczanie i filtrowanie danych w kolekcjach."
published: false
content_ready: false
---

## Cel wykładu

Indeks liczbowy nie zawsze dobrze opisuje dane. Słownik pozwala odszukać wartość za pomocą znaczącego klucza, np. nazwy przedmiotu, symbolu pola albo identyfikatora statystyki.

## Zakres wykładu — 90 minut

| Część | Czas |
|---|---:|
| Model klucz–wartość | 10 min |
| Tworzenie i modyfikacja słownika | 20 min |
| `ContainsKey` i `TryGetValue` | 15 min |
| Iterowanie po parach | 10 min |
| Zliczanie i ręczne filtrowanie | 15 min |
| Tablica, lista czy słownik | 15 min |
| Podsumowanie | 5 min |

## Zagadnienia do rozwinięcia

- `Dictionary<TKey, TValue>` i unikalne klucze,
- dodawanie, odczyt i aktualizacja,
- bezpieczny odczyt brakującego klucza,
- `KeyValuePair` w pętli `foreach`,
- słownik jako tabela właściwości przedmiotów,
- zliczanie wystąpień,
- ręczne budowanie przefiltrowanej listy.

> **Granica materiału:** kolekcje przetwarzamy pętlami; LINQ pozostaje poza zakresem kursu.

## Pytania kontrolne

1. Dlaczego dwa elementy słownika nie mogą mieć identycznego klucza?
2. Kiedy użyć `TryGetValue`?
3. Dlaczego kolejność elementów nie powinna być głównym powodem wyboru słownika?

