using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class CameraOffsetController : MonoBehaviour
{
    private CinemachineTransposer _cam;
    private bool isChanging;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _cam = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>();
    }

    private void Start()
    {
        ChangeCamera();
    }

    public void ChangeCamera()
    {
        _cam.m_FollowOffset = new Vector3(GameManager.Instance.cameraOffset, _cam.m_FollowOffset.y, _cam.m_FollowOffset.z);
    }
}
