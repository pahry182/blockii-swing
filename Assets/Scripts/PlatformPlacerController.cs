using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformPlacerController : MonoBehaviour, IPointerDownHandler
{
    private Vector3 worldPosition;

    private GameObject[] platforms;
    private Transform parent;

    private int maxCount;

    private void Awake()
    {
        maxCount = GameManager.Instance.maxPlatformPlaced;
        parent = GameManager.Instance.userPlacedTransformParent;
        platforms = GameManager.Instance.placedPlatforms;
    }

    private void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (parent.childCount >= maxCount) return;

        GameManager.Instance.placedPlatformCurrentCooldown = GameManager.Instance.placedPlatformCooldown;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        print(worldPosition);
        Instantiate(platforms[0], worldPosition, Quaternion.identity, parent);
    }
}
