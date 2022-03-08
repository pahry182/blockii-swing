using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.PlaySfx("PlayerDie");
            Time.timeScale = 0f;
            GameManager.Instance.isLost = true;
        }
    }
}
