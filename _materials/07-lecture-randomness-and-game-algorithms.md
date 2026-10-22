---
layout: material
title: "Losowość i algorytmy mechanik gier"
kind: lecture
week: 7
summary: "Klasa Random, prawdopodobieństwo oraz algorytmy losowania, walki i obliczania obrażeń."
published: false
content_ready: false
---

## Cel wykładu

Losowość urozmaica rozgrywkę, ale reguły gry nadal muszą być jednoznaczne i możliwe do sprawdzenia. Poznamy `Random` i zbudujemy z małych metod pełną turę walki.

## Zakres wykładu — 90 minut

| Część | Czas |
|---|---:|
| Pseudolosowość i jeden obiekt `Random` | 10 min |
| `Next` i granice zakresu | 15 min |
| Losowanie elementów oraz zdarzeń | 15 min |
| Algorytm jednej tury walki | 20 min |
| Trafienie krytyczne, unik i balans | 15 min |
| Testowanie i typowe błędy | 10 min |
| Podsumowanie | 5 min |

## Zagadnienia do rozwinięcia

- dolna granica włącznie, górna wyłącznie,
- losowanie indeksu kolekcji,
- szansa zapisana jako czytelny warunek,
- zakres obrażeń i redukcja zdrowia,
- kolejność akcji gracza i przeciwnika,
- ograniczanie zdrowia do zera,
- powtarzalne testy części mechaniki niezależnej od losowania.

> **Ważne:** tworzymy jeden obiekt `Random` i przekazujemy go tam, gdzie jest potrzebny.

## Pytania kontrolne

1. Jakie wartości może zwrócić `random.Next(2, 6)`?
2. Jak zapisać zdarzenie o szansie 25%?
3. Dlaczego pokonany przeciwnik nie powinien wykonywać kontrataku?

