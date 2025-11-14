using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerPrimeAttackState : PlayerState
    {
        private int attackCounter = 0;
        private float coolDown = 2f;
        private float lastAttackTime;
        public PlayerPrimeAttackState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
        {
        }
        public override void Enter()
        {
            base.Enter();
            // animation speed up
            // player.anim.speed = 2f;
            if (attackCounter > 2 || Time.time - lastAttackTime > coolDown)
                attackCounter = 0;

            #region SetAttackDirection
            float attackDir = player.faceDir;
            if (xInput != 0)
                attackDir = xInput;
            #endregion
            player.SetVelocity(player.move[attackCounter].x * attackDir,player.move[attackCounter].y);
            player.anim.SetInteger("AttackCount",attackCounter);
            stateTimer = .2f;
        }

        public override void Exit()
        {
            base.Exit();
            lastAttackTime = Time.time;
            attackCounter++;
            //cannot move in the attack interval
            player.StartBusy(0.15f);
            
            // player.anim.speed = 1f;

        }

        public override void Update()
        {
            base.Update();
            
            //don not allow to move
            if(stateTimer < 0)
                player.ZeroVelocity();
            
            if(animationTrigger)
                stateMachine.Exchange(player._idle);
        }
    }
}