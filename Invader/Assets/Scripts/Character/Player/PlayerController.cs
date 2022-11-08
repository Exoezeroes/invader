using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AController
{
    float maxSpeed;

    public override void FixedUpdate() 
    {
        UpdateMovement(Horizontal());
        UpdateMovement(Vertical());
    }

    public Vector2 Horizontal() 
    {
        Vector2 vector = Vector2.zero;

        float horizontal = Input.GetAxisRaw("Horizontal");
        character.SetRunning(Input.GetButton("Run"));
        if (Input.GetButton("Horizontal")) 
        {
            character.SetMoving(true);

            float acceleration = character.OnGround() ? character.GetGroundAccel() : character.GetAirAccel();
            if (character.OnGround())
            {
                maxSpeed = character.IsRunning() ? character.GetMaxRunSpeed() : character.GetMaxGroundSpeed();
            }
            else { maxSpeed = character.GetMaxAirSpeed(); }

            SetDrag(acceleration / maxSpeed);
            
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
