using System;

public class PolishLanguagePack : ILanguagePack
{
    public string WelcomeTitle => "Witaj w Zgadnij liczbę 2!";
    public string NewGame => "Nowa gra";
    public string HallOfFame => "Hall of Fame";
    public string Settings => "Ustawienia";
    public string Exit => "Wyjście";
    public string ChooseOption => "Wybierz opcję:";
    public string SettingsTitle => "Ustawienia";
    public string ChangeLanguage => "Zmień język";
    public string ToggleAskBet => "Przełącz pytanie o tryb zakładu";
    public string ClearHallOfFame => "Wyczyść Hall of Fame";
    public string Back => "Powrót";
    public string Yes => "Tak";
    public string No => "Nie";
    public string ConfirmClearHallOfFame => "Czy na pewno chcesz wyczyścić Hall of Fame?";
    public string HallOfFameCleared => "Lista rekordów została wyczyszczona.";
    public string NewGameTitle => "Tryb gry";
    public string StandardGame => "Zgadnij liczbę 1";
    public string NewGamePlus => "Nowa gra plus";
    public string ChooseDifficulty => "Wybierz poziom trudności:";
    public string Easy => "Łatwy (1-50)";
    public string Medium => "Średni (1-100)";
    public string Hard => "Trudny (1-250)";
    public string HallOfFameTitle => "Hall of Fame";
    public string NoRecords => "Brak zapisanych wyników.";
    public string NoRecordsForDifficulty => "Brak wyników dla tego poziomu trudności.";
    public string Attempts => "prób";
    public string Seconds => "sekund";
    public string PressAnyKey => "Naciśnij dowolny klawisz, aby kontynuować...";
    public string InvalidOption => "Nieprawidłowa wartość. Spróbuj ponownie.";
    public string EnterBetMaxAttempts => "Podaj maksymalną liczbę prób:";
    public string AskBetQuestion => "Czy chcesz grać w trybie zakładu?";
    public string EnterGuessPrompt => "Podaj swoją liczbę:";
    public string OutOfAttempts => "Nie udało się trafić w wyznaczonej liczbie prób.";
    public string WonMessage => "Gratulacje! Trafiłeś liczbę.";
    public string EnterPlayerName => "Podaj swoje imię:";
    public string ResultSaved => "Wynik został zapisany do Hall of Fame.";
    public string NewGamePlusHighlight => "[Nowa gra plus]";
    public string SecretReshuffled => "Ukryta liczba została przelosowana!";
    public string NoRecordsYetHint => "Wyniki pojawią się po rozegraniu przynajmniej jednej gry.";

    public string CurrentSettings(string lang, string bet) => $"Aktualne ustawienia: język={lang}, tryb zakładu={bet}";
    public string CurrentLanguage(string lang) => $"Język: {lang}";
    public string CurrentAskBet(string bet) => $"Tryb zakładu: {bet}";
    public string AskBetChanged(string bet) => $"Pytanie o tryb zakładu ustawione na: {bet}";
    public string LanguageChanged(string lang) => $"Język zmieniony na: {lang}";
    public string AttemptNumber(int attempt) => $"Aktualna próba: {attempt}";
    public string TimeResult(double seconds) => $"Czas gry: {seconds:F1} sekund.";

    public string[] LowGuessMessages => new[]
    {
        "Twoja liczba nadal jest za mała.",
        "Wybrałeś zbyt małą wartość.",
        "Spróbuj wyżej.",
        "Za mało, idź wyżej.",
        "Czekam na większą liczbę."
    };

    public string[] HighGuessMessages => new[]
    {
        "Twoja liczba jest za duża.",
        "Wybrałeś zbyt wysoką wartość.",
        "Spróbuj niżej.",
        "Za dużo, idź niżej.",
        "Czekam na mniejszą liczbę."
    };
}