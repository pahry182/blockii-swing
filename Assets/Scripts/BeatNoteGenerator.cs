using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatNoteGenerator : MonoBehaviour
{
    public GameObject beatNotePrefab;
    public string[] beatCoordinates;
    public List<string> beatType;

    private const string BEATTYPE = "AR";

    private void Start()
    {
        GenerateBeatNote();
    }

    private void GenerateBeatNote()
    {
        TextAsset beatFile = Resources.Load("Beat Notes/" + SceneManager.GetActiveScene().name) as TextAsset;
        string txt = beatFile.ToString();
        char[] separators = new char[] { '\n', ',', 'A', 'R', '\r'};
        beatCoordinates = txt.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < txt.Length; i++)
        {
            if (BEATTYPE.Contains(txt[i]))
            {
                beatType.Add(txt[i].ToString());
            }
        }

        foreach (var item in beatCoordinates)
        {
            Vector2 pos = new(float.Parse(item) * MusicConductor.Instance.speedRatio, 0);
            Instantiate(beatNotePrefab, pos, Quaternion.identity);
        }
    }

}
