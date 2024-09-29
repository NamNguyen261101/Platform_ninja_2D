using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter(EnemyController enemy); // start state
    void OnExecute(EnemyController enemy); // update state
    void OnExit(EnemyController enemy); // end state
}
