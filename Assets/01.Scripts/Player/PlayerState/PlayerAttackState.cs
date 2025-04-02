using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {



        base.Enter();


        _player._playerAttackSetting.SetActive(true);


    }

    public override void Exit()
    {
   
        base.Exit();
        _player._playerAttackSetting.transform.rotation = Quaternion.Euler(
      _player._playerAttackSetting.transform.rotation.eulerAngles.x,
      0f,
      _player._playerAttackSetting.transform.rotation.eulerAngles.z
  );


        _player._playerAttackSetting.SetActive(false);
    }

    public override void Update()
    {

        base.Update();

        if (Input.GetMouseButtonUp(1))
        {
            _stateMachine.ChageState(_player._idleState);

        }
    }
}
