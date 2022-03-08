using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformPlacerController : MonoBehaviour, IPointerDownHandler
{
    private Vector3 worldPosition;

    public GameObject[] platforms;

    private void Update()
    {
        
    }

    public void OnMouseDown()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        print(worldPosition);
        Destroy(Instantiate(platforms[0], worldPosition, Quaternion.identity), 2);
    }
}
