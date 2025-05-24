using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class CanvasSwitch : MonoBehaviour
{
    [SerializeField] private Canvas _activeCanvas;
    [SerializeField] private Canvas _nextCanvas;

    private void Awake()
    {
        CheckFields();
    }

    private void OnValidate()
    {
        CheckFields();
    }

    public void SwitchCanvas()
    {
        if (_activeCanvas == null || _nextCanvas == null)
        {
            Debug.LogError($"Active or next canvas at {this.gameObject.name} was not assigned.");
            return;
        }

        _activeCanvas.gameObject.SetActive(false);
        _nextCanvas.gameObject.SetActive(true);

        UpdateUIState(_activeCanvas, false);
        UpdateUIState(_nextCanvas, true);

    }

    public void CloseAllMenus()
    {
        GameUIState.MenuOpen = false;
        GameUIState.AboutOpen = false;
        GameUIState.GameOverOpen = false;
    }

    private void UpdateUIState(Canvas canvas, bool isActive)
    {
        switch (canvas.name)
        {
            case "Menu":
                GameUIState.MenuOpen = isActive;
                break;
            case "About":
                GameUIState.AboutOpen = isActive;
                break;
            case "GameOver":
                GameUIState.GameOverOpen = isActive;
                break;
        }
    }

    private void CheckFields()
    {
        if (_activeCanvas == null)
        {
            Debug.LogError($"Active canvas at {this.gameObject.name} was not assigned.");
            _activeCanvas = GetComponent<Canvas>();
        }
        if (_nextCanvas == null)
        {
            Debug.LogError($"Next canvas at {this.gameObject.name} was not assigned.");
        }
    }
}
