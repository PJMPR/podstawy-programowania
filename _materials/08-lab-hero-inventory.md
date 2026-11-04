---
layout: material
title: "Przestrzenie nazw, projekty i rozwiązania"
kind: lab
week: 8
summary: "Organizujemy kod w namespace, tworzymy nowe projekty i uczymy się zarządzać pakietami NuGet."
published: false
content_ready: false
---

## Cel laboratorium

Kiedy projekt rośnie, warto go organizować w logiczne grupy. W tym laboratorium podzielisz grę na moduły, nauczysz się tworzyć namespace i pracować z pakietami.

## Zadania

1. Podziel kod gry na namespace (np. `RogueSemesterGame.Engine`, `RogueSemesterGame.UI`, `RogueSemesterGame.Combat`).
2. Utwórz nowy projekt biblioteki klasy (Class Library) dla logiki gry.
3. Przenieś klasy `Player` i `Enemy` do biblioteki.
4. Dodaj pakiet NuGet (np. `Spectre.Console` do lepszych wyników) i użyj go w projekcie.
5. Upewnij się, że główny projekt prawidłowo odwołuje się do biblioteki.

## Scenariusze testowe

- Projekt się kompiluje bez błędów.
- Gra nadal działa po podziale na moduły.
- Pakiet NuGet jest prawidłowo zainstalowany i użyty.
- Zmiana kodu w bibliotece jest widoczna w głównym projekcie.

## Kryteria ukończenia

- [ ] Kod jest zorganizowany w sensowne namespace.
- [ ] Utworzono co najmniej jeden projekt biblioteki.
- [ ] Pakiet NuGet jest poprawnie zainstalowany.
- [ ] Aplikacja kompiluje się i działa poprawnie.

## Cel laboratorium

Zastosuj listę, gdy liczba elementów się zmienia, oraz słownik, gdy wartość wyszukujemy według nazwy.

## Zadania

1. Utwórz listę przedmiotów oraz słownik opisów.
2. Dodaj słownik wartości leczenia lub cen dla znanych przedmiotów.
3. Wyświetl ekwipunek z opisami, bezpiecznie obsługując nieznaną nazwę.
4. Pozwól użyć przedmiotu: zastosuj efekt, a następnie usuń jedną sztukę.
5. Połącz łupy z tygodnia 7 z ekwipunkiem i ogranicz pojemność plecaka.
6. Za pomocą pętli policz liczbę przedmiotów każdego rodzaju.

> Nie używaj LINQ. Celem jest świadome ćwiczenie pętli, list i słowników.

## Kryteria ukończenia

- [ ] Brak klucza nie kończy programu wyjątkiem.
- [ ] Użyty przedmiot znika tylko po udanym zastosowaniu.
- [ ] Program rozróżnia listę posiadanych rzeczy od katalogu ich właściwości.
- [ ] Pełny plecak jest obsłużony czytelnym komunikatem.

