using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControllerUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreRecord;
    public TextMeshProUGUI monets;

    [SerializeField] private GameObject menuGame;
   
    private GameManager gameManager;

    private void Awake()
    {
        menuGame.SetActive(true);
    }
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        OutputScore();
    }
    public void ButtonStartGame()
    {
        menuGame.SetActive(false);
        gameManager.StartGame();
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void OutputScore()
    {
        scoreText.text = "Score: " + GameManager.score.ToString();
        scoreRecord.text = "Record: " + GameManager.scoreRecord.ToString();
        monets.text = "Monets: " + GameManager.monets.ToString();
    }
}
