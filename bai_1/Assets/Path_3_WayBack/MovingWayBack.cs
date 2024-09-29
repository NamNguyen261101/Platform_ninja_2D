using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWayBack : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    [SerializeField] List<Vector3> _path = new List<Vector3>();

    Vector2 _target;
    [SerializeField]
    int _currentIndexPlat = 0, _way = 1;


    void Start()
    {
        _target = _path[0];
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, _target, _speedMove * Time.deltaTime);

        if (Vector2.Distance(this.transform.position, _target) <= 0.5f)
        {
            if (_currentIndexPlat == _path.Count - 1 && _way == 1) // chi xay ra khi = duong va index no chay toi do
            {
                _way = -_way; // dao giau de chay nguoc lai
            }

            if (_currentIndexPlat == 0 && _way == -1)// chi xay ra khi = am va = 0 va index no chay toi do
            {
                _way = 1; // chuyen lai thanh duong
            }
                // thanh dau am thi se + nguoc lai
                _currentIndexPlat += _way;

            _target = _path[_currentIndexPlat];
        }
    }

}
