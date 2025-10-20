using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;
    public List<Button> buttons;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI TitleText;
    public int score;
    public bool gameActive = true;
    public Button restartButton;
    private float spawnRate = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameActive = false;
    }
    public void StartGame(float difficulty)
    {
        TitleText.gameObject.SetActive(false);
        for (int x=0; x < buttons.Count; x++)
        {
            buttons[x].gameObject.SetActive(false);
        }
        gameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        spawnRate /= difficulty;
    }
        // Function that restarts the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        // Function that stops the game
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameActive = false;
        restartButton.gameObject.SetActive(true);
    }
        // Funtion that add the score and put it on the screen
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
        // Co-rutin that spawn objects per time
    IEnumerator SpawnTarget() {
        while (gameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
