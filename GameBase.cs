using System;

public abstract class GameBase : IGame
{
    protected readonly GameSettings settings;
    protected readonly Localizer localizer;
    protected readonly Random random = new();

    protected GameBase(GameSettings settings, Localizer localizer)
    {
        this.settings = settings;
        this.localizer = localizer;
    }

    public abstract ScoreEntry? Play(Difficulty difficulty);

    protected int ReadInteger(string prompt, int minimum, int maximum)
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

    protected void Pause()
    {
        Console.WriteLine();
        Console.WriteLine(localizer.Get("PressAnyKey"));
        Console.ReadKey(true);
    }

    protected ScoreEntry CompleteGame(Difficulty difficulty, int attempts, double durationSeconds, bool newGamePlus)
    {
        Console.WriteLine(localizer.Get("WonMessage"));
        Console.WriteLine(localizer.Get("TimeResult", durationSeconds));
        Console.WriteLine(localizer.Get("EnterPlayerName"));

        string? playerName = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(playerName))
        {
            playerName = "Player";
        }

        return ScoreEntry.Create(playerName, difficulty, attempts, durationSeconds, newGamePlus);
    }
}
