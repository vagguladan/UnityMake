using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine _stateMachine;
    protected Player _player;


    protected Rigidbody _rb;
    protected Collider _collider;

    protected float _xInput;
    protected float _yInput;
    protected float _rotate;
    private string _aniBoolName;

    protected float _stateTimer;
    protected bool _trigerCalled;


    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        this._player = player;
        this._stateMachine = stateMachine;
        this._aniBoolName = animBoolName;
    }


    public virtual void Enter()
    {
        _player._anim.SetBool(_aniBoolName, true);
     //   _rb = _player._rb;
        _trigerCalled = false;
    }

    public virtual void Update()
    {
        _stateTimer -= Time.deltaTime;


          _xInput = Input.GetAxisRaw("Horizontal");
        _yInput = Input.GetAxisRaw("Vertical");
         _rotate = Input.GetAxisRaw("Rotate");

    }

    public virtual void Exit()
    {
        _player._anim.SetBool(_aniBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        _trigerCalled = true;
    }


}
