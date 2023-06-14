using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Mario : MonoBehaviour
{

    private Rigidbody2D mRigidBody;
    public float speedX = 5f;

    private void Awake()
    {
        mRigidBody = GetComponent<Rigidbody2D>();
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
    }
}
