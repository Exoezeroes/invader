using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AController
{
    public override void FixedUpdate() 
    {
        UpdateMovement(Horizontal());
        UpdateMovement(Vertical());
    }

    public Vector2 Horizontal() 
    {
        Vector2 vector = Vector2.zero;

        float horizontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButton("Horizontal")) 
        {
            character.SetMoving(true);

            float acceleration = character.OnGround() ? character.GetGroundAccel() : character.GetAirAccel();
            float maxSpeed = character.OnGround() ? character.GetMaxGroundSpeed() : character.GetMaxAirSpeed();
            SetDrag(acceleration/maxSpeed);
            
            vector = acceleration * horizontal * transform.right;
        }
        else
        {
            character.SetMoving(false);
        }

        return vector;
    }

    public Vector2 Vertical()
    {
        Vector2 vector = Vector2.zero;

        if (character.GetCurrentJumpTime() < character.GetMaxJumpTime()) 
        {
            if (Input.GetButton("Jump")) 
            {
                character.SetJumping(true);
                character.AddJumpTime(Time.deltaTime);

                vector = transform.up * character.GetJumpAccel();
            }

            else if (character.IsJumping()) 
            {
                // stop the jump
                character.SetJumping(false);
                character.SetJumpTime(character.GetMaxJumpTime());
            }
        }
        else if (character.OnGround())
        {
            character.SetJumpTime(0);
        }

        return vector;
    }
}
