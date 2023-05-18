using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance of the GameManager

    public GameObject player; // Reference to the player object
    public TextMeshProUGUI scoreText; // Reference to the UI text displaying the score
    // public GameObject gameOverPanel; // Reference to the UI panel displaying the game over screen

    private int score; // Current score

    private bool isGameOver; // Flag to track if the game is over

    private float respawnRate = 10f;
    private float gameSpeed = 1f;

    public float RespawnRate
    {
        get { return respawnRate; }
        set { respawnRate = value; }
    }
    public float GameSpeed
    {
        get { return gameSpeed; }
        set { gameSpeed = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        isGameOver = false;
        score = 0;
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {

        if (score == 500)
        {
            GameSpeed = GameSpeed + 0.5f;
            if (respawnRate > 2)
            {
                Debug.Log("RespawnRate " + RespawnRate);
                RespawnRate = respawnRate - 1f;
            }

        }
        else if (score >= 1000)
        {
            GameSpeed = GameSpeed + 0.5f;
            if (respawnRate > 2)
            {
                Debug.Log("RespawnRate " + RespawnRate);
                RespawnRate = respawnRate - 1f;
            }

        }
        else if (score >= 1500)
        {
            GameSpeed = GameSpeed + 0.5f;
            if (respawnRate > 2)
            {
                Debug.Log("RespawnRate " + RespawnRate);
                RespawnRate = respawnRate - 1f;
            }

        }




        Debug.Log("score increased by " + amount.ToString() + " points");
        if (!isGameOver)
        {
            score += amount;
            UpdateScoreText();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        // gameOverPanel.SetActive(true);
        // You can add more game over logic here, such as stopping the player movement, playing a sound effect, etc.
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
