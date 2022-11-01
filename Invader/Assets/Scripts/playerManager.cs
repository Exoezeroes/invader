using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public float hp = 100; // Health Point
    public float mp = 10; // Mana Point
    public float sp = 100; // Stamina Point
    public float maxHp = 100; // Max Health Point
    public float maxMp = 10; // Max Mana Point
    public float maxSp = 100; // Max Stamina Point
    [SerializeField] Rigidbody2D rb;

    [SerializeField] bool isMoving = false;
    [SerializeField] float groundAccel = 20;
    [SerializeField] float airAccel = 5;
    [SerializeField] float curSpeed;
    [SerializeField] float maxGroundSpeed = 20;
    [SerializeField] float maxAirSpeed = 20;

    [SerializeField] bool isOnGround;
    [SerializeField] bool isJumping = false;
    [SerializeField] float jumpAccel = 60; 
    [SerializeField] float maxJumpDur = 1; //second
    [SerializeField] float curJumpDur = 0; //second

    void OnTriggerStay2D() {
        isOnGround = true;
    }

    void OnTriggerExit2D() {
        isOnGround = false;
    }

    void FixedUpdate()
    {
        // Horizontal
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Horizontal")) {
            isMoving = true;
            if (isOnGround) {
                rb.AddForce(transform.right * groundAccel * horizontal);
                rb.drag = (groundAccel / maxGroundSpeed);
            } else {
                rb.AddForce(transform.right * airAccel * horizontal);
                rb.drag = (airAccel / maxAirSpeed);
            }
        }
        else if (isMoving) {
            isMoving = false;
        }
    
        // Jump
        if (isOnGround) {
            curJumpDur = 0;
        }

        if (curJumpDur < maxJumpDur) {

            if (Input.GetButton("Jump")) {
                isJumping = true;

                rb.AddForce(transform.up * jumpAccel);

                curJumpDur += Time.deltaTime;
            }

            else if (isJumping) {
                curJumpDur = maxJumpDur;

                isJumping = false;
            }
        }
    }
}
