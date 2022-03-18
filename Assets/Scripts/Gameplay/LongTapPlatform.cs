using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongTapPlatform : MonoBehaviour
{
    private GameObject platform;
    [SerializeField] private SpriteRenderer _sr;

    private void Awake()
    {
        
    }

    private void OnMouseDown()
    {
        platform = CallPlatform();
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0.10f);
    }

    private void OnMouseUp()
    {
        Destroy(platform);
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0.35f);
    }

    private GameObject CallPlatform()
    {
        GameObject[] platforms = GameManager.Instance.placedPlatforms;
        Vector3 worldPosition = transform.position;
        worldPosition.y = -1.2f;
        return Instantiate(platforms[1], worldPosition, Quaternion.identity);
    }
}
