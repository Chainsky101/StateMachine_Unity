using UnityEngine;

public class PlayerState
{
    public PlayerStateMachine stateMachine;
    public Player player;
    public string animBoolName;

    protected Rigidbody2D rigid;
    protected float xInput;
    
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
        xInput = Input.GetAxisRaw("Horizontal");
        player.SetVelocity(xInput*player.moveSpeed, rigid.linearVelocityY);
        player.anim.SetFloat("yVelocity",rigid.linearVelocityY);

        Debug.Log($"I'm in the {animBoolName}");
        
    }
    
    
}
