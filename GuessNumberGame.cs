using System;
using System.Diagnostics;

public class GuessNumberGame : GameBase
{
    public GuessNumberGame(GameSettings settings, Localizer localizer)
        : base(settings, localizer)
    {
    }

    //Polymorphism example
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
            Console.WriteLine(localizer.Text.AskBetQuestion);
            Console.WriteLine("1) " + localizer.Text.Yes);
            Console.WriteLine("2) " + localizer.Text.No);
            int betChoice = ReadInteger(localizer.Text.ChooseOption, 1, 2);
            if (betChoice == 1)
            {
                maxAttempts = ReadInteger(localizer.Text.EnterBetMaxAttempts, 1, maxValue * 2);
            }
        }

        var stopwatch = Stopwatch.StartNew();
        int attemptNumber = 1;

        while (attemptNumber <= maxAttempts)
        {
            Console.Clear();
            Console.WriteLine($"========== {localizer.GetDifficultyText(difficulty)} ==========");
            Console.WriteLine(localizer.Text.AttemptNumber(attemptNumber));
            int guess = ReadInteger(localizer.Text.EnterGuessPrompt, 1, maxValue);

            if (guess == secret)
            {
                stopwatch.Stop();
                return CompleteGame(difficulty, attemptNumber, stopwatch.Elapsed.TotalSeconds, false);
            }

            Console.WriteLine(localizer.GetRandomGuessMessage(guess, secret));
            if (attemptNumber == maxAttempts)
            {
                Console.WriteLine(localizer.Text.OutOfAttempts);
                Pause();
                return null;
            }

            Pause();
            attemptNumber++;
        }

        return null;
    }
}