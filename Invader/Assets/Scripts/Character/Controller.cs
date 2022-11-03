using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{   
    // Attributes
#pragma warning disable 0649
    [SerializeField] Rigidbody2D rb;
        // Statuses
    [SerializeField] protected bool isMoving = false;
    [SerializeField] protected bool isOnGround = false;
    [SerializeField] protected bool isJumping = false;
        // Accelerations
    [SerializeField] protected float groundAccel = 15;
    [SerializeField] protected float jumpAccel = 60;
    [SerializeField] protected float airAccel = 9;
        // Max Speeds
    [SerializeField] protected float maxGroundSpeed = 15;
    [SerializeField] protected float maxJumpSpeed = 30;
    [SerializeField] protected float maxAirSpeed = 15;
        // Durations
    [SerializeField] protected float curJumpDur = 0f;    //seconds
    [SerializeField] protected float maxJumpDur = 0.1f; //seconds
#pragma warning restore 0649

    // Abstracts
    public abstract void FixedUpdate();

    // Methods
    protected void UpdateMovement(Vector2 vector) 
    {
        rb.AddForce(vector);
    }

    protected void SetDrag(float val) 
    {
        rb.drag = val;
    }

    // Functions
    void OnTriggerStay2D() {
        isOnGround = true;
    }

    void OnTriggerExit2D() {
        isOnGround = false;
    }
}
