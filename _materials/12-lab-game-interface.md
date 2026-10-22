---
layout: material
title: "Stany i interfejs gry"
kind: lab
week: 12
summary: "Budujemy ekrany menu, rozgrywki, zwycięstwa i porażki oraz przejścia między poziomami."
published: false
content_ready: false
---

## Cel laboratorium

Spraw, aby interfejs zawsze odzwierciedlał bieżący stan programu, a przejścia między fazami gry były jawne i przewidywalne.

## Zadania

1. Zdefiniuj `enum GameState` dla menu, gry, zwycięstwa, porażki i wyjścia.
2. Uruchamiaj odpowiedni ekran zależnie od bieżącego stanu.
3. Wyświetl mapę, HP, złoto, ekwipunek i ostatni komunikat akcji.
4. Dodaj rozpoczęcie nowej gry resetujące wszystkie potrzebne dane.
5. Dodaj drugi poziom i przejście po osiągnięciu wyjścia.
6. Zapewnij osobne ekrany zwycięstwa i porażki z opcją ponownej gry.

## Kryteria ukończenia

- [ ] Każdy stan ma jasno określone możliwe przejścia.
- [ ] Nowa gra nie zachowuje przypadkowych danych poprzedniej rozgrywki.
- [ ] Interfejs przekazuje informacje również tekstem, nie tylko kolorem.
- [ ] Pełną grę można rozpocząć, wygrać lub przegrać i zakończyć.

