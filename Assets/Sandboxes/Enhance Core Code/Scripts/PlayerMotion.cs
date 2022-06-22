using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private Transform _tf;

    public float movementSpeed;

    private void Awake()
    {
        _tf = GetComponent<Transform>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        _tf.position = new Vector2(MusicConductor.Instance.songPosition, _tf.position.y);
    }
}
