using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplaySceneController : UIController
{
    [SerializeField] private Slider progressBar;
    private Transform playerPos;

    public CanvasGroup mainPanel, ingamePanel, resultPanel;
    public TextMeshProUGUI scoreText, loseScoreText, resultText;

    public int stage;
    public float levelPlatformDuration;
    public float levelProgress;
    public float currentLevelProgress;
    public float highestLevelProgress;

    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        progressBar.maxValue = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>().position.x;
        progressBar.minValue = playerPos.position.x;
    }

    private void Start()
    {
        GameManager.Instance.placedPlatformDuration = levelPlatformDuration;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RestartGame(); 
        }

        if (GameManager.Instance.isStarted)
        {
            progressBar.value = playerPos.position.x;
        }
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance.isLost = false;
        GameManager.Instance.isStarted = false;
        GameManager.Instance.StopBgm();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        GameManager.Instance.isLost = false;
        GameManager.Instance.isStarted = true;
        GameManager.Instance.PlayBgm("Level" + stage);
        StartCoroutine(SmoothFadeTransition(mainPanel, ingamePanel, 0.15f));
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        GameManager.Instance.PlaySfx("PlayerDie");
        GameManager.Instance.StopBgm();
        GameManager.Instance.isLost = true;
        GameManager.Instance.isStarted = false;
        resultText.text = (int)((progressBar.value / progressBar.maxValue)*100) + "%";
        StartCoroutine(SmoothFadeTransition(ingamePanel, resultPanel, 0.15f));
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        GameManager.Instance.PlaySfx("Win");
        GameManager.Instance.isStarted = false;
        GameManager.Instance.StopBgm();
        resultText.text = "100%";
        StartCoroutine(SmoothFadeTransition(ingamePanel, resultPanel, 0.15f));
    }
}
