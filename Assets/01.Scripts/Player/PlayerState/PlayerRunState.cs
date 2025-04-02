using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerState
{
    public PlayerRunState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        
        _player.SetVelocity(_xInput * _player._runSpeed, _yInput * _player._runSpeed);
       
        if (_xInput == 0 && _yInput == 0)
            _stateMachine.ChageState(_player._idleState);
    }

    public override void Exit()
    {
        base.Exit();
    }

}
