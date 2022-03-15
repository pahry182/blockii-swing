using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneController : UIController
{
    [SerializeField] private CanvasGroup menuPanel, selectLevelPanel, settingPanel, creditsPanel, guidePanel, skinPanel;

    private void Awake()
    {
        menuPanel.gameObject.SetActive(true);
        selectLevelPanel.gameObject.SetActive(false);
        settingPanel.gameObject.SetActive(false);
        creditsPanel.gameObject.SetActive(false);
        guidePanel.gameObject.SetActive(false);
        skinPanel.gameObject.SetActive(false);
    }

    private void Start()
    {
        GameManager.Instance.PlayBgm("MainMenu");
    }

    public void buttonStart()
    {
        menuPanel.gameObject.SetActive(false);
        selectLevelPanel.gameObject.SetActive(true);
    }

    public void buttonBack()
    {
        menuPanel.gameObject.SetActive(true);
        selectLevelPanel.gameObject.SetActive(false);
    }

    public void settingButton()
    {
        settingPanel.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(false);
    }

    public void backSettingButton()
    {
        settingPanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(true);
    }

    public void creditsButton()
    {
        creditsPanel.gameObject.SetActive(true);
        settingPanel.gameObject.SetActive(false);
    }

    public void backCreditsButton()
    {
        creditsPanel.gameObject.SetActive(false);
        settingPanel.gameObject.SetActive(true);
    }

    public void guideButton()
    {
        guidePanel.gameObject.SetActive(true);
        settingPanel.gameObject.SetActive(false);
    }

    public void backGuideButton()
    {
        guidePanel.gameObject.SetActive(false);
        settingPanel.gameObject.SetActive(true);
    }

    public void SkinButton()
    {
        StartCoroutine(SmoothFadeTransition(menuPanel, skinPanel, 0.5f));
    }

    public void BackSkinButton()
    {
        StartCoroutine(SmoothFadeTransition(skinPanel, menuPanel, 0.5f));
    }
}
