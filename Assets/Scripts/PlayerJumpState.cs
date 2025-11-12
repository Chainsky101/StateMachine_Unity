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
            rigid.linearVelocity = new Vector2(rigid.linearVelocityX, player.jumpForce);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            
            if(rigid.linearVelocityY < 0)
                stateMachine.Exchange(player._air);
        }
    }
}