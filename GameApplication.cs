using System;
using System.Collections.Generic;

// Encapsualtion
public class GameApplication
{
    private readonly GameSettings settings;
    private readonly HallOfFame hallOfFame;
    private readonly Localizer localizer;
    private bool exitRequested;

    public GameApplication()
    {
        settings = GameSettings.Load();
        hallOfFame = HallOfFame.Load();
        localizer = new Localizer(settings.Language);
    }

    public void Run()
    {
        while (!exitRequested)
        {
            ShowWelcomeScreen();
        }
    }

    private void ShowWelcomeScreen()
    {
        localizer.SetLanguage(settings.Language);
        Console.Clear();
        Console.WriteLine("=====================================");
        Console.WriteLine(localizer.Text.WelcomeTitle);
        Console.WriteLine("=====================================");
        Console.WriteLine(localizer.Text.CurrentSettings(settings.Language.ToString(), settings.AskBet ? localizer.Text.Yes : localizer.Text.No));
        Console.WriteLine();
        Console.WriteLine("1) " + localizer.Text.NewGame);
        Console.WriteLine("2) " + localizer.Text.HallOfFame);
        Console.WriteLine("3) " + localizer.Text.Settings);
        Console.WriteLine("4) " + localizer.Text.Exit);
        Console.WriteLine();

        int choice = ReadInteger(localizer.Text.ChooseOption, 1, 4);

        if (choice == 1)
        {
            StartNewGame();
            return;
        }

        if (choice == 2)
        {
            ShowHallOfFameScreen();
            return;
        }

        if (choice == 3)
        {
            ShowSettingsScreen();
            return;
        }

        exitRequested = true;
    }

