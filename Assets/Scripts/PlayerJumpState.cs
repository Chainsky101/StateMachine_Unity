using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerJumpState : PlayerState
    {
        public PlayerJumpState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.SetVelocity(rigid.linearVelocityX,player.jumpForce);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            if(player.WallDetection())
                stateMachine.Exchange(player._slide);
            // player.anim.SetFloat("yVelocity",rigid.linearVelocityY);
            // if(rigid.linearVelocityY < 0)
            //     stateMachine.Exchange(player._air); -- optimized : decrease the state switch times
            if(player.GroundDetection() && rigid.linearVelocityY < 0) 
                stateMachine.Exchange(player._idle);
            
        }
    }
}