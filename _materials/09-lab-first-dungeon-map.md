---
layout: material
title: "Pierwsza mapa lochu"
kind: lab
week: 9
summary: "Budujemy i wyświetlamy mapę `char[,]` zawierającą podłogę, ściany, wyjście i bohatera."
published: false
content_ready: false
---

## Cel laboratorium

Zamień tablicę dwuwymiarową w czytelny model świata gry. W tym tygodniu mapa jeszcze nie musi obsługiwać sterowania.

## Konwencja

W całym projekcie używaj zapisu `mapa[y, x]`: pierwszy indeks oznacza wiersz, drugi kolumnę.

## Zadania

1. Utwórz małą `char[,]` i wyświetl ją zagnieżdżonymi pętlami.
2. Zbuduj prostokątną mapę z podłogą `.` i ścianą `#` na krawędziach.
3. Umieść wyjście `>` i kilka przeszkód.
4. Przechowuj pozycję gracza w dwóch zmiennych i wyświetlaj `@` bez trwałego nadpisywania podłoża.
5. Napisz metody tworzenia oraz wyświetlania mapy.
6. Dodaj legendę i sprawdzanie, czy współrzędne mieszczą się na planszy.

## Kryteria ukończenia

- [ ] Obie pętle korzystają z właściwego wymiaru `GetLength`.
- [ ] Mapa nie jest zniekształcona ani transponowana.
- [ ] Pozycja bohatera i dane podłoża są rozdzielone.
- [ ] Program nie odczytuje pola poza granicą tablicy.

