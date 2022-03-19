using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSceneController : UIController
{
    [SerializeField] private CanvasGroup menuPanel, selectLevelPanel, settingPanel, creditsPanel, guidePanel, skinPanel;
    [SerializeField] private Slider volumeSlider, cameraSlider;

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
        volumeSlider.value = GameManager.Instance.setting.BgmVolume;
        cameraSlider.value = GameManager.Instance.cameraOffset;
        Time.timeScale = 1f;
    }

    public void buttonStart()
    {
        StartCoroutine(SmoothFadeTransition(menuPanel, selectLevelPanel, 0.2f));
    }

    public void buttonBack()
    {
        StartCoroutine(SmoothFadeTransition(selectLevelPanel, menuPanel, 0.2f));
    }

    public void settingButton()
    {
        StartCoroutine(SmoothFadeTransition(menuPanel, settingPanel, 0.2f));
    }

    public void backSettingButton()
    {
        StartCoroutine(SmoothFadeTransition(settingPanel, menuPanel, 0.2f));
    }

    public void creditsButton()
    {
        StartCoroutine(SmoothFadeTransition(settingPanel, creditsPanel, 0.2f));
    }

    public void backCreditsButton()
    {
        StartCoroutine(SmoothFadeTransition(creditsPanel, settingPanel, 0.2f));
    }

    public void guideButton()
    {
        StartCoroutine(SmoothFadeTransition(settingPanel, guidePanel, 0.2f));
    }

    public void backGuideButton()
    {
        StartCoroutine(SmoothFadeTransition(guidePanel, settingPanel, 0.2f));
    }

    public void SkinButton()
    {
        StartCoroutine(SmoothFadeTransition(menuPanel, skinPanel, 0.2f));
    }

    public void BackSkinButton()
    {
        StartCoroutine(SmoothFadeTransition(skinPanel, menuPanel, 0.2f));
    }

    public void OnChangeVolume()
    {
        GameManager.Instance.setting.BgmVolume = volumeSlider.value;
        GameManager.Instance.setting.SfxVolume = volumeSlider.value;
        GameManager.Instance.UpdateVolume();
    }

    public void OnChangeCamera()
    {
        GameManager.Instance.cameraOffset = cameraSlider.value;
    }
}
