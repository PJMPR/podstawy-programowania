---
layout: material
title: "Walka i zdarzenia losowe"
kind: lab
week: 7
summary: "Dodajemy losowe obrażenia, trafienia krytyczne, przeciwników i nagrody."
published: false
content_ready: false
---

## Cel laboratorium

Zbuduj kompletną, kończącą się walkę i zastosuj `Random` w małych metodach o czytelnych regułach.

## Zadania

1. Sprawdź granice `Random.Next` na serii losowań.
2. Napisz metodę losującą nazwę przeciwnika z tablicy.
3. Zaimplementuj obrażenia z zakresu oraz 20% szansy na trafienie krytyczne.
4. Zbuduj pętlę walki: atak, leczenie albo ucieczka; pokonany przeciwnik nie kontratakuje.
5. Po zwycięstwie wylosuj złoto i opcjonalny przedmiot, a opis dodaj do historii gry.

## Scenariusze testowe

- zwycięstwo zwykłym atakiem,
- trafienie krytyczne,
- brak mikstur,
- skuteczna ucieczka,
- przegrana bohatera.

## Kryteria ukończenia

- [ ] Program korzysta z jednego obiektu `Random`.
- [ ] Zakresy losowania są zgodne ze specyfikacją.
- [ ] Walka zawsze może się zakończyć.
- [ ] Zdrowie nie jest wyświetlane jako liczba ujemna.

