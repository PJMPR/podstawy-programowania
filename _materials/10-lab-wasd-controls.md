---
layout: material
title: "Laboratorium 10 — sterowanie WASD i kolizje"
kind: lab
week: 10
summary: "Siedem zadań o odczytywaniu klawiszy, proponowanym ruchu, kolizjach, interakcjach i prostej turze gry."
published: true
content_ready: true
---

## Cel laboratorium

Zamienisz statyczną mapę z poprzedniego laboratorium w prostą grę turową. Odczytasz klawisze `W`, `A`, `S`, `D`, obliczysz proponowaną pozycję, sprawdzisz kolizje i dopiero wtedy zatwierdzisz ruch. Dodasz także przedmioty, drzwi, przeciwnika i warunek zwycięstwa.

Do wykonania jest **7 zadań**:

- zadania 1–2 — proste,
- zadania 3–4 — średnie,
- zadania 5–6 — trudniejsze,
- zadanie 7 — projekt integracyjny.

```text
klawisz → dx/dy → proponowana pozycja → walidacja → ruch → interakcja → następna tura
```

<aside class="material-callout callout-note">
<strong>Najważniejsza zasada</strong>
<p>Najpierw oblicz i sprawdź proponowany ruch. Aktualną pozycję gracza zmień dopiero wtedy, gdy ruch jest dozwolony.</p>
</aside>

## Zasady pracy

- Pracuj na własnym repozytorium utworzonym przez GitHub Classroom.
- Każde zadanie uruchamiaj przez menu i osobną metodę `Task1()`–`Task7()`.
- Rozwiązuj zadania po kolei — późniejsze wykorzystują wcześniejsze metody.
- Po każdym zadaniu zbuduj plik `.slnx` i uruchom `DungeonRaider.App`.
- Logikę ruchu i kolizji umieszczaj w `DungeonRaider.Core`; konsolę i rysowanie w `DungeonRaider.App`.
- Zachowaj kierunek zależności `DungeonRaider.App → DungeonRaider.Core`.
- Stosuj konwencję `map[y, x]`.
- Nie zapisuj `@` ani `M` w mapie — są nakładkami renderera.

---

# Repozytorium i projekt startowy

Kod do GitHub Classroom znajduje się w `examples/10-dungeon-raider-starter`. Rozwiązanie prowadzącego jest przechowywane osobno w `examples/10-dungeon-raider-solution`. Do Classroom skopiuj wyłącznie starter.

Otwórz `src/DungeonRaider/DungeonRaider.slnx` i uruchom:

```powershell
dotnet build .\src\DungeonRaider\DungeonRaider.slnx
dotnet run --project .\src\DungeonRaider\DungeonRaider.App\DungeonRaider.App.csproj
```

Starter kompiluje się przed rozpoczęciem pracy. Miejsca przeznaczone do uzupełnienia oznaczono `TODO`.

```text
src/DungeonRaider/
├── DungeonRaider.slnx
├── DungeonRaider.App/
│   ├── Program.cs
│   └── UI/MapRenderer.cs
└── DungeonRaider.Core/
    └── Game/Movement.cs
```

| Projekt | Odpowiedzialność |
|---|---|
| `DungeonRaider.Core` | kierunek ruchu, granice i reguły wejścia na pole |
| `DungeonRaider.App` | menu, pętla gry, komunikaty i odczyt klawiatury |
| `DungeonRaider.App.UI` | wyświetlanie mapy, aktorów i stanu gry |

## Symbole mapy

| Symbol | Znaczenie | Element mapy? |
|---:|---|---:|
| `#` | ściana | tak |
| `.` | podłoga | tak |
| `G` | złoto | tak |
| `K` | klucz | tak |
| `D` | zamknięte drzwi | tak |
| `E` | wyjście | tak |
| `@` | gracz | nie — nakładka |
| `M` | przeciwnik | nie — nakładka |

---

# Poziom prosty — zadania 1–2

## Zadanie 1. Proste — odczytywanie poleceń

Uzupełnij `Movement.TryGetDirection(ConsoleKey key, out int dx, out int dy)`. Metoda ma zamieniać klawisz na zmianę współrzędnych:

| Klawisz | `dx` | `dy` |
|---:|---:|---:|
| `W` | `0` | `-1` |
| `A` | `-1` | `0` |
| `S` | `0` | `1` |
| `D` | `1` | `0` |

Dla innego klawisza ustaw `dx = 0`, `dy = 0` i zwróć `false`. W `Task1()` odczytuj klawisze przez `Console.ReadKey(true)`, pokazuj wynik i kończ po `Q`.

