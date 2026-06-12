using System;
using System.Collections.Generic;

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
        Console.WriteLine(localizer.Get("WelcomeTitle"));
        Console.WriteLine("=====================================");
        Console.WriteLine(localizer.Get("CurrentSettings", settings.Language.ToString(), settings.AskBet ? localizer.Get("Yes") : localizer.Get("No")));
        Console.WriteLine();
        Console.WriteLine("1) " + localizer.Get("NewGame"));

        var optionIndex = 2;
        if (hallOfFame.HasRecords)
        {
            Console.WriteLine(optionIndex + ") " + localizer.Get("HallOfFame"));
            optionIndex++;
        }

        Console.WriteLine(optionIndex + ") " + localizer.Get("Settings"));
        optionIndex++;
        Console.WriteLine(optionIndex + ") " + localizer.Get("Exit"));
        Console.WriteLine();

        int optionCount = optionIndex;
        int choice = ReadInteger(localizer.Get("ChooseOption"), 1, optionCount);

        if (choice == 1)
        {
            StartNewGame();
            return;
        }

        if (hallOfFame.HasRecords && choice == 2)
        {
            ShowHallOfFameScreen();
            return;
        }

        int settingsIndex = hallOfFame.HasRecords ? 3 : 2;
        if (choice == settingsIndex)
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
            Console.WriteLine("========== " + localizer.Get("SettingsTitle") + " ==========");
            Console.WriteLine(localizer.Get("CurrentLanguage", localizer.Get(settings.Language == Language.Polish ? "Polish" : "English")));
            Console.WriteLine(localizer.Get("CurrentAskBet", settings.AskBet ? localizer.Get("Yes") : localizer.Get("No")));
            Console.WriteLine();
            Console.WriteLine("1) " + localizer.Get("ChangeLanguage"));
            Console.WriteLine("2) " + localizer.Get("ToggleAskBet"));
            Console.WriteLine("3) " + localizer.Get("ClearHallOfFame"));
            Console.WriteLine("4) " + localizer.Get("Back"));
            Console.WriteLine();

            int choice = ReadInteger(localizer.Get("ChooseOption"), 1, 4);
            if (choice == 1)
            {
                ChooseLanguage();
            }
            else if (choice == 2)
            {
                settings.AskBet = !settings.AskBet;
                settings.Save();
                Console.WriteLine(localizer.Get("AskBetChanged", settings.AskBet ? localizer.Get("Yes") : localizer.Get("No")));
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
        Console.WriteLine("========== " + localizer.Get("ChangeLanguage") + " ==========");
        Console.WriteLine("1) " + localizer.Get("Polish"));
        Console.WriteLine("2) " + localizer.Get("English"));
        Console.WriteLine();
        int choice = ReadInteger(localizer.Get("ChooseOption"), 1, 2);
        settings.Language = choice == 1 ? Language.Polish : Language.English;
        settings.Save();
        localizer.SetLanguage(settings.Language);
        Console.WriteLine(localizer.Get("LanguageChanged", localizer.Get(settings.Language == Language.Polish ? "Polish" : "English")));
        Pause();
    }

    private void ClearHallOfFame()
    {
        Console.WriteLine(localizer.Get("ConfirmClearHallOfFame"));
        Console.WriteLine("1) " + localizer.Get("Yes"));
        Console.WriteLine("2) " + localizer.Get("No"));
        int choice = ReadInteger(localizer.Get("ChooseOption"), 1, 2);
        if (choice == 1)
        {
            hallOfFame.Clear();
            hallOfFame.Save();
            Console.WriteLine(localizer.Get("HallOfFameCleared"));
            Pause();
        }
    }

    private void StartNewGame()
    {
        localizer.SetLanguage(settings.Language);
        Console.Clear();
        Console.WriteLine("========== " + localizer.Get("NewGameTitle") + " ==========");
        Console.WriteLine("1) " + localizer.Get("StandardGame"));
        Console.WriteLine("2) " + localizer.Get("NewGamePlus"));
        Console.WriteLine("3) " + localizer.Get("Back"));
        Console.WriteLine();

        int choice = ReadInteger(localizer.Get("ChooseOption"), 1, 3);
        if (choice == 3)
        {
            return;
        }

        Difficulty difficulty = ChooseDifficulty();
        if (difficulty == Difficulty.None)
        {
            return;
        }

        ScoreEntry? entry = null;
        if (choice == 1)
        {
            var game = new GuessNumberGame(settings, localizer);
            entry = game.Play(difficulty);
        }
        else
        {
            var game = new NewGamePlus(settings, localizer);
            entry = game.Play(difficulty);
        }

        if (entry != null)
        {
            hallOfFame.Add(entry);
            hallOfFame.Save();
            Console.WriteLine();
            Console.WriteLine(localizer.Get("ResultSaved"));
            Pause();
        }
    }

    private Difficulty ChooseDifficulty()
    {
        Console.WriteLine();
        Console.WriteLine(localizer.Get("ChooseDifficulty"));
        Console.WriteLine("1) " + localizer.Get("Easy"));
        Console.WriteLine("2) " + localizer.Get("Medium"));
        Console.WriteLine("3) " + localizer.Get("Hard"));
        Console.WriteLine("4) " + localizer.Get("Back"));
        Console.WriteLine();
        int choice = ReadInteger(localizer.Get("ChooseOption"), 1, 4);
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
            Console.WriteLine("========== " + localizer.Get("HallOfFameTitle") + " ==========");
            if (!hallOfFame.HasRecords)
            {
                Console.WriteLine(localizer.Get("NoRecords"));
                Pause();
                return;
            }

            Console.WriteLine(localizer.Get("ChooseDifficulty"));
            Console.WriteLine("1) " + localizer.Get("Easy"));
            Console.WriteLine("2) " + localizer.Get("Medium"));
            Console.WriteLine("3) " + localizer.Get("Hard"));
            Console.WriteLine("4) " + localizer.Get("Back"));
            Console.WriteLine();
            int choice = ReadInteger(localizer.Get("ChooseOption"), 1, 4);
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
            Console.WriteLine("========== " + localizer.Get("HallOfFameTitle") + " - " + localizer.Get(difficulty.ToString()) + " ==========");
            var top = hallOfFame.GetTopForDifficulty(difficulty, 5);
            if (top.Count == 0)
            {
                Console.WriteLine(localizer.Get("NoRecordsForDifficulty"));
            }
            else
            {
                for (int index = 0; index < top.Count; index++)
                {
                    var entry = top[index];
                    string highlight = entry.NewGamePlus ? localizer.Get("NewGamePlusHighlight") : string.Empty;
                    Console.WriteLine($"{index + 1}. {entry.PlayerName} - {entry.Attempts} {localizer.Get("Attempts")} - {entry.DurationSeconds:F1} {localizer.Get("Seconds")} {highlight}");
                }
            }

            Console.WriteLine();
            Console.WriteLine(localizer.Get("PressAnyKey"));
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
