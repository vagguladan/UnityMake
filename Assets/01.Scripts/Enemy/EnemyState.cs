using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState
{
    [Header("Enemy Stat Info")]
    public int Hp = 100;


    protected EnemyStateMachine _stateMachine;
    protected Enemy _enemy;

    protected Rigidbody _rb;
    protected NavMeshAgent _navAgent;
    protected Transform _targetPlayer;

    private string _aniBoolName;

    protected float _stateTimer;
    protected bool _trigerCalled;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        this._enemy = enemy;
        this._stateMachine = stateMachine;
        this._aniBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        _enemy._anim.SetBool(_aniBoolName, true);
        _trigerCalled = false;
    }

    public virtual void Update()
    {
        _stateTimer -= Time.deltaTime;

    
    }

    public virtual void Exit()
    {
        _enemy._anim.SetBool(_aniBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        _trigerCalled = true;
    }


}
