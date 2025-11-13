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
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            
            if(yInput > 0)
                player.SetVelocity(rigid.linearVelocityX,rigid.linearVelocityY*0.7f);
            if(!player.WallDetection())
                stateMachine.Exchange(player._idle);
            if(player.GroundDetection())
                stateMachine.Exchange(player._idle);
        }
    }
}