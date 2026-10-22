---
layout: material
title: "Zarządzanie stanem gry i przepływem rozgrywki"
kind: lecture
week: 12
summary: "Fazy gry, stan postaci i świata, przejścia między poziomami oraz rozpoczęcie i zakończenie rozgrywki."
published: false
content_ready: false
---

## Cel wykładu

Pętla mówi, że gra trwa, a stan gry mówi, w jakiej fazie się znajduje i jakie przejścia są teraz dozwolone.

## Zakres wykładu — 90 minut

| Część | Czas |
|---|---:|
| Dane składające się na stan gry | 10 min |
| `enum` i fazy rozgrywki | 15 min |
| Przejścia między stanami | 20 min |
| Nowa gra, reset i kolejny poziom | 15 min |
| Zwycięstwo i porażka | 10 min |
| Interfejs odzwierciedlający stan | 15 min |
| Podsumowanie | 5 min |

## Zagadnienia do rozwinięcia

- `GameState` jako skończony zbiór faz,
- menu, rozgrywka, zwycięstwo, porażka i wyjście,
- jawne warunki przejść,
- inicjalizacja oraz pełny reset,
- numer poziomu i wymiana mapy,
- dane zachowywane i zerowane między poziomami,
- ekran wynikający z bieżącego stanu.

> Automat stanów traktujemy jako praktyczny model przepływu, bez formalnej teorii automatów.

