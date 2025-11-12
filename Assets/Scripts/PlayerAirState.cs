
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
            if(rigid.linearVelocityY == 0)
                stateMachine.Exchange(player._idle);
        }
    }
}