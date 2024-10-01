using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _imageFill;

    private float _hp;
    private float _maxHp;
    
    void Update()
    {
        _imageFill.fillAmount = Mathf.Lerp(_imageFill.fillAmount, _hp / _maxHp, Time.deltaTime * 5f);
    }

    public void OnInit(float maxHp)
    {
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
