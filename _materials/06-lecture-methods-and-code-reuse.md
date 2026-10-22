---
layout: material
title: "Metody — organizacja i ponowne wykorzystanie kodu"
kind: lecture
week: 6
summary: "Definiowanie metod, parametry, wartości zwracane, zasięg zmiennych i podział programu na mniejsze części."
published: false
content_ready: false
---

## Cel wykładu

Rosnący program trudno rozwijać jako jeden długi blok. Metody pozwalają nazwać operacje, ograniczyć powtórzenia i rozdzielić większy problem na mniejsze kroki.

Po wykładzie potrafisz definiować i wywoływać metody `void`, przekazywać argumenty, zwracać wyniki, rozpoznawać zasięg zmiennej i dzielić kod gry według odpowiedzialności.

## Zakres wykładu — 90 minut

| Część | Czas |
|---|---:|
| Po co wydzielać metody | 10 min |
| Definicja, wywołanie i `void` | 15 min |
| Parametry i argumenty | 15 min |
| Typ wyniku oraz `return` | 15 min |
| Zasięg i przepływ danych | 15 min |
| Refaktoryzacja fragmentu gry | 15 min |
| Podsumowanie | 5 min |

## Zagadnienia do rozwinięcia

- sygnatura metody i kolejność wykonania,
- różnica między parametrem i argumentem,
- metody wykonujące działanie i obliczające wynik,
- wczesny `return`,
- zmienne lokalne i zasięg blokowy,
- dobre nazwy oraz jedna odpowiedzialność,
- oddzielenie logiki gry od wejścia i wyjścia konsolowego.

> **Granica materiału:** nie wprowadzamy `ref`, `out`, delegatów, callbacków ani lambd.

## Przykład przewodni

Jednolity blok pętli gry zostaje podzielony na `ShowStatus`, `ShowMenu`, `ReadCommand`, `CalculateDamage`, `Heal` i `IsGameOver`.

## Pytania kontrolne

1. Czym różni się metoda `void` od metody zwracającej `int`?
2. Czy zmienna lokalna metody istnieje po jej zakończeniu?
3. Dlaczego metoda licząca obrażenia nie musi niczego wypisywać?

