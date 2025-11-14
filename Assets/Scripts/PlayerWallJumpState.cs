using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerWallJumpState : PlayerState
    {
        private float backward = 5f;
        public PlayerWallJumpState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.SetVelocity(backward*-player.faceDir,player.jumpForce -3f);
            Debug.Log(player.rigid.linearVelocity);
            stateTimer = 0.5f;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            // Debug.Log(player.rigid.linearVelocity);
            
            if(player.rigid.linearVelocityY < 0 && player.WallDetection())
                stateMachine.Exchange(player._slide);
            
            if(stateTimer < 0) 
                stateMachine.Exchange(player._air);
        }
    }
}