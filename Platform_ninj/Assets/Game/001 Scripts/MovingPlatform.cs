using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private Transform _start, _end;
    [SerializeField] private float _speedMove;
    private Vector3 _target;
    void Start()
    {
        this.transform.position = _start.position;
        _target = _end.position;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, _target, _speedMove * Time.deltaTime);

        if (Vector3.Distance(this.transform.position, _start.position) <= 0.1f)
        {
            _target = _end.position;
        } else if (Vector3.Distance(this.transform.position, _end.position) <= 0.1f)
        {
            _target = _start.position;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            collision.transform.SetParent(transform); // khi ma va cham voi moving thi no se la con cua thang squares
        } // va cham cung
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        } 
    }
}
