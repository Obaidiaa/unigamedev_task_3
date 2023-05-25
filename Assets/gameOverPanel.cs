using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameOverPanel : MonoBehaviour
{




    public TextMeshProUGUI scoreText;

    public void RestartGame()
    {
        // Reload the current scene
        // Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }


    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }

    public void setup(int score)
    {
        gameObject.SetActive(true);
        Debug.Log("game over panel setup");
        scoreText.text = "Score: " + score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
