using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPath1 : MonoBehaviour
{
    [SerializeField] private Transform _start, _end;
    [SerializeField] private float _speed;

    private Vector2 _target;
    
    void Start()
    {
        _target = _start.position; // k add he thong vat ly
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, _target, _speed * Time.deltaTime); // current -> target (tra ve toa do)
        if (Vector2.Distance(this.transform.position, _target) <= 0.5f) // neu ma gan cham thi bat dau so sanh 
        {
            if (_target.Equals(_start.position)) 
            { 
                _target = _end.position;
            }
            else
            {
                _target = _start.position;
            }
        }
    }
}
