using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private float timer;
    public void OnEnter(EnemyController enemy)
    {
        if (enemy.Target != null)
        {
            // doi huong enemy toi huong cua player
            enemy.ChangeDirection(enemy.Target.transform.position.x > enemy.transform.position.x);

            enemy.StopMoving();
            enemy.Attack();
        }

        timer = 0;
    }

    public void OnExecute(EnemyController enemy)
    {
        timer += Time.deltaTime;
        
        if (timer > 1.5f)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

    public void OnExit(EnemyController enemy)
    {

    }
}
