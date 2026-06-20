using System;

public class EnglishLanguagePack : ILanguagePack
{
    public string WelcomeTitle => "Welcome to Guess the Number 2!";
    public string NewGame => "New game";
    public string HallOfFame => "Hall of Fame";
    public string Settings => "Settings";
    public string Exit => "Exit";
    public string ChooseOption => "Choose an option:";
    public string SettingsTitle => "Settings";
    public string ChangeLanguage => "Change language";
    public string ToggleAskBet => "Toggle bet mode question";
    public string ClearHallOfFame => "Clear Hall of Fame";
    public string Back => "Back";
    public string Yes => "Yes";
    public string No => "No";
    public string ConfirmClearHallOfFame => "Are you sure you want to clear the Hall of Fame?";
    public string HallOfFameCleared => "Hall of Fame records have been cleared.";
    public string NewGameTitle => "Game mode";
    public string StandardGame => "Guess the Number 1";
    public string NewGamePlus => "New Game Plus";
    public string ChooseDifficulty => "Choose a difficulty:";
    public string Easy => "Easy (1-50)";
    public string Medium => "Medium (1-100)";
    public string Hard => "Hard (1-250)";
    public string HallOfFameTitle => "Hall of Fame";
    public string NoRecords => "No saved results.";
    public string NoRecordsForDifficulty => "No records for this difficulty.";
    public string Attempts => "attempts";
    public string Seconds => "seconds";
    public string PressAnyKey => "Press any key to continue...";
    public string InvalidOption => "Invalid value. Try again.";
    public string EnterBetMaxAttempts => "Enter the maximum number of attempts:";
    public string AskBetQuestion => "Do you want to play with bet mode?";
    public string EnterGuessPrompt => "Enter your guess:";
    public string OutOfAttempts => "You did not guess the number within the allotted attempts.";
    public string WonMessage => "Congratulations! You guessed the number.";
    public string EnterPlayerName => "Enter your name:";
    public string ResultSaved => "Result has been saved to the Hall of Fame.";
    public string NewGamePlusHighlight => "[New Game Plus]";
    public string SecretReshuffled => "The hidden number has been reshuffled!";
    public string NoRecordsYetHint => "Results will appear after playing at least one game.";

    public string CurrentSettings(string lang, string bet) => $"Current settings: language={lang}, bet mode={bet}";
    public string CurrentLanguage(string lang) => $"Language: {lang}";
    public string CurrentAskBet(string bet) => $"Ask bet mode: {bet}";
    public string AskBetChanged(string bet) => $"Ask bet mode is now: {bet}";
    public string LanguageChanged(string lang) => $"Language changed to: {lang}";
    public string AttemptNumber(int attempt) => $"Current attempt: {attempt}";
    public string TimeResult(double seconds) => $"Game time: {seconds:F1} seconds.";

    public string[] LowGuessMessages => new[]
    {
        "Your guess is still too low.",
        "You picked a number that is too small.",
        "Try higher.",
        "Too low, go higher.",
        "I am waiting for a larger number."
    };

    public string[] HighGuessMessages => new[]
    {
        "Your guess is too high.",
        "You picked a number that is too large.",
        "Try lower.",
        "Too much, go lower.",
        "I am waiting for a smaller number."
    };
}