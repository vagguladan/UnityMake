using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    

    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();
 //       _rb.velocity = Vector3.zero;
    }     
    public override void Update()
    {
        base.Update();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_xInput != 0 || _yInput != 0)
                _stateMachine.ChageState(_player._runState);
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            _stateMachine.ChageState(_player._sitState);
        }

        if (_xInput != 0 || _yInput !=0 || _rotate != 0)
            _stateMachine.ChageState(_player._moveState);


        if (Input.GetMouseButton(1))
        {
            _stateMachine.ChageState(_player._attackState);
        }
    
    }

    public override void Exit()
    {
        base.Exit();
    }

}
