using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVfx : MonoBehaviour
{
    public GameObject VFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(SetVFX());
    }

    public IEnumerator SetVFX()
    {
        VFX.SetActive(true);
        yield return new WaitForSeconds(2f);
        VFX.SetActive(false);
    }
}
