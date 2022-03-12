using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneController : UIController
{
    [SerializeField] private GameObject menuPanel, selectLevelPanel, settingPanel, creditsPanel, guidePanel;

    private void Start()
    {
        menuPanel.SetActive(true);
        selectLevelPanel.SetActive(false);
        settingPanel.SetActive(false);
        creditsPanel.SetActive(false);
        guidePanel.SetActive(false);
    }

    public void buttonStart()
    {
        menuPanel.SetActive(false);
        selectLevelPanel.SetActive(true);
    }

    public void buttonBack()
    {
        menuPanel.SetActive(true);
        selectLevelPanel.SetActive(false);
    }

    public void settingButton()
    {
        settingPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void backSettingButton()
    {
        settingPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void creditsButton()
    {
        creditsPanel.SetActive(true);
        settingPanel.SetActive(false);
    }

    public void backCreditsButton()
    {
        creditsPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void guideButton()
    {
        guidePanel.SetActive(true);
        settingPanel.SetActive(false);
    }

    public void backGuideButton()
    {
        guidePanel.SetActive(false);
        settingPanel.SetActive(true);
    }
}
