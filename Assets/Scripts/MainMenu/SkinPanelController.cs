using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinPanelController : MonoBehaviour
{
    [SerializeField] private Image displaySkin;

    private void OnEnable()
    {
        UpdateDisplay();
    }

    public void GetSkin(string skinId)
    {
        Sprite skin = Resources.Load<Sprite>("Skins/" + skinId);
        GameManager.Instance.currentUsedSkin = skin;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        displaySkin.sprite = GameManager.Instance.currentUsedSkin;
    }
}
