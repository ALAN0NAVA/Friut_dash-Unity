using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    float gameDifficulty;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetDifficulty()
    {

        if (gameObject.CompareTag("EASY")) gameDifficulty = 1;
        if (gameObject.CompareTag("MEDIUM")) gameDifficulty = 2;
        if (gameObject.CompareTag("HARD")) gameDifficulty = 2.5f;
        gameManager.StartGame(gameDifficulty);
        //if(gameObject.CompareTag())
    }
}
