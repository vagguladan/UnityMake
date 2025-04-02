using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSitState : PlayerState
{
    public PlayerSitState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        _player._collider.size = new Vector3(2.38f, 5, 2.29f);

        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        _player._collider.size = new Vector3(2.38f, 8.54f, 2.29f);
    }

    public override void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _stateMachine.ChageState(_player._idleState);
        }

        base.Update();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("VentCollider"))
        {

        }
    }
}
