using System;

public interface ILanguagePack
{
    string WelcomeTitle { get; }
    string NewGame { get; }
    string HallOfFame { get; }
    string Settings { get; }
    string Exit { get; }
    string ChooseOption { get; }
    string SettingsTitle { get; }
    string ChangeLanguage { get; }
    string ToggleAskBet { get; }
    string ClearHallOfFame { get; }
    string Back { get; }
    string Yes { get; }
    string No { get; }
    string ConfirmClearHallOfFame { get; }
    string HallOfFameCleared { get; }
    string NewGameTitle { get; }
    string StandardGame { get; }
    string NewGamePlus { get; }
    string ChooseDifficulty { get; }
    string Easy { get; }
    string Medium { get; }
    string Hard { get; }
    string HallOfFameTitle { get; }
    string NoRecords { get; }
    string NoRecordsForDifficulty { get; }
    string Attempts { get; }
    string Seconds { get; }
    string PressAnyKey { get; }
    string InvalidOption { get; }
    string EnterBetMaxAttempts { get; }
    string AskBetQuestion { get; }
    string EnterGuessPrompt { get; }
    string OutOfAttempts { get; }
    string WonMessage { get; }
    string EnterPlayerName { get; }
    string ResultSaved { get; }
    string NewGamePlusHighlight { get; }
    string SecretReshuffled { get; }
    string NoRecordsYetHint { get; }

    // Metody z parametrami zastępujące podatne na błędy string.Format
    string CurrentSettings(string lang, string bet);
    string CurrentLanguage(string lang);
    string CurrentAskBet(string bet);
    string AskBetChanged(string bet);
    string LanguageChanged(string lang);
    string AttemptNumber(int attempt);
    string TimeResult(double seconds);

    // Listy losowych komunikatów
    string[] LowGuessMessages { get; }
    string[] HighGuessMessages { get; }
}