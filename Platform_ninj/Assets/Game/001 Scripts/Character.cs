using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float hp;
    [SerializeField] private Animator _anim;
    [SerializeField] protected HealthBar _healthBar;

    [SerializeField] protected CombatTech combatTechPrefabs;
    public bool _isDead => hp <= 0;

    private string _currentAnim;
    private void Start()
    {
        OnInit();
    }

    public virtual void OnInit()
    {
        hp = 100;
        _healthBar.OnInit(100, transform); // 
    }

    public virtual void OnDespawn()
    {

    }

    protected virtual void OnDeath()
    {
        ChangeAnim("die");

        Invoke(nameof(OnDespawn), 2f);
    }

    protected void ChangeAnim(string animName)
    {
        if (_currentAnim != animName)
        {
            _anim.ResetTrigger(animName);

            _currentAnim = animName;

            _anim.SetTrigger(_currentAnim);
        }
    }

    public void OnHit(float damage)
    {
        if (hp >= damage)
        {
            hp -= damage;

            if (_isDead)
            {
                hp = 0;
                OnDeath();
            }

            _healthBar.SetNewHp(hp);
            Instantiate(combatTechPrefabs, transform.position + Vector3.up, Quaternion.identity).OnInit(damage);
        }
    }


}
