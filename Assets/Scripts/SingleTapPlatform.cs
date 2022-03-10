using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SingleTapPlatform : MonoBehaviour
{
    private Vector3 worldPosition;
    private Vector3 upPos;

    private GameObject[] platforms;

    private int maxCount;
    private float currentCd;

    private void Start()
    {
        maxCount = GameManager.Instance.maxPlatformPlaced;
        platforms = GameManager.Instance.placedPlatforms;
    }

    private void Update()
    {
        if (currentCd > 0)
            currentCd -= Time.deltaTime;
    }

    private void OnMouseDown()
    {
        if (currentCd > 0) return;
        currentCd = GameManager.Instance.placedPlatformCooldown;
        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = Camera.main.nearClipPlane;
        //worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        worldPosition = transform.position;
        worldPosition.y = -1.2f;
        Instantiate(platforms[0], worldPosition, Quaternion.identity);
    }
}
