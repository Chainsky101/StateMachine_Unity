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
            // used in dash 
            if(!player.GroundDetection())
                stateMachine.Exchange(player._air);
            
            // //protected player from moving to wall
            // if (player.WallDetection())
            // {
            //     stateMachine.Exchange(player._idle);
            // }
            
            // if put dash controller in here, only in the ground state can dash, but
            // we want to dash in any state, so we put the dash controller in the player Update().
            // if(Input.GetKeyDown(KeyCode.LeftShift))
            //     stateMachine.Exchange(player._dash);
        }
    }
}