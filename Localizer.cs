using System;
using System.Collections.Generic;

public class Localizer
{
    private Language language;
    private readonly Dictionary<string, string> translationsPl = new()
    {
        { "WelcomeTitle", "Witaj w Zgadnij liczbę 2!" },
        { "CurrentSettings", "Aktualne ustawienia: język={0}, tryb zakładu={1}" },
        { "NewGame", "Nowa gra" },
        { "HallOfFame", "Hall of Fame" },
        { "Settings", "Ustawienia" },
        { "Exit", "Wyjście" },
        { "ChooseOption", "Wybierz opcję:" },
        { "SettingsTitle", "Ustawienia" },
        { "CurrentLanguage", "Język: {0}" },
        { "CurrentAskBet", "Tryb zakładu: {0}" },
        { "ChangeLanguage", "Zmień język" },
        { "ToggleAskBet", "Przełącz pytanie o tryb zakładu" },
        { "ClearHallOfFame", "Wyczyść Hall of Fame" },
        { "Back", "Powrót" },
        { "Yes", "Tak" },
        { "No", "Nie" },
        { "AskBetChanged", "Pytanie o tryb zakładu ustawione na: {0}" },
        { "ConfirmClearHallOfFame", "Czy na pewno chcesz wyczyścić Hall of Fame?" },
        { "HallOfFameCleared", "Lista rekordów została wyczyszczona." },
        { "LanguageChanged", "Język zmieniony na: {0}" },
        { "NewGameTitle", "Tryb gry" },
        { "StandardGame", "Zgadnij liczbę 1" },
        { "NewGamePlus", "Nowa gra plus" },
        { "ChooseDifficulty", "Wybierz poziom trudności:" },
        { "Easy", "Łatwy (1-50)" },
        { "Medium", "Średni (1-100)" },
        { "Hard", "Trudny (1-250)" },
        { "HallOfFameTitle", "Hall of Fame" },
        { "NoRecords", "Brak zapisanych wyników." },
        { "NoRecordsForDifficulty", "Brak wyników dla tego poziomu trudności." },
        { "Attempts", "prób" },
        { "Seconds", "sekund" },
        { "PressAnyKey", "Naciśnij dowolny klawisz, aby kontynuować..." },
        { "InvalidOption", "Nieprawidłowa wartość. Spróbuj ponownie." },
        { "EnterBetMaxAttempts", "Podaj maksymalną liczbę prób:" },
        { "AskBetQuestion", "Czy chcesz grać w trybie zakładu?" },
        { "EnterGuessPrompt", "Podaj swoją liczbę:" },
        { "AttemptNumber", "Aktualna próba: {0}" },
        { "OutOfAttempts", "Nie udało się trafić w wyznaczonej liczbie prób." },
        { "GuessTooLow", "Twoja liczba jest za mała." },
        { "GuessTooHigh", "Twoja liczba jest za duża." },
        { "WonMessage", "Gratulacje! Trafiłeś liczbę." },
        { "EnterPlayerName", "Podaj swoje imię:" },
        { "TimeResult", "Czas gry: {0:F1} sekund." },
        { "ResultSaved", "Wynik został zapisany do Hall of Fame." },
        { "NewGamePlusHighlight", "[Nowa gra plus]" },
        { "SecretReshuffled", "Ukryta liczba została przelosowana!" },
        { "NoRecordsYetHint", "Wyniki pojawią się po rozegraniu przynajmniej jednej gry." }
    };

