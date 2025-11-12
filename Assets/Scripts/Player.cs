using System;
using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Info")] public float moveSpeed;
    public float jumpForce;

    [Header("Collision Info")]
    [SerializeField] private float groundDetectedDistance;
    [SerializeField] private Transform ground;
    [SerializeField] private float wallDetectedDistance;
    [SerializeField] private Transform wall;
    [SerializeField] private LayerMask WhatIsGround;

    public float faceDir { get; private set; } = 1f;
    private bool faceRight = true;
    
    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rigid { get;private set; }
    #endregion

    #region States
    private PlayerStateMachine _stateMachine;
    public PlayerIdleState _idle;
    public PlayerMoveState _move;
    public PlayerJumpState _jump;
    public PlayerAirState _air;
    #endregion
    

    private void Awake()
    {
        _stateMachine = new PlayerStateMachine();
        _idle = new PlayerIdleState(_stateMachine, this, "Idle");
        _move = new PlayerMoveState(_stateMachine, this, "Move");
        _jump = new PlayerJumpState(_stateMachine, this, "Jump");
        _air = new PlayerAirState(_stateMachine, this, "Jump");

    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        
        
        _stateMachine.Initialize(_idle);
    }

    private void Update()
    {
        _stateMachine.currentState.Update();
    }

    public bool GroundDetection() => Physics2D.Raycast(ground.position, Vector2.down, groundDetectedDistance);

    private void Flip()
    {
        faceDir *= -1f;
        faceRight = !faceRight;
        transform.Rotate(Vector2.up,180);
    }

    private void FaceController(float xVelocity)
    {
        if(rigid.linearVelocityX < 0 && faceRight)
            Flip();
        else if(rigid.linearVelocityX >0 && !faceRight)
            Flip();
    }
    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rigid.linearVelocity = new Vector2(xVelocity, yVelocity);
        FaceController(xVelocity);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(ground.position,new Vector2(ground.position.x,ground.position.y-groundDetectedDistance));
        Gizmos.DrawLine(wall.position,new Vector2(wall.position.x + wallDetectedDistance,wall.position.y));
    }
}
