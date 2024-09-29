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
        if (timer > randomTime)
        {
            enemy.Moving();
        } else
        {
            enemy.ChangeState(new IdleState());
        }
    }

    public void OnExit(EnemyController enemy)
    {
        
    }
}
