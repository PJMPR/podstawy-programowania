---
layout: material
title: "Porządkowanie gry za pomocą metod"
kind: lab
week: 6
summary: "Dzielimy rosnący program na małe metody z parametrami i wartościami zwracanymi."
published: false
content_ready: false
---

## Cel laboratorium

Uporządkuj kod gry bez zmiany jej zachowania. Ćwicz zwykłe parametry, wartości zwracane i zasięg zmiennych.

## Zadania

1. Napisz `ShowStatus(string name, int health, int gold)` i `ShowMenu()`.
2. Napisz `ReadCommand()`, która ponawia pytanie aż otrzyma dozwoloną komendę.
3. Napisz metody `CalculateDamage`, `Heal` oraz `IsGameOver` i sprawdź je dla wartości granicznych.
4. Wydziel wyświetlanie ekwipunku i historii akcji.
5. Zrefaktoryzuj projekt z tygodnia 5 tak, aby główna pętla przedstawiała ogólny przebieg gry.

> Nie używaj `ref`, `out`, delegatów ani zmiennych globalnych jako sposobu przekazywania każdego wyniku.

## Kryteria ukończenia

- [ ] Program zawiera metody `void` i metody zwracające wartość.
- [ ] Parametry mają odpowiednie typy i czytelne nazwy.
- [ ] Logika obliczeń nie wymaga bezpośredniego odczytu z konsoli.
- [ ] Po refaktoryzacji zachowanie gry pozostało poprawne.

