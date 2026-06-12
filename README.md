# Guess The Number 2 (C#)

## Description
Konsolowa gra "Zgadnij liczbę 2" napisana w podejściu obiektowym w C#.
Gracz może wybrać standardową rozgrywkę lub tryb "Nowa gra plus" z przelosowywaniem ukrytej liczby co 6/7/8 prób.
Wyniki są zapisywane do Hall of Fame wraz z czasem trwania w sekundach.

## Jak zbudować

```
dotnet build
```

## Jak uruchomić

```
dotnet run
```

## Funkcje

* ekran powitalny z opcjami: nowa gra, Hall of Fame, ustawienia, wyjście
* ustawienia: zmiana języka (PL/EN), przełączanie pytania o tryb zakładu, czyszczenie Hall of Fame
* Hall of Fame przechowuje TOP5 wyników dla każdego poziomu trudności
* wyświetlanie aktualnych ustawień na ekranie powitalnym
* tryb zakładu dostępny w standardowej rozgrywce (jeśli włączony)
* tryb Nowa gra plus bez zakładu, z przelosowywaniem ukrytej liczby co 6/7/8 prób
* po każdej wygranej podawany jest czas gry w sekundach
* przy równych próbach wyżej klasyfikowany jest krótszy czas gry

## Pliki

* `Program.cs`
* `GameApplication.cs`
* `GameSettings.cs`
* `HallOfFame.cs`
* `ScoreEntry.cs`
* `Language.cs`
* `Difficulty.cs`
* `GuessNumberGame.cs`
* `NewGamePlus.cs`
* `Localizer.cs`
* `guess-the-number.csproj`

## Uwagi

* Gra tworzy pliki `settings.json` i `halloffame.json` w katalogu uruchomieniowym.
* Opcja Hall of Fame pojawia się dopiero po zapisaniu chociaż jednego wyniku.