### Kryteria ukończenia

- [ ] Cztery klawisze zwracają właściwe `dx` i `dy`.
- [ ] Nieznany klawisz zwraca `false` i `(0, 0)`.
- [ ] Odczytany klawisz nie pojawia się automatycznie w konsoli.
- [ ] `Q` kończy pętlę bez ruchu.

---

## Zadanie 2. Proste — proponowana pozycja

W `Task2()` przechowuj `playerX` i `playerY`. Po poprawnym klawiszu oblicz osobno:

```csharp
int nextX = playerX + dx;
int nextY = playerY + dy;
```

Wyświetl pozycję aktualną i proponowaną, a następnie zatwierdź ruch. Nie sprawdzaj jeszcze ścian. Niepoprawny klawisz nie może zmienić pozycji.

### Kryteria ukończenia

- [ ] Nowa pozycja powstaje w osobnych zmiennych.
- [ ] `x` zmienia się dla `A/D`, a `y` dla `W/S`.
- [ ] Nieznany klawisz nie przesuwa gracza.
- [ ] Pozycja jest zatwierdzana dopiero po obliczeniu obu współrzędnych.

---

# Poziom średni — zadania 3–4

## Zadanie 3. Średnie — granice mapy i ściany

Uzupełnij `Movement.IsInside` oraz `Movement.CanEnter`. Pole jest niedostępne, gdy leży poza mapą, jest ścianą `#` albo jest drzwiami `D`, a gracz nie ma klucza.

W `Task3()` dla każdego poprawnego polecenia:

1. oblicz `nextX` i `nextY`,
2. sprawdź proponowane pole,
3. przy błędzie pozostaw stare współrzędne,
4. przy poprawnym ruchu zatwierdź obie współrzędne,
5. ponownie narysuj planszę.

<aside class="material-callout callout-hint">
<strong>Podpowiedź</strong>
<p>Najpierw wywołaj <code>IsInside</code>, a dopiero potem odczytaj <code>map[y, x]</code>.</p>
</aside>

### Kryteria ukończenia

- [ ] Gracz nie wychodzi poza mapę ani nie przechodzi przez `#`.
- [ ] Tablica nie jest odczytywana przed sprawdzeniem granic.
- [ ] Nieudany ruch nie zmienia pozycji.
- [ ] Komunikat opisuje ostatnią próbę ruchu.

---

## Zadanie 4. Średnie — zbieranie złota

Dodaj pola `G` i licznik `gold`. Po **poprawnym ruchu** na złoto zwiększ licznik, zamień pole na `.` i ustaw komunikat `Zebrano złoto.`. Ponowne wejście na to samo pole nie może drugi raz zwiększyć wyniku.

### Eksperyment

Wyjaśnij, dlaczego interakcja wykonana przed sprawdzeniem ruchu mogłaby pozwolić zebrać przedmiot bez wejścia na jego pole.

### Kryteria ukończenia

- [ ] Złoto jest zbierane tylko po zatwierdzonym ruchu.
- [ ] Zebrane `G` zmienia się w `.`.
- [ ] Jedno pole zwiększa licznik dokładnie raz.
- [ ] Próba wejścia w ścianę nie uruchamia interakcji.

---

# Poziom trudniejszy — zadania 5–6

## Zadanie 5. Trudniejsze — klucz i drzwi

Dodaj pola `K` i `D` oraz zmienną `hasKey`.

- Wejście na `K` ustawia `hasKey = true` i usuwa klucz z mapy.
- Wejście na `D` bez klucza jest niedozwolone.
- Wejście na `D` z kluczem otwiera drzwi, zużywa klucz i pozostawia gracza na tym polu.
- Stan klucza oraz ostatni komunikat są widoczne pod mapą.

### Kryteria ukończenia

- [ ] Klucz można podnieść tylko raz.
- [ ] Drzwi blokują gracza bez klucza.
- [ ] Klucz pozwala wejść na drzwi i zostaje zużyty.
- [ ] Otwarte drzwi nie blokują kolejnych przejść.

---

## Zadanie 6. Trudniejsze — tura przeciwnika

Przechowuj przeciwnika jako osobne `enemyX` i `enemyY`. Po każdym **poprawnym ruchu gracza** przeciwnik wykonuje najwyżej jeden krok:

1. najpierw próbuje zmniejszyć różnicę w osi `x`,
2. jeżeli krok jest zablokowany albo `x` jest równe, próbuje osi `y`,
3. nie wychodzi poza mapę i nie przechodzi przez `#` ani `D`,
4. wejście na pozycję gracza kończy grę porażką.

