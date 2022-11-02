using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    public override void FixedUpdate() 
    {
        UpdateMovement(Horizontal());
        UpdateMovement(Vertical());
    }

    public Vector2 Horizontal() 
    {
        Vector2 vector = new Vector2(0f, 0f);

        float horizontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButton("Horizontal")) 
        {
            isMoving = true;

            float acceleration = isOnGround ? groundAccel : airAccel;
            float maxSpeed = isOnGround ? maxGroundSpeed : maxAirSpeed;
            SetDrag(acceleration/maxSpeed);
            
            vector = transform.right * acceleration * horizontal;
        }

        else if (isMoving) 
        {
            isMoving = false;
        }

        return vector;
    }

    public Vector2 Vertical()
    {
        Vector2 vector = new Vector2(0f, 0f);

        if (isOnGround) curJumpDur = 0;

        if (curJumpDur < maxJumpDur) 
        {
            if (Input.GetButton("Jump")) 
            {
                isJumping = true;
                vector = transform.up * jumpAccel;
                curJumpDur += Time.deltaTime;
            }

            else if (isJumping) 
            {
                curJumpDur = maxJumpDur;
                isJumping = false;
            }
        }

        return vector;
    }
}
