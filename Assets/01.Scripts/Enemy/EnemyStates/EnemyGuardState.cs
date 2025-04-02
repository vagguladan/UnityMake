using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardState : EnemyState
{
    public EnemyGuardState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        _enemy._moveSpeed = 20f;

        _stateTimer = 30f;

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
        _enemy._attackDelayTimer -= Time.deltaTime;
        if (_enemy._attackDelayTimer < 0)
        {
            _enemy._attackCollider.SetActive(true);
        }

       if(_stateTimer<0)
        {
            _enemy.StopPlayerTagerMove();
            _enemy.RotateMove();
        }

            _enemy.PlayerTargerMove();

        

    }

}
