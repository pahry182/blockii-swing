using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplaySceneController : UIController
{
    [SerializeField] private Image progressBar;
    private Transform playerPos;

    public GameObject[] textDisplayFX;

    public CanvasGroup mainPanel, ingamePanel, resultPanel;
    public TextMeshProUGUI scoreText, loseScoreText, resultText;

    public int stage;
    public float levelPlatformDuration;
    public float levelProgress;
    public float currentLevelProgress;
    public float highestLevelProgress;

    private float maxFinishPosition;

    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        maxFinishPosition = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>().position.x;
        //progressBar.minValue = playerPos.position.x;
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
            progressBar.fillAmount = playerPos.position.x / maxFinishPosition; 
        }
        
    }

    public void RestartGame()
    {
        GameManager.Instance.PlaySfx("Button");
        GameManager.Instance.isLost = false;
        GameManager.Instance.isStarted = false;
        GameManager.Instance.StopBgm();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        GameManager.Instance.PlaySfx("Button");
        Time.timeScale = 1f;
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
        int result = (int)((progressBar.fillAmount) * 100);
        resultText.text = result + "%";
        GameManager.Instance.data.SetStageProgress(stage, result);
        StartCoroutine(SmoothFadeTransition(ingamePanel, resultPanel, 0.15f));
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        GameManager.Instance.PlaySfx("Win");
        GameManager.Instance.isStarted = false;
        GameManager.Instance.StopBgm();
        resultText.text = "100%";
        GameManager.Instance.data.SetStageProgress(stage, 100);
        StartCoroutine(SmoothFadeTransition(ingamePanel, resultPanel, 0.15f));
    }

    public void MenuButtonSFX()
    {
        GameManager.Instance.PlaySfx("Button");
    }

    public void SpawnTextDisplay()
    {
        StartCoroutine(SetTextDisplay());
    }
    private IEnumerator SetTextDisplay()
    {
        int random = Random.Range(0, textDisplayFX.Length);

        textDisplayFX[random].SetActive(true);
        yield return new WaitForSeconds(5f);
        textDisplayFX[random].SetActive(false);
    }
}
