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
    public float speedX = 5f;

    private void Awake()
    {
        mRigidBody = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveX * speedX, mRigidBody.velocity.y);
        mRigidBody.velocity = movement;
        if (moveX != 0)
            mAnimator.Play("MarioRun");
        else mAnimator.Play("MarioIdle");
        if (moveX<0)
            mSpriteRenderer.flipX = true;
        else mSpriteRenderer.flipX = false;
    }
}
