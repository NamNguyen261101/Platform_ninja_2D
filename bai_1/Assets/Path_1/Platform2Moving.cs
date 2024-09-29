using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2Moving : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _moveSpeed;
    private int pointIndex;

    void Start()
    {
        this.transform.position = _points[pointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, _points[pointIndex].transform.position, _moveSpeed * Time.deltaTime);
        
        if (this.transform.position == _points[pointIndex].transform.position )
        {
            pointIndex += 1;    
        }

        if (pointIndex == _points.Length ) // khi chay toi cuoi index thi quay lai
        {
            pointIndex = 0;
        }
    }
}
