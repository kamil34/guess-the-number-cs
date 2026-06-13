using System;
using System.Diagnostics;

public class GuessNumberGame : GameBase
{
    public GuessNumberGame(GameSettings settings, Localizer localizer)
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
        int maxAttempts = int.MaxValue;

        if (settings.AskBet)
        {
            Console.WriteLine();
            Console.WriteLine(localizer.Get("AskBetQuestion"));
            Console.WriteLine("1) " + localizer.Get("Yes"));
            Console.WriteLine("2) " + localizer.Get("No"));
            int betChoice = ReadInteger(localizer.Get("ChooseOption"), 1, 2);
            if (betChoice == 1)
            {
                maxAttempts = ReadInteger(localizer.Get("EnterBetMaxAttempts"), 1, maxValue * 2);
            }
        }

        var stopwatch = Stopwatch.StartNew();
        int attemptNumber = 1;

        while (attemptNumber <= maxAttempts)
        {
            Console.Clear();
            Console.WriteLine($"========== {localizer.Get(difficulty.ToString())} ==========");
            Console.WriteLine(localizer.Get("AttemptNumber", attemptNumber));
            int guess = ReadInteger(localizer.Get("EnterGuessPrompt"), 1, maxValue);

            if (guess == secret)
            {
                stopwatch.Stop();
                return CompleteGame(difficulty, attemptNumber, stopwatch.Elapsed.TotalSeconds, false);
            }

            Console.WriteLine(localizer.GetRandomGuessMessage(guess, secret));
            if (attemptNumber == maxAttempts)
            {
                Console.WriteLine(localizer.Get("OutOfAttempts"));
                Pause();
                return null;
            }

            Pause();
            attemptNumber++;
        }

        return null;
    }
}
