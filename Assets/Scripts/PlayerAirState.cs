
namespace DefaultNamespace
{
    public class PlayerAirState : PlayerState
    {
        public PlayerAirState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
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
            if(player.GroundDetection())
               stateMachine.Exchange(player._idle); 
            if(player.WallDetection())
                stateMachine.Exchange(player._slide);
        }
    }
}