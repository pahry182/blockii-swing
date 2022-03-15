using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectPanelController : MonoBehaviour
{
    public Image[] progressBars;
    public TextMeshProUGUI[] textMeshPros;

    private void Start()
    {
        UpdateProgress();
    }

    private void UpdateProgress()
    {
        for (int i = 0; i < textMeshPros.Length; i++)
        {
            progressBars[i].fillAmount = (float)(GameManager.Instance.data.GetStageProgress(i + 1)) / 100;
            textMeshPros[i].text = GameManager.Instance.data.GetStageProgress(i + 1) + "%";
        }
    }
}
