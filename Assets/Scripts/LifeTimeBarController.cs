using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeBarController : MonoBehaviour
{
    private Vector3 localScale;
    private float defaultX;
    private float currentDuration;
    private float maxDuration;

    void Start()
    {
        maxDuration = GameManager.Instance.placedPlatformDuration;
        currentDuration = GameManager.Instance.placedPlatformDuration;
        localScale = transform.localScale;
        defaultX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDuration <= 0)
        {
            localScale.x = 0;
            Destroy(transform.parent.gameObject);
        }
        currentDuration -= Time.deltaTime;
        localScale.x = defaultX * (currentDuration / maxDuration);
        transform.localScale = localScale;
    }
}
