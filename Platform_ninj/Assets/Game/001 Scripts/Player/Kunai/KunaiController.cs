using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigi;
    [SerializeField] private float _speed = 5f;

    [SerializeField] private GameObject _hitVFX;

    void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        _rigi.velocity = this.transform.right * _speed;
        Invoke(nameof(OnDespawn), 4f);
    }

    public void OnDespawn()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Character>().OnHit(30f);
            Instantiate(_hitVFX, transform.position, transform.rotation);
            OnDespawn();
        }
    }
}
