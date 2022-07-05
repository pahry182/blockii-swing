using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private Transform _tf;

    private void Awake()
    {
        _tf = GetComponent<Transform>();
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        _tf.position = new Vector2((MusicConductor.Instance.songPosition * MusicConductor.Instance.speedRatio) - MusicConductor.Instance.offsetPos, _tf.position.y);
    }
}
