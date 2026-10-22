---
layout: material
title: "Ruch, kolizje i logika rozgrywki"
kind: lecture
week: 10
summary: "Sterowanie postacią, granice mapy, pola blokujące, interakcje i warunki zwycięstwa."
published: false
content_ready: false
---

## Cel wykładu

Statyczna mapa stanie się planszą reagującą na wejście gracza. Ruch potraktujemy jako propozycję, którą gra zatwierdza dopiero po sprawdzeniu reguł.

## Zakres wykładu — 90 minut

| Część | Czas |
|---|---:|
| `Console.ReadKey` i kierunki | 15 min |
| Aktualna i proponowana pozycja | 15 min |
| Sprawdzanie granic | 15 min |
| Kolizje ze ścianami | 15 min |
| Interakcje i zwycięstwo | 15 min |
| Pełna iteracja pętli gry | 10 min |
| Podsumowanie | 5 min |

## Zagadnienia do rozwinięcia

- mapowanie WASD na `dx` i `dy`,
- walidacja współrzędnych przed dostępem do tablicy,
- rozpoznawanie pola przechodniego,
- zatwierdzanie albo odrzucanie ruchu,
- przedmiot, drzwi i wyjście,
- kolejność: renderowanie, wejście, aktualizacja, sprawdzenie końca,
- oddzielenie wejścia, reguł i wyświetlania.

> Optymalizacja renderowania konsoli nie jest celem tego tygodnia.

