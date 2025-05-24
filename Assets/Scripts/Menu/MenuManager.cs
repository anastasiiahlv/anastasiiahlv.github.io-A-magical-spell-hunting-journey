using UnityEngine;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [Header("Canvas References")]
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas aboutCanvas;
    [SerializeField] private Canvas gameOverCanvas;

    private void Start()
    {
        ShowMenu();
        GameUIState.GameStarted = false;
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (GameUIState.IsMenuOpen)
            {
                if (GameUIState.GameOverOpen)
                {
                    return;
                }

                if (GameUIState.GameStarted)
                {
                    CloseAllMenus();
                }
            }
            else if (GameUIState.GameStarted)
            {
                ShowPauseMenu();
            }
        }
    }

    public void ShowMenu()
    {
        SetCanvasState(menuCanvas, true);
        SetCanvasState(aboutCanvas, false);
        SetCanvasState(gameOverCanvas, false);

        GameUIState.OpenMenu();
        UpdateCursorAndTime();
    }

    public void ShowAbout()
    {
        SetCanvasState(menuCanvas, false);
        SetCanvasState(aboutCanvas, true);
        SetCanvasState(gameOverCanvas, false);

        GameUIState.OpenAbout();
        UpdateCursorAndTime();
    }

    public void ShowPauseMenu()
    {
        SetCanvasState(menuCanvas, true);
        SetCanvasState(aboutCanvas, false);
        SetCanvasState(gameOverCanvas, false);

        GameUIState.OpenMenu();
        UpdateCursorAndTime();
    }

    public void ShowGameOver()
    {
        SetCanvasState(menuCanvas, false);
        SetCanvasState(aboutCanvas, false);
        SetCanvasState(gameOverCanvas, true);

        GameUIState.OpenGameOver();
        UpdateCursorAndTime();
    }

    public void CloseAllMenus()
    {
        SetCanvasState(menuCanvas, false);
        SetCanvasState(aboutCanvas, false);
        SetCanvasState(gameOverCanvas, false);

        GameUIState.CloseAll();
        UpdateCursorAndTime();
    }

    public void StartGame()
    {
        GameUIState.StartGame();
        CloseAllMenus();
    }

    public void RestartGame()
    {
        GameUIState.GameStarted = false;
        StartGame();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void SetCanvasState(Canvas canvas, bool isActive)
    {
        if (canvas != null)
        {
            canvas.gameObject.SetActive(isActive);
        }
    }

    private void UpdateCursorAndTime()
    {
        if (GameUIState.IsMenuOpen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }
}
