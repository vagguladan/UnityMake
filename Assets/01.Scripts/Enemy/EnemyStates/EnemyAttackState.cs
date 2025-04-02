using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackState : EnemyState
{

    public EnemyAttackState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        _stateTimer = 10;
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        _stateTimer -= Time.deltaTime;

        if (_stateTimer < 0)
        {
            _enemy.StopPlayerTagerMove();
            _stateMachine.ChangeState(_enemy._guardState);
        }
    }

}
