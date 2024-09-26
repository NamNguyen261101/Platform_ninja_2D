using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset; // vi tri tuong doi target voi camera
    [SerializeField] private float _speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        _target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, _target.position + _offset, Time.deltaTime * _speed); 
        // trg hop nay la fix update boi player cung xai fix

    }
}
