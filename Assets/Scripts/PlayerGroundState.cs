using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerGroundState : PlayerState
    {
        public PlayerGroundState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
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
            if(Input.GetKeyDown(KeyCode.Space) && player.GroundDetection())
                stateMachine.Exchange(player._jump);
        }
    }
}