using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTD : MonoBehaviour
{
    private GameplaySceneController _gsc;

    private void Awake()
    {
        _gsc = FindObjectOfType<GameplaySceneController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _gsc.SpawnTextDisplay();
        }
    }
}
