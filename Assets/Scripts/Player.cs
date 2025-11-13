using System;
using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Info")] public float moveSpeed;
    public float jumpForce;
    public float faceDir { get; private set; } = 1f;
    private bool faceRight = true;

    [Header("Dash Info")]    
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set; }
    [SerializeField] private float dashCoolDown;
    private float dashTimer;
    
    [Header("Collision Info")]
    [SerializeField] private float groundDetectedDistance;
    [SerializeField] private Transform ground;
    [SerializeField] private float wallDetectedDistance;
    [SerializeField] private Transform wall;
    [SerializeField] private LayerMask WhatIsGround;

    
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
    public PlayerDashState _dash;
    public PlayerSlideState _slide;
    #endregion
    

    private void Awake()
    {
        _stateMachine = new PlayerStateMachine();
        // _idle = new PlayerIdleState(_stateMachine, this, "Idle");
        // _move = new PlayerMoveState(_stateMachine, this, "Move");
        // _jump = new PlayerJumpState(_stateMachine, this, "Jump");
        // _air = new PlayerAirState(_stateMachine, this, "Jump");
        // _dash = new PlayerDashState(_stateMachine, this, "Dash");
        _idle = CreateState<PlayerIdleState>("Idle");
        _move = CreateState<PlayerMoveState>("Move");
        _jump = CreateState<PlayerJumpState>("Jump");
        _air = CreateState<PlayerAirState>("Jump");
        _dash = CreateState<PlayerDashState>("Dash");
        _slide = CreateState<PlayerSlideState>("Slide");
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

        DashController();
        Debug.Log("wall detection"+WallDetection());
    }

    public bool GroundDetection() => 
        Physics2D.Raycast(ground.position, Vector2.down, groundDetectedDistance,WhatIsGround);
    public bool WallDetection() =>
        Physics2D.Raycast(wall.position, Vector2.right * faceDir, wallDetectedDistance, WhatIsGround);
    
    private void Flip()
    {
        faceDir *= -1f;
        faceRight = !faceRight;
        transform.Rotate(Vector2.up,180);
    }

    private void FaceController(float xVelocity)
    {
        if(xVelocity < 0 && faceRight)
            Flip();
        else if(xVelocity >0 && !faceRight)
            Flip();
    }
    public void SetVelocity(float xVelocity, float yVelocity=0)
    {
        rigid.linearVelocity = new Vector2(xVelocity, yVelocity);
        FaceController(xVelocity);
    }

    private void DashController()
    {
        dashTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer < 0)
        {
            dashTimer = dashCoolDown;
            
            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0)
                dashDir = faceDir;
            _stateMachine.Exchange(_dash);
        }
    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(ground.position,new Vector2(ground.position.x,ground.position.y+groundDetectedDistance));
        Gizmos.DrawLine(wall.position,new Vector2(wall.position.x + wallDetectedDistance,wall.position.y));
    }

    private T CreateState<T>(string stringBoolName) where T : PlayerState
    {
        Type obj = typeof(T);
        return Activator.CreateInstance(obj, new object[] { _stateMachine, this, stringBoolName }) as T;
    }
}
