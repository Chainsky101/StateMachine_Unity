using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerDashState : PlayerState
    {
        public PlayerDashState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            stateTimer = player.dashDuration;
            
        }

        public override void Exit()
        {
            base.Exit();
            player.SetVelocity(0);
        }

        public override void Update()
        {
            base.Update();
            player.SetVelocity(player.dashSpeed * player.dashDir);//use dash direction to set velocity
            
            if(stateTimer < 0)
                stateMachine.Exchange(player._idle);
        }
    }
}