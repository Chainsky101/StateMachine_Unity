using DefaultNamespace;
using UnityEngine;

public class PlayerState : IState
{
    public PlayerStateMachine stateMachine;
    public Player player;
    public string animBoolName;

    protected Rigidbody2D rigid;
    protected float xInput;
    protected float yInput;

    protected float stateTimer;
    //used to control the animation event
    protected bool animationTrigger;
    public PlayerState(PlayerStateMachine stateMachine, Player player, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName,true);
        rigid = player.rigid;
        animationTrigger = false;
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName,false);
    }

    //used to control the animation event
    public void AnimationTrigger()
    {
        animationTrigger = true;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        if(stateMachine.currentState == player._attack)
            return;
        
        if (!player.isBusy)
        {
            player.SetVelocity(xInput*player.moveSpeed, rigid.linearVelocityY);
        }
        //-- Optimized: put it in to jump state, decrease setting times
        //but we need to use in Air state, so we can add a bool condition,
        // whether to set value depend on the IsGround value
        // if(!player.GroundDetection())
        player.anim.SetFloat("yVelocity",rigid.linearVelocityY);

        Debug.Log($"I'm in the {animBoolName}");
        
    }
    
    
}
