# Podstawy programowania — Portal kursu

Portal WWW dla kursu **Podstawy programowania** — lekka, responsywna strona statyczna stworzona w Jekyll i hostowana na GitHub Pages.

## 🚀 O portalu

Ten portal stanowi centralny punkt organizacyjny kursu C# dla początkujących, bez wymagań wstępnych. Kurs obejmuje **15 tygodni** z powiązanymi **wykładami** i **laboratoriami**, na którego tle buduje się stopniowo **konsolowa gra typu roguelike**.

### Główne cechy

- 📚 **15 tygodni kursu** z osobnymi linkami do wykładów i laboratoriów
- 🔒 **System statusów materiałów** — dostępny, wkrótce, zablokowany do tygodnia
- 📱 **Responsywny design** — pulpit sci-fi (estetyka Decepticonów)
- ⚙️ **Łatwe zarządzanie** — materiały w Markdown, publikacja poprzez zmianę metadanych
- 🌐 **GitHub Pages** — hosting bezpłatny, deployment automatyczny
- 🎨 **Estetyka sci-fi** — grafit, metaliczne tony, czerwone akcenty

## 📂 Struktura projektu

```
.
├── _config.yml              # Konfiguracja Jekyll
├── _data/
│   └── course.yml          # Dane kursu, bieżący tydzień
├── _layouts/               # Szablony stron
│   ├── default.html
│   ├── page.html
│   ├── material.html
│   └── plan.html
├── _includes/              # Komponenty wielokrotnego użytku
│   ├── header.html
│   ├── footer.html
│   ├── status-badge.html
│   └── material-nav.html
├── _materials/             # 30 stron materiałów (15 wyk. + 15 lab.)
│   ├── 01-lecture-introduction-to-csharp.md
│   ├── 01-lab-setting-up-environment.md
│   ├── 02-lecture-variables-and-data-types.md
│   ├── 02-lab-working-with-variables.md
│   └── ...
├── assets/css/
│   └── site.css            # Style i responsywny design
├── .github/workflows/
│   └── pages.yml           # Workflow publikacji GitHub Pages
├── index.md                # Strona główna
├── plan.md                 # Plan kursu (lista wszystkich tygodni)
├── organizacja.md          # Informacje organizacyjne
├── Gemfile                 # Zależności Ruby/Jekyll
└── README.md               # Ten plik

```

## 🛠️ Technologie

- **Jekyll** — generator stron statycznych
- **Markdown** — format plików treści
- **Liquid** — szablonowanie
- **HTML5 & CSS3** — frontend
- **GitHub Pages** — hosting

## 🚀 Szybki start

### Wymagania

- Ruby 3.0+
- Jekyll 4.3+
- Bundler

### Instalacja

1. **Klonuj repozytorium:**
   ```bash
   git clone https://github.com/pjatk-prg/podstawy-programowania.git
   cd podstawy-programowania
   ```

2. **Zainstaluj zależności:**
   ```bash
   bundle install
   ```

3. **Zbuduj stronę lokalnie:**
   ```bash
   bundle exec jekyll serve
   ```

4. **Otwórz w przeglądarce:**
   ```
   http://localhost:4000/podstawy-programowania
   ```

## 📝 Dodawanie i publikowanie materiałów

### Zmiana bieżącego tygodnia

Edytuj `_data/course.yml` i zmień `current_week`:

```yaml
current_week: 1  # → zmień na 2, 3, itd.
```

Status materiałów zmieni się automatycznie.

### Publikacja materiału

Edytuj plik materiału, np. `_materials/02-lecture-variables-and-data-types.md`:

```yaml
published: false          # → zmień na true
unlock_week: 2           # materiał będzie dostępny w tygodniu 2
```

### Dodawanie treści do materiału

Dodaj tekst pod front matter:

```markdown
---
layout: material
title: "Zmienne, typy danych i operatory"
kind: lecture
week: 2
published: true
---

## Zawartość

Tutaj dodaj treść wykładu...
```

## 📊 Statusy materiałów

| Status | Warunek | Wygląd |
|--------|---------|--------|
| 🟢 Dostępny | `published: true` i `unlock_week ≤ current_week` | Zielona etykieta |
| 🟡 Wkrótce | `published: false` | Żółta etykieta |
| 🔴 Zablokowany | `published: true` ale `unlock_week > current_week` | Czerwona etykieta |

## 🎨 Dostosowywanie wyglądu

Kolory i style znajdują się w `assets/css/site.css`. Główne zmienne CSS:

```css
--color-bg: #0a0a0e;           /* Tło */
--color-primary: #e60012;      /* Czerwony (główny akcent) */
--color-accent: #8e00ff;       /* Fioletowy (akcent drugorzędny) */
--color-text: #e0e0e0;         /* Tekst */
```

## 🌐 Publikacja na GitHub Pages

1. **Upewnij się, że Settings → Pages ma:**
   - Source: Deploy from a branch
   - Branch: main

2. **Dodaj zmiany:**
   ```bash
   git add .
   git commit -m "Add/update course materials"
   git push origin main
   ```

3. **Workflow uruchomi się automatycznie** i strona będzie dostępna pod:
   ```
   https://pjatk-prg.github.io/podstawy-programowania
   ```

## 📚 Struktura materiału

Każdy materiał (wykład/laboratorium) zawiera:

- `title` — Tytuł materiału
- `kind` — Typ: `lecture` (wykład) lub `lab` (laboratorium)
- `week` — Numer tygodnia (1–15)
- `summary` — Krótki opis
- `published` — czy jest opublikowany (true/false)
- `unlock_week` — tydzień, w którym materiał zostaje odblokowany (opcjonalnie)

## ❓ FAQ

**P: Jak zmienić bieżący tydzień kursu?**  
O: Edytuj `_data/course.yml` i zmień `current_week`.

**P: Czy mogę dodać swoje formaty plików (obrazy, PDF)?**  
O: Tak, dodaj je do folderu `assets/` i linkuj w Markdown: `[Link]({{ '/assets/file.pdf' | relative_url }})`.

**P: Jak zablokować materiał do konkretnego tygodnia?**  
O: Ustaw `unlock_week: N` w front matter materiału.

**P: Czy można zmienić kolor motywu?**  
O: Tak, edytuj zmienne w `assets/css/site.css`.

**P: Jak dodać nowy tydzień ponad 15?**  
O: Dodaj wpis w `_data/course.yml` i utwórz dwa pliki materiałów.

## 📞 Kontakt i wsparcie

- Prowadzący: [uzupełnij email]
- Portal: https://github.com/pjatk-prg/podstawy-programowania
- Platforma: GitHub Pages

## 📄 Licencja

Treści kursu — **[Uzupełnij licencję]**

---

**Ostatnia aktualizacja:** 2026-09-30  
**Status:** ✅ Operacyjny