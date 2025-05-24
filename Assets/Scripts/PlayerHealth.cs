using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100;
    public Scrollbar HealthScroll;

    [SerializeField] private GameObject gameOverScreen;

    private bool isGameOver = false;

    public void TakeDamage(int damage)
    {
        if (isGameOver) return;

        Health -= damage;
        HealthScroll.size = Health / 100f;

        if (Health <= 0)
        {
            Health = 0;
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        isGameOver = true;

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("GameOver screen is not assigned in PlayerHealth!");
        }
    }
}

