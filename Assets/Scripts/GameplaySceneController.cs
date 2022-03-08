using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplaySceneController : UIController
{
    public CanvasGroup mainPanel, ingamePanel, losePanel;
    public TextMeshProUGUI scoreText, loseScoreText;

    private void Update()
    {
        if (Input.anyKeyDown &&
            !Input.GetKeyDown(KeyCode.Escape) &&
            !GameManager.Instance.isStarted && 
            !GameManager.Instance.isLost)
        {
            GameManager.Instance.isLost = false;
            GameManager.Instance.isStarted = true;
            StartCoroutine(SmoothFadeTransition(mainPanel, ingamePanel, 0.15f));
        }

        if (GameManager.Instance.isLost && GameManager.Instance.isStarted)
        {
            GameManager.Instance.isStarted = false;
            StartCoroutine(SmoothFadeTransition(ingamePanel, losePanel, 0.15f));
            loseScoreText.text = "Score : " + ((int)GameManager.Instance.Score).ToString();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space) && GameManager.Instance.isLost)
        {
            Restart();
        }

        scoreText.text = "Score : " + ((int)GameManager.Instance.Score).ToString();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
