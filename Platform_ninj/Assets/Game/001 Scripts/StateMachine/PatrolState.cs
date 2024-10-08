using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    private float timer;
    private float randomTime;
     
    public void OnEnter(EnemyController enemy)
    {
        timer = 0;
        randomTime = Random.Range(3f, 6f);
    }

    public void OnExecute(EnemyController enemy)
    {
        timer += Time.deltaTime;

        if (enemy.Target != null)
        {
            // doi huong enemy toi huong cua player
            enemy.ChangeDirection(enemy.Target.transform.position.x > enemy.transform.position.x); // so sanh truc x cua player neu player lon hon thi huong sang phai
            if (enemy.IsTargetInRange())
            {
                enemy.ChangeState(new AttackState());
            } else
            {
                enemy.Moving();
            }
        } 
        else
        {
            if (timer > randomTime)
            {
                enemy.Moving();
            }
            else
            {
                enemy.ChangeState(new IdleState());
            }
        }
    }

    public void OnExit(EnemyController enemy)
    {
        
    }
}