    private readonly Dictionary<string, string> translationsEn = new()
    {
        { "WelcomeTitle", "Welcome to Guess the Number 2!" },
        { "CurrentSettings", "Current settings: language={0}, bet mode={1}" },
        { "NewGame", "New game" },
        { "HallOfFame", "Hall of Fame" },
        { "Settings", "Settings" },
        { "Exit", "Exit" },
        { "ChooseOption", "Choose an option:" },
        { "SettingsTitle", "Settings" },
        { "CurrentLanguage", "Language: {0}" },
        { "CurrentAskBet", "Ask bet mode: {0}" },
        { "ChangeLanguage", "Change language" },
        { "ToggleAskBet", "Toggle bet mode question" },
        { "ClearHallOfFame", "Clear Hall of Fame" },
        { "Back", "Back" },
        { "Yes", "Yes" },
        { "No", "No" },
        { "AskBetChanged", "Ask bet mode is now: {0}" },
        { "ConfirmClearHallOfFame", "Are you sure you want to clear the Hall of Fame?" },
        { "HallOfFameCleared", "Hall of Fame records have been cleared." },
        { "LanguageChanged", "Language changed to: {0}" },
        { "NewGameTitle", "Game mode" },
        { "StandardGame", "Guess the Number 1" },
        { "NewGamePlus", "New Game Plus" },
        { "ChooseDifficulty", "Choose a difficulty:" },
        { "Easy", "Easy (1-50)" },
        { "Medium", "Medium (1-100)" },
        { "Hard", "Hard (1-250)" },
        { "HallOfFameTitle", "Hall of Fame" },
        { "NoRecords", "No saved results." },
        { "NoRecordsForDifficulty", "No records for this difficulty." },
        { "Attempts", "attempts" },
        { "Seconds", "seconds" },
        { "PressAnyKey", "Press any key to continue..." },
        { "InvalidOption", "Invalid value. Try again." },
        { "EnterBetMaxAttempts", "Enter the maximum number of attempts:" },
        { "AskBetQuestion", "Do you want to play with bet mode?" },
        { "EnterGuessPrompt", "Enter your guess:" },
        { "AttemptNumber", "Current attempt: {0}" },
        { "OutOfAttempts", "You did not guess the number within the allotted attempts." },
        { "GuessTooLow", "Your guess is too low." },
        { "GuessTooHigh", "Your guess is too high." },
        { "WonMessage", "Congratulations! You guessed the number." },
        { "EnterPlayerName", "Enter your name:" },
        { "TimeResult", "Game time: {0:F1} seconds." },
        { "ResultSaved", "Result has been saved to the Hall of Fame." },
        { "NewGamePlusHighlight", "[New Game Plus]" },
        { "SecretReshuffled", "The hidden number has been reshuffled!" },
        { "NoRecordsYetHint", "Results will appear after playing at least one game." }
    };

    private static readonly List<string> lowGuessMessagesPl = new()
    {
        "Twoja liczba nadal jest za mała.",
        "Wybrałeś zbyt małą wartość.",
        "Spróbuj wyżej.",
        "Za mało, idź wyżej.",
        "Czekam na większą liczbę."
    };

    private static readonly List<string> highGuessMessagesPl = new()
    {
        "Twoja liczba jest za duża.",
        "Wybrałeś zbyt wysoką wartość.",
        "Spróbuj niżej.",
        "Za dużo, idź niżej.",
        "Czekam na mniejszą liczbę."
    };

    private static readonly List<string> lowGuessMessagesEn = new()
    {
        "Your guess is still too low.",
        "You picked a number that is too small.",
        "Try higher.",
        "Too low, go higher.",
        "I am waiting for a larger number."
    };

    private static readonly List<string> highGuessMessagesEn = new()
    {
        "Your guess is too high.",
        "You picked a number that is too large.",
        "Try lower.",
        "Too much, go lower.",
        "I am waiting for a smaller number."
    };

    public Localizer(Language language)
    {
        this.language = language;
    }

    public void SetLanguage(Language language)
    {
        this.language = language;
    }

    public string Get(string key)
    {
        var dictionary = language == Language.Polish ? translationsPl : translationsEn;
        if (dictionary.TryGetValue(key, out var value))
        {
            return value;
        }

        return key;
    }

    public string Get(string key, params object[] args)
    {
        return string.Format(Get(key), args);
    }

    public string GetRandomGuessMessage(int guess, int target)
    {
        var random = new Random();
        if (guess < target)
        {
            var messages = language == Language.Polish ? lowGuessMessagesPl : lowGuessMessagesEn;
            return messages[random.Next(messages.Count)];
        }

        var highMessages = language == Language.Polish ? highGuessMessagesPl : highGuessMessagesEn;
        return highMessages[random.Next(highMessages.Count)];
    }
}
