using UnityEngine;

public class PlayerState
{
    public PlayerStateMachine stateMachine;
    public Player player;
    public string animBoolName;

    protected Rigidbody2D rigid;
    protected float xInput;
    protected float yInput;

    protected float stateTimer;
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
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName,false);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        player.SetVelocity(xInput*player.moveSpeed, rigid.linearVelocityY);
        //-- Optimized: put it in to jump state, decrease setting times
        //but we need to use in Air state, so we can add a bool condition,
        // whether to set value depend on the IsGround value
        // if(!player.GroundDetection())
        player.anim.SetFloat("yVelocity",rigid.linearVelocityY);

        Debug.Log($"I'm in the {animBoolName}");
        
    }
    
    
}
