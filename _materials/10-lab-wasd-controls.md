---
layout: material
title: "Sterowanie WASD i kolizje"
kind: lab
week: 10
summary: "Poruszamy bohaterem po mapie, blokujemy ściany i obsługujemy wyjście z poziomu."
published: false
content_ready: false
---

## Cel laboratorium

Zmień statyczną mapę w prostą rozgrywkę turową sterowaną klawiszami.

## Zadania

1. Odczytaj `W`, `A`, `S`, `D` za pomocą `Console.ReadKey(true)`.
2. Zamień klawisz na zmianę `dx` i `dy`.
3. Oblicz proponowaną pozycję, nie zmieniając jeszcze aktualnej.
4. Odrzuć ruch poza mapę lub na ścianę `#`.
5. Zatwierdź ruch na podłogę i ponownie narysuj planszę.
6. Dodaj drzwi, złoto albo miksturę oraz wyjście kończące poziom.
7. Dodaj komendę kończącą grę i komunikat ostatniej akcji.

## Kryteria ukończenia

- [ ] Nieznany klawisz nie przesuwa gracza.
- [ ] Gracz nie opuszcza planszy i nie przechodzi przez ściany.
- [ ] Interakcja zachodzi dopiero po poprawnym ruchu.
- [ ] Można osiągnąć warunek zwycięstwa.

