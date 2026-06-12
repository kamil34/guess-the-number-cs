# Guess The Number 2 (C#)

## Description
A console game "Guess the Number 2" written in an object-oriented approach in C#.
The player can choose a standard game or "New Game Plus" mode with the hidden number being redrawn every 6/7/8 attempts.
Results are saved to the Hall of Fame along with the duration time in seconds.

## How to Build

```
dotnet build
```

## How to Run

```
dotnet run
```

## Features

* welcome screen with options: new game, Hall of Fame, settings, exit
* settings: change language (PL/EN), toggle betting mode question, clear Hall of Fame
* Hall of Fame stores TOP 5 results for each difficulty level
* display current settings on the welcome screen
* betting mode available in standard gameplay (if enabled)
* New Game Plus mode without betting, with hidden number redrawn every 6/7/8 attempts
* after each win, the game time in seconds is provided
* with equal attempts, shorter game time is ranked higher

## Files

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

## Notes

* The game creates `settings.json` and `halloffame.json` files in the application directory.
* The Hall of Fame option appears only after saving at least one result.
