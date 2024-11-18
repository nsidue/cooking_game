using UnityEngine;
using TMPro;

public class PlayerSurvival : MonoBehaviour
{
    public TMP_Text healthText;        // Reference to the Health UI Text
    public TMP_Text collectiblesText; // Reference to the Collectibles UI Text
    public TMP_Text timerText;        // Reference to the Timer UI Text

    public int maxHealth = 100;       // Maximum player health
    public int currentHealth;         // Current player health
    public int collectiblesNeeded = 15; // Number of collectibles required to win
    public float timeRemaining = 120f; // Timer for the level

    private int currentCollectibles = 0; // Number of collectibles currently obtained
    private bool isAlive = true;

    void Awake()
    {
        // Initialize health and update HUD at the start of the game
        currentHealth = maxHealth;
        UpdateHUD();
    }

    void Update()
    {
        if (!isAlive) return;

        // Countdown timer
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            GameOver("Time ran out!");
        }

        UpdateHUD();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= Mathf.RoundToInt(damage);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameOver("Player health depleted!");
        }
    }

    public void CollectItem()
    {
        currentCollectibles++;
        if (currentCollectibles >= collectiblesNeeded)
        {
            LevelComplete();
        }
    }

    void UpdateHUD()
    {
        // Update the UI elements in the HUD
        if (healthText != null)
            healthText.text = "Health: " + currentHealth;

        if (collectiblesText != null)
            collectiblesText.text = "Materials: " + currentCollectibles + "/" + collectiblesNeeded;

        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining) + "s";
    }

    void GameOver(string message)
    {
        isAlive = false;
        Debug.Log(message);
        // Implement game-over logic (e.g., display Game Over UI)
    }

    void LevelComplete()
    {
        isAlive = false;
        Debug.Log("Level Complete!");
        // Implement level-complete logic (e.g., display Level Complete UI)
    }
}
