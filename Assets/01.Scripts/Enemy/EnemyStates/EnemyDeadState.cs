using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyDeadState : EnemyState
{
    public EnemyDeadState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {

        _enemy._navMesh.isStopped = true; 
        _enemy._boxCollider.isTrigger = true;

        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        _enemy.transform.rotation = _enemy.transform.rotation; // 그대로 유지 (고정)
        _enemy.GetComponent<Rigidbody>().freezeRotation = true; // 물리 회전 잠금
        base.Update();
    }
}
