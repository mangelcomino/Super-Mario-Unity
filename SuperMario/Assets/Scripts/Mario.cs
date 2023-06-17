using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Mario : MonoBehaviour
{

    private Rigidbody2D mRigidBody;
    private Animator mAnimator;
    private SpriteRenderer mSpriteRenderer;
    private BoxCollider2D mBoxCollider;
    public float speedX = 5f;
    public float JumpForce = 5f;
    public bool isGrounded=false;
    public LayerMask FloorLayer;
    public float moveX;
    public ePlayerState State=ePlayerState.Idle;

    private void Awake()
    {
        mRigidBody = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mBoxCollider = GetComponent<BoxCollider2D>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void CheckGround()
    {
        Vector2 groundCheckPosition = (Vector2) this.transform.position + this.mBoxCollider.offset;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(groundCheckPosition, this.mBoxCollider.size, 0f);
        isGrounded = false;
        foreach (var coll in colliders) 
        {
            if (coll.tag == ("Player"))
                continue;
            isGrounded=true;
            break;
        }
        

    }  

    private void CheckInput()
    {
        moveX = Input.GetAxis("Horizontal");
        if (moveX != 0f)
            Run(moveX);
        else Stop();

        if (moveX < 0)
            mSpriteRenderer.flipX = true;
        else mSpriteRenderer.flipX = false;

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            Jump();
        
    }

    private void Run(float moveX)
    {
        State = ePlayerState.Run;
        Vector2 movement = new Vector2(moveX * speedX, mRigidBody.velocity.y);
        mRigidBody.velocity = movement;
    }

    private void Stop()
    {
        State = ePlayerState.Idle;
    }
    private void Jump()
    {
        State=ePlayerState.Jump;
        mRigidBody.AddForce(new Vector2(0f, JumpForce));
    }

    private void CheckState()
    {
        if (!isGrounded)
        {
            mAnimator.Play("MarioJump");
            return;
        }
        switch (State)
        {
            case ePlayerState.Idle:
                mAnimator.Play("MarioIdle");
                break;
            case ePlayerState.Run:
                mAnimator.Play("MarioRun");
                break;
            case ePlayerState.Jump:
                mAnimator.Play("MarioJump");
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        CheckGround();
        CheckInput();
        CheckState();
        //isGrounded=Physics2D.OverlapCircle()
    }
}
