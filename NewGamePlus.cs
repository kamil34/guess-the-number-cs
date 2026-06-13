using System;
using System.Diagnostics;

public class NewGamePlus : GameBase
{
    public NewGamePlus(GameSettings settings, Localizer localizer)
        : base(settings, localizer)
    {
    }

    public override ScoreEntry? Play(Difficulty difficulty)
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
                return CompleteGame(difficulty, attemptNumber, stopwatch.Elapsed.TotalSeconds, true);
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
}
