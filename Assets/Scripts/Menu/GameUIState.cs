using UnityEngine;

public static class GameUIState
{
    public static bool MenuOpen = false;
    public static bool AboutOpen = false;
    public static bool GameOverOpen = false;
    public static bool GameStarted = false;

    public static bool IsMenuOpen => MenuOpen || AboutOpen || GameOverOpen;

    public static void OpenMenu()
    {
        MenuOpen = true;
        AboutOpen = false;
        GameOverOpen = false;
    }

    public static void OpenAbout()
    {
        MenuOpen = false;
        AboutOpen = true;
        GameOverOpen = false;
    }

    public static void OpenGameOver()
    {
        MenuOpen = false;
        AboutOpen = false;
        GameOverOpen = true;
    }

    public static void CloseAll()
    {
        MenuOpen = false;
        AboutOpen = false;
        GameOverOpen = false;
    }

    public static void StartGame()
    {
        GameStarted = true;
        CloseAll();
    }
}
