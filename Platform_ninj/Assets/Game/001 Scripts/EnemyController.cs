using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Character
{
    [SerializeField] private float _attackRange, _moveSpeed;

    [SerializeField] private Rigidbody2D _rigi;

    private IState currentState;


    private bool _isRight = true;

    private Character _target;

    public Character Target => _target;
    private void Update()
    {
        if (currentState != null) 
        {
            currentState.OnExecute(this);
        }

    }
    public override void OnInit()
    {
        base.OnInit();

        ChangeState(new IdleState());
    }

    public override void OnDespawn()
    {
       
    }

    protected override void OnDeath()
    {
        base.OnDeath();
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;

        if (currentState != null)
        
        {
            currentState.OnEnter(this);
        }
    }

    internal void SetTarget(Character character)
    {
        this._target = character;

        if (IsTargetInRange())
        {
            ChangeState(new AttackState());
        }
        else if (Target != null)
        {
            ChangeState(new PatrolState());
        } else
        {
            ChangeState(new IdleState());
        }
    }

    public void Moving()
    {
        ChangeAnim("run");

        _rigi.velocity = transform.right * _moveSpeed;
    }

    public void StopMoving()
    {
        ChangeAnim("idle");
        _rigi.velocity = Vector2.zero;
    }

    public void Attack()
    {

    }

    public bool IsTargetInRange()
    {
        return Vector2.Distance(_target.transform.position, this.transform.position) <= _attackRange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemywall")
        {
            ChangeDirection(!_isRight);
        }
    }

    public void ChangeDirection(bool isRight)
    {
        this._isRight = isRight;

        this.transform.rotation = isRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 100);
    }

    
}
