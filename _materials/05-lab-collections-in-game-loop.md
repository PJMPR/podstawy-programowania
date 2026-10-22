---
layout: material
title: "Kolekcje w pętli gry"
kind: lab
week: 5
summary: "Dodajemy do istniejącej pętli gry tablice danych, listę przedmiotów i historię akcji."
published: false
content_ready: false
---

## Cel laboratorium

Ćwiczymy tablice i listy bez wyprzedzania dalszych tematów. Projekt z tygodnia 4 nadal działa w pętli, ale od teraz może przechowywać wiele przedmiotów, wyników i komunikatów.

> **Ważne:** nie używaj jeszcze własnych metod, słowników, LINQ ani tablic 2D.

## Zadania

### 1. Statystyki wyprawy

Utwórz tablicę zawierającą ilość złota zdobytego w kolejnych turach. Wyświetl wszystkie wartości, sumę, wartość największą i numer pierwszej tury, w której ją uzyskano.

### 2. Lista przedmiotów

Utwórz `List<string>` z początkowym wyposażeniem. Pozwól graczowi wyświetlić przedmioty z numerami, dodać znaleziony przedmiot, sprawdzić, czy posiada miksturę, oraz usunąć przedmiot wskazany poprawnym indeksem.

### 3. Bezpieczny wybór przeciwnika

Utwórz tablicę co najmniej czterech nazw przeciwników. Pobierz od użytkownika numer i bezpiecznie wyświetl odpowiedni element. Nie używaj jeszcze `Random`.

### 4. Historia akcji

Rozbuduj menu z poprzedniego tygodnia o `List<string> historia`. Po poprawnej akcji dodaj krótki opis. Nowa opcja menu ma wyświetlać historię od najstarszej do najnowszej.

### 5. Projekt — przygotowanie ekwipunku

Połącz pętlę gry z listą przedmiotów. Opcja leczenia zużywa jedną miksturę, a brak mikstury nie zmienia punktów życia. Błędny indeks i błędna komenda nie mogą zakończyć programu.

## Rozszerzenie

- ogranicz pojemność plecaka,
- policz wystąpienia wybranego przedmiotu za pomocą pętli,
- pokaż ostatnie trzy wpisy historii bez zmiany oryginalnej listy.

## Kryteria ukończenia

- [ ] Program używa co najmniej jednej tablicy i jednej listy.
- [ ] Każdy dostęp przez indeks jest poprzedzony kontrolą zakresu.
- [ ] Program samodzielnie oblicza co najmniej jedną statystykę kolekcji.
- [ ] Dodawanie i usuwanie przedmiotów działa.
- [ ] Pętla gry nadal poprawnie się kończy.

