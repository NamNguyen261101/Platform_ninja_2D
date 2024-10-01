using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _imageFill;
    [SerializeField] private Vector3 _offset;

    private float _hp;
    private float _maxHp;

    private Transform _target;

    void Update()
    {
        _imageFill.fillAmount = Mathf.Lerp(_imageFill.fillAmount, _hp / _maxHp, Time.deltaTime * 5f);
        transform.position = _target.position + _offset;
    }

    public void OnInit(float maxHp, Transform _target)
    {
        this._target = _target;
        this._maxHp = maxHp;
        _hp = maxHp;
        _imageFill.fillAmount = 1; // lay thong so hinh anh 1 la day
    }

    public void SetNewHp(float hp)
    {
        this._hp = hp;

        // _imageFill.fillAmount = hp / _maxHp;
    }
}
