using DefaultNamespace;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlayerStateMachine stateMachine, Player player, string animBoolName) 
        : base(stateMachine, player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.ZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        
            
        if (xInput != 0 && !player.isBusy && !player.WallDetection())
        {
            stateMachine.Exchange(player._move);
        }
    }
}