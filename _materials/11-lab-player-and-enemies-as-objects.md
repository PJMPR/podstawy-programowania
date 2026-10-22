---
layout: material
title: "Bohater i przeciwnicy jako obiekty"
kind: lab
week: 11
summary: "Przenosimy dane i zachowania bohatera oraz przeciwników do klas Player i Enemy."
published: false
content_ready: false
---

## Cel laboratorium

Uporządkuj luźne zmienne projektu, tworząc klasy `Player` i `Enemy`. Nie zmieniaj zasad gry bardziej niż to konieczne.

## Zadania

1. Utwórz klasę `Player` z właściwościami imienia, pozycji, HP, złota i ekwipunku.
2. Dodaj konstruktor ustawiający poprawny stan początkowy.
3. Dodaj metody `TakeDamage`, `Heal` i `MoveTo`.
4. Utwórz klasę `Enemy` oraz listę co najmniej dwóch obiektów.
5. Zastąp luźne zmienne obiektami w renderowaniu, ruchu i walce.
6. Sprawdź, że zmiana jednego przeciwnika nie zmienia pozostałych.

## Kryteria ukończenia

- [ ] Klasa i obiekt są używane zgodnie z ich rolą.
- [ ] Konstruktor tworzy gotowy do użycia obiekt.
- [ ] Dane jednego bytu nie są rozproszone po wielu niezależnych zmiennych.
- [ ] Gra nadal umożliwia ruch, walkę i zwycięstwo.

