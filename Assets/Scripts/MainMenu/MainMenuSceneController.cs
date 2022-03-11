using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneController : UIController
{
    [SerializeField] private GameObject menuPanel, selectLevelPanel;

    private void Start()
    {
        menuPanel.SetActive(true);
        selectLevelPanel.SetActive(false);
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

    }

    public void backSettingButton()
    {

    }

    public void skinButton()
    {

    }

    public void backSkinButton()
    {

    }
}
