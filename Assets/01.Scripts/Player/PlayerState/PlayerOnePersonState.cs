    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerOnePersonState : PlayerState
    {
    private OnePersonCameraMove _cameraMove;
    private PlayerAttack _playerAttack;
    
        public PlayerOnePersonState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
        {
        _cameraMove = _player.GetComponent<OnePersonCameraMove>();
        _playerAttack = _player.GetComponent<PlayerAttack>();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
        }
    }
