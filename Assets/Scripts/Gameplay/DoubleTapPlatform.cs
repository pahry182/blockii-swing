using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DoubleTapPlatform : MonoBehaviour
{
    [Tooltip("Max duration between 2 clicks in seconds")]
    [Range(0.01f, 0.5f)] public float doubleClickDuration = 0.4f;

    private byte clicks = 0;
    private float elapsedTime = 0f;
    private float currentCd;
    [SerializeField] private SpriteRenderer _sr;

    private void Awake()
    {
        
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (clicks == 1)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > doubleClickDuration)
            {
                clicks = 0;
                elapsedTime = 0f;
                _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0.17f);
            }
        }
        if (currentCd > 0)
            currentCd -= Time.deltaTime;
    }

    private void OnMouseDown()
    {
        clicks++;

        if (clicks == 1 && currentCd <= 0)
        {
            elapsedTime = 0f;
            _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0.27f);

        }
        else if (clicks > 1)
        {
            if (elapsedTime <= doubleClickDuration)
            {
                clicks = 0;
                elapsedTime = 0f;
                CallPlatform();
            }
        }
    }

    private void CallPlatform()
    {
        if (currentCd > 0) return;
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0.27f);
        currentCd = GameManager.Instance.placedPlatformDuration;
        GameObject[] platforms = GameManager.Instance.placedPlatforms;
        Vector3 worldPosition = transform.position;
        worldPosition.y = -1.2f;
        Instantiate(platforms[0], worldPosition, Quaternion.identity);
    }
}
