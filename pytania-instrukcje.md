Moduł importu pytań pozwala na zaimportowanie gotowego pliku z pytaniami testowymi, dzięki czemu nie jest konieczne ręczne dodawanie osobno każdego z pytań. Pytania mogą zostać zaimportowane do nowego działu, którego nazwę trzeba będzie wprowadzić przed wgraniem pliku lub do działu już istniejącego. Pytania po zaimportowaniu będą mogły zostać wykorzystane do przygotowania testów.

W celu zaimportowania pytań należy wcześniej przygotować odpowiedni plik w formacie JSON. Każde z pytań musi posiadać odpowiednio określone parametry, tak samo, jak miałoby to miejsce podczas dodawania pytań bezpośrednio w module Testów w Gakko.

Każde z pytań musi zawierać:

Treść pytania (Content)
Rodzaj pytania (QuestionType)
Pytanie jednokrotnego wyboru (0)
Pytanie wielokrotnego wyboru (1)
Pytanie otwarte (2)
Liczbę punktów możliwą do uzyskania za pytanie (Points)
Liczbę opcji, które zostaną wyświetlone studentowi do wyboru w danym pytaniu (NumberOfOptions) – co najmniej 3
Listę odpowiedzi dla danego pytania (Answers)
Każda z odpowiedzi musi składać się z:
Treści odpowiedzi (Content)
Informacji, czy dana odpowiedź jest (Correct):
Poprawna (true)
Niepoprawna (false)
Wagi danej odpowiedzi (Weight)
Waga będzie brana pod uwagę tylko w przypadku testów z rodzajem punktacji „wagi łatwe” lub „wagi trudne”. Jeżeli wiadomo od razu, że pytania posłużą do przygotowania jedynie testów z rodzajem punktacji „duże punkty” lub „małe punkty”, waga może zostać ustawiona jako NULL, co będzie równoznaczne z wartością 1.
Aby plik został prawidłowo zaimportowany, wszystkie powyższe parametry muszą zostać uzupełnione. W przypadku, gdy chociażby dla jednego pytania któryś z powyższych parametrów nie zostanie określony lub zostanie określony nieprawidłowo, cały plik nie zostanie zaimportowany, a dydaktykowi zostanie wyświetlony komunikat informujący o przyczynie problemu.

Przykład pliku:

[
  {
    "Content": "Question 1",
    "QuestionType": 1,
    "NumberOfOptions": 3,
    "Points": 5,
    "Answers": [
      {
        "Content": "A",
        "Weight": 2,
        "Correct": false
      },
      {
        "Content": "B",
        "Weight": -2,
        "Correct": true
      },
      {
        "Content": "C",
        "Weight": -1,
        "Correct": false
      },
      {
        "Content": "D",
        "Weight": 1,
        "Correct": true
      }
    ]
  },
  {
    "Content": "Question 2",
    "QuestionType": 1,
    "NumberOfOptions": 3,
    "Points": 5,
    "Answers": [
      {
        "Content": "A",
        "Weight": 2,
        "Correct": false
      },
      {
        "Content": "B",
        "Weight": -2,
        "Correct": true
      },
      {
        "Content": "C",
        "Weight": -1,
        "Correct": false
      },
      {
        "Content": "D",
        "Weight": 1,
        "Correct": true
      }
    ]
  }
]