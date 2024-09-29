using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform2 : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    [SerializeField] List<Vector3> _path = new List<Vector3>();

    Vector2 _target;

    int _currentIndexPlat = 0;


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
            _currentIndexPlat++;
            if (_currentIndexPlat > _path.Count)
            {
                _currentIndexPlat = 0;
            }
            _target = _path[_currentIndexPlat];
        }
    }

    private void OnDrawGizmos()
    {
        
    }
}
