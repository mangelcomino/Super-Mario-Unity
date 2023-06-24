using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool HitDownByMario = false;
    private Rigidbody2D mRigidBody;
    private SpriteRenderer mSpriteRenderer;
    public float BumpVelocity = 1.0f;
    public float BumpAmount = 1.0f;
    private Vector2 mInitialPosition;


    private void Awake()
    {
        mRigidBody = GetComponent<Rigidbody2D>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        mInitialPosition = mSpriteRenderer.transform.position;
    }

    private void CheckHitByMario()
    {
        if (HitDownByMario)
        {
            Bump();
        }
    }

    private void Bump()
    {
        if (HitDownByMario)
        {
            mRigidBody.velocity = new Vector2(0f, BumpVelocity);
            HitDownByMario = false;
        }
    }

    private void CheckBumping()
    {
        if (mSpriteRenderer.transform.position.y>mInitialPosition.y + BumpAmount)
        {
            mRigidBody.velocity = new Vector2(0f, -BumpVelocity);
        }
        if (mRigidBody.velocity.y<0f && mSpriteRenderer.transform.position.y < mInitialPosition.y)
        {
            mRigidBody.velocity =new Vector2(0f,0f);
            mSpriteRenderer.transform.position = mInitialPosition;
            HitDownByMario = false;

        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckHitByMario();
        CheckBumping();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        ContactPoint2D[] contacts = collision.contacts;
        foreach (ContactPoint2D contact in contacts)
        {
            Vector2 contactNormal = contact.normal;
            if (contactNormal == Vector2.up && collision.collider.tag=="Player")
            {
                HitDownByMario = true;
            }

        }
    }
}