Niepoprawny klawisz i zablokowany ruch gracza nie uruchamiają tury przeciwnika.

### Kryteria ukończenia

- [ ] Przeciwnik wykonuje maksymalnie jeden krok na turę.
- [ ] Porusza się tylko po poprawnym ruchu gracza.
- [ ] Respektuje granice, ściany i zamknięte drzwi.
- [ ] Spotkanie kończy grę czytelnym komunikatem.
- [ ] `M` nie jest zapisane w mapie.

---

# Zadanie projektowe

## Zadanie 7. Projekt — „Ucieczka z lochu”

Zbuduj kompletny poziom gry konsolowej wykorzystujący elementy z zadań 1–6.

## Wymagania obowiązkowe

Gra musi zawierać:

1. sterowanie `WASD` oraz zakończenie przez `Q`,
2. prostokątną mapę z granicami i wewnętrznymi ścianami,
3. gracza przechowywanego poza mapą,
4. co najmniej dwa pola złota `G`,
5. jeden klucz `K` i jedne drzwi `D`,
6. wyjście `E`, które daje zwycięstwo dopiero po zebraniu całego złota,
7. przeciwnika poruszającego się po poprawnej turze gracza,
8. liczniki ruchów i złota,
9. komunikat ostatniej akcji,
10. ekran końcowy: zwycięstwo, porażka albo rezygnacja.

## Kolejność tury

```text
1. Odczytaj klawisz i wyznacz dx/dy.
2. Oblicz nextX/nextY.
3. Sprawdź i zatwierdź ruch gracza.
4. Obsłuż G, K, D albo E.
5. Jeżeli gra trwa, wykonaj ruch przeciwnika.
6. Sprawdź porażkę i narysuj kolejny stan.
```

Jeśli gracz wejdzie na `E` przed zebraniem całego złota, gra trwa, a komunikat podaje, ile złota brakuje. Nie jest wymagane tworzenie klas `Player` ani `Enemy` — klasy będą tematem następnego tygodnia.

## Scenariusze testowe

1. Nieznany klawisz nie zmienia świata.
2. Ruch w ścianę nie zwiększa licznika ruchów.
3. Złoto można zebrać tylko raz.
4. Drzwi nie przepuszczają bez klucza.
5. Klucz otwiera drzwi i znika z ekwipunku.
6. Wyjście z brakującym złotem nie kończy gry.
7. Wyjście po zebraniu złota daje zwycięstwo.
8. Przeciwnik nie przechodzi przez przeszkody.
9. Spotkanie z przeciwnikiem daje porażkę.
10. `Q` kończy grę jako rezygnacja.

## Kryteria ukończenia projektu

- [ ] Wszystkie obowiązkowe symbole mają działające reguły.
- [ ] Walidacja poprzedza każdą zmianę pozycji.
- [ ] Interakcja zachodzi dopiero po poprawnym ruchu.
- [ ] Tura przeciwnika zachodzi we właściwym momencie.
- [ ] Istnieją trzy czytelne zakończenia gry.
- [ ] Liczniki i komunikat odpowiadają stanowi gry.
- [ ] Kod nie duplikuje logiki granic i kolizji.
- [ ] Projekt buduje się bez błędów.

---

## Pytania kontrolne

1. Dlaczego `W` zmniejsza `y`?
2. Czym różni się pozycja aktualna od proponowanej?
3. Dlaczego granice sprawdzamy przed `map[y, x]`?
4. Kiedy ruch należy uznać za turę?
5. Dlaczego interakcja zachodzi po zatwierdzeniu ruchu?
6. Jak zapobiec wielokrotnemu zebraniu przedmiotu?
7. Dlaczego aktorzy są nakładkami, a drzwi częścią mapy?
8. Gdzie najlepiej sprawdzać zwycięstwo i porażkę?

## Co oddać

- kompletny projekt oparty na starterze,
- rozwiązania `Task1()`–`Task7()`,
- uzupełnione `Movement.cs` i `MapRenderer.cs`,
- oba projekty oraz plik `DungeonRaider.slnx`,
- historię commitów i listę wykonanych scenariuszy testowych,
- odpowiedź: „Dlaczego ruch jest najpierw proponowany, a później zatwierdzany?”.

## Podsumowanie

Po laboratorium potrafisz odczytywać klawisze bez echa, zamieniać je na wektor ruchu, bezpiecznie sprawdzać współrzędne, obsługiwać kolizje i interakcje oraz uporządkować prostą turę gry.
