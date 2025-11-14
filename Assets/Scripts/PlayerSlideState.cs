using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerSlideState : PlayerState
    {
        public PlayerSlideState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            stateTimer = 0.2f;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.Exchange(player._wallJump);
                return;
            }
            
            if(yInput > 0)
                player.SetVelocity(0,rigid.linearVelocityY*0.7f);
            else
                player.SetVelocity(0,rigid.linearVelocityY);
            
            if((!player.WallDetection() || player.GroundDetection())&& stateTimer < 0)
                stateMachine.Exchange(player._idle);
            
        }
    }
}