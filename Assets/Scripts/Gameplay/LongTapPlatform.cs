using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongTapPlatform : MonoBehaviour
{
    private GameObject platform;

    private void Awake()
    {
        
    }

    private void OnMouseDown()
    {
        platform = CallPlatform();
    }

    private void OnMouseUp()
    {
        Destroy(platform);
    }

    private GameObject CallPlatform()
    {
        GameObject[] platforms = GameManager.Instance.placedPlatforms;
        Vector3 worldPosition = transform.position;
        worldPosition.y = -1.2f;
        return Instantiate(platforms[1], worldPosition, Quaternion.identity);
    }
}
