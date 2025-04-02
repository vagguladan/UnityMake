using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        _player.SetRotateMove(_yInput, _xInput,_rotate);
      //  _player.SetVelocity(_xInput * _player._moveSpeed,  _yInput*_player._moveSpeed);

   

        if (_xInput == 0 && _yInput == 0 && _rotate == 0)
            _stateMachine.ChageState(_player._idleState);

    }

    public override void Exit()
    {
        base.Exit();
    }

}