    private void ShowSettingsScreen()
    {
        localizer.SetLanguage(settings.Language);
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========== " + localizer.Text.SettingsTitle + " ==========");
            Console.WriteLine(localizer.Text.CurrentLanguage(localizer.GetLanguageName(settings.Language)));
            Console.WriteLine(localizer.Text.CurrentAskBet(settings.AskBet ? localizer.Text.Yes : localizer.Text.No));
            Console.WriteLine();
            Console.WriteLine("1) " + localizer.Text.ChangeLanguage);
            Console.WriteLine("2) " + localizer.Text.ToggleAskBet);
            Console.WriteLine("3) " + localizer.Text.ClearHallOfFame);
            Console.WriteLine("4) " + localizer.Text.Back);
            Console.WriteLine();

            int choice = ReadInteger(localizer.Text.ChooseOption, 1, 4);
            if (choice == 1)
            {
                ChooseLanguage();
            }
            else if (choice == 2)
            {
                settings.AskBet = !settings.AskBet;
                settings.Save();
                Console.WriteLine(localizer.Text.AskBetChanged(settings.AskBet ? localizer.Text.Yes : localizer.Text.No));
                Pause();
            }
            else if (choice == 3)
            {
                ClearHallOfFame();
            }
            else
            {
                return;
            }
        }
    }

    private void ChooseLanguage()
    {
        Console.Clear();
        Console.WriteLine("========== " + localizer.Text.ChangeLanguage + " ==========");
        Console.WriteLine("1) " + localizer.GetLanguageName(Language.Polish));
        Console.WriteLine("2) " + localizer.GetLanguageName(Language.English));
        Console.WriteLine();
        int choice = ReadInteger(localizer.Text.ChooseOption, 1, 2);
        settings.Language = choice == 1 ? Language.Polish : Language.English;
        settings.Save();
        localizer.SetLanguage(settings.Language);
        Console.WriteLine(localizer.Text.LanguageChanged(localizer.GetLanguageName(settings.Language)));
        Pause();
    }

    private void ClearHallOfFame()
    {
        Console.WriteLine(localizer.Text.ConfirmClearHallOfFame);
        Console.WriteLine("1) " + localizer.Text.Yes);
        Console.WriteLine("2) " + localizer.Text.No);
        int choice = ReadInteger(localizer.Text.ChooseOption, 1, 2);
        if (choice == 1)
        {
            hallOfFame.Clear();
            hallOfFame.Save();
            Console.WriteLine(localizer.Text.HallOfFameCleared);
            Pause();
        }
    }

    private void StartNewGame()
    {
        localizer.SetLanguage(settings.Language);
        Console.Clear();
        Console.WriteLine("========== " + localizer.Text.NewGameTitle + " ==========");
        Console.WriteLine("1) " + localizer.Text.StandardGame);
        Console.WriteLine("2) " + localizer.Text.NewGamePlus);
        Console.WriteLine("3) " + localizer.Text.Back);
        Console.WriteLine();

        int choice = ReadInteger(localizer.Text.ChooseOption, 1, 3);
        if (choice == 3)
        {
            return;
        }

        Difficulty difficulty = ChooseDifficulty();
        if (difficulty == Difficulty.None)
        {
            return;
        }

        IGame game = choice == 1
            ? new GuessNumberGame(settings, localizer)
            : new NewGamePlus(settings, localizer);

        ScoreEntry? entry = game.Play(difficulty);

        if (entry != null)
        {
            hallOfFame.Add(entry);
            hallOfFame.Save();
            Console.WriteLine();
            Console.WriteLine(localizer.Text.ResultSaved);
            Pause();
        }
    }

    private Difficulty ChooseDifficulty()
    {
        Console.WriteLine();
        Console.WriteLine(localizer.Text.ChooseDifficulty);
        Console.WriteLine("1) " + localizer.Text.Easy);
        Console.WriteLine("2) " + localizer.Text.Medium);
        Console.WriteLine("3) " + localizer.Text.Hard);
        Console.WriteLine("4) " + localizer.Text.Back);
        Console.WriteLine();
        int choice = ReadInteger(localizer.Text.ChooseOption, 1, 4);
        return choice switch
        {
            1 => Difficulty.Easy,
            2 => Difficulty.Medium,
            3 => Difficulty.Hard,
            _ => Difficulty.None,
        };
    }

    private void ShowHallOfFameScreen()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========== " + localizer.Text.HallOfFameTitle + " ==========");
            if (!hallOfFame.HasRecords)
            {
                Console.WriteLine(localizer.Text.NoRecords);
                Pause();
                return;
            }

            Console.WriteLine(localizer.Text.ChooseDifficulty);
            Console.WriteLine("1) " + localizer.Text.Easy);
            Console.WriteLine("2) " + localizer.Text.Medium);
            Console.WriteLine("3) " + localizer.Text.Hard);
            Console.WriteLine("4) " + localizer.Text.Back);
            Console.WriteLine();
            int choice = ReadInteger(localizer.Text.ChooseOption, 1, 4);
            if (choice == 4)
            {
                return;
            }

            Difficulty difficulty = choice switch
            {
                1 => Difficulty.Easy,
                2 => Difficulty.Medium,
                3 => Difficulty.Hard,
                _ => Difficulty.Easy,
            };

            Console.Clear();
            Console.WriteLine("========== " + localizer.Text.HallOfFameTitle + " - " + localizer.GetDifficultyText(difficulty) + " ==========");
            var top = hallOfFame.GetTopForDifficulty(difficulty, 5);
            if (top.Count == 0)
            {
                Console.WriteLine(localizer.Text.NoRecordsForDifficulty);
            }
            else
            {
                for (int index = 0; index < top.Count; index++)
                {
                    var entry = top[index];
                    string highlight = entry.NewGamePlus ? localizer.Text.NewGamePlusHighlight : string.Empty;
                    Console.WriteLine($"{index + 1}. {entry.PlayerName} - {entry.Attempts} {localizer.Text.Attempts} - {entry.DurationSeconds:F1} {localizer.Text.Seconds} {highlight}");
                }
            }

            Console.WriteLine();
            Console.WriteLine(localizer.Text.PressAnyKey);
            Console.ReadKey(true);
        }
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

            Console.WriteLine(localizer.Text.InvalidOption);
        }
    }

    private void Pause()
    {
        Console.WriteLine();
        Console.WriteLine(localizer.Text.PressAnyKey);
        Console.ReadKey(true);
    }
}