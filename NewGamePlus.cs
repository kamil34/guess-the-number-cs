using System;
using System.Diagnostics;

public class NewGamePlus
{
    private readonly GameSettings settings;
    private readonly Localizer localizer;
    private readonly Random random = new();

    public NewGamePlus(GameSettings settings, Localizer localizer)
    {
        this.settings = settings;
        this.localizer = localizer;
    }

    public ScoreEntry? Play(Difficulty difficulty)
    {
        int maxValue = difficulty switch
        {
            Difficulty.Easy => 50,
            Difficulty.Medium => 100,
            Difficulty.Hard => 250,
            _ => 100,
        };

        int secret = random.Next(1, maxValue + 1);
        var stopwatch = Stopwatch.StartNew();
        int attemptNumber = 1;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"========== {localizer.Get(difficulty.ToString())} - {localizer.Get("NewGamePlus")} ==========");
            Console.WriteLine(localizer.Get("AttemptNumber", attemptNumber));
            int guess = ReadInteger(localizer.Get("EnterGuessPrompt"), 1, maxValue);

            if (guess == secret)
            {
                stopwatch.Stop();
                return CompleteGame(difficulty, attemptNumber, stopwatch.Elapsed.TotalSeconds);
            }

            Console.WriteLine(localizer.GetRandomGuessMessage(guess, secret));
            if (attemptNumber % 6 == 0 || attemptNumber % 7 == 0 || attemptNumber % 8 == 0)
            {
                secret = random.Next(1, maxValue + 1);
                Console.WriteLine(localizer.Get("SecretReshuffled"));
            }

            Pause();
            attemptNumber++;
        }
    }

    private ScoreEntry CompleteGame(Difficulty difficulty, int attempts, double durationSeconds)
    {
        Console.WriteLine(localizer.Get("WonMessage"));
        Console.WriteLine(localizer.Get("TimeResult", durationSeconds));
        Console.WriteLine(localizer.Get("EnterPlayerName"));

        string? playerName = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(playerName))
        {
            playerName = "Player";
        }

        return ScoreEntry.Create(playerName, difficulty, attempts, durationSeconds, true);
    }

    private int ReadInteger(string prompt, int minimum, int maximum)
    {
        while (true)
        {
            Console.Write(prompt + " ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int value) && value >= minimum && value <= maximum)
            {
                return value;
            }

            Console.WriteLine(localizer.Get("InvalidOption"));
        }
    }

    private void Pause()
    {
        Console.WriteLine();
        Console.WriteLine(localizer.Get("PressAnyKey"));
        Console.ReadKey(true);
    }
}
