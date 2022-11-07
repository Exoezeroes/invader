using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACharacter : MonoBehaviour
{
    // Attributes
        // Physics Body
#pragma warning disable 0649
    [SerializeField] private Rigidbody2D rb;
#pragma warning restore 0649
    // Health Point
    [SerializeField] private float currentHP = 100;
    [SerializeField] private float currentMaxHP = 100;
    [SerializeField] private float baseMaxHP = 100;
    [SerializeField] private float multiplierHP = 1;
    public float testHp;
        // Mana Point
    [SerializeField] private float currentMP = 10; 
    [SerializeField] private float currentMaxMP = 10;
    [SerializeField] private float baseMaxMP = 10;
    [SerializeField] private float multiplierMP = 1;
        // Stamina Point
    [SerializeField] private float currentSP = 100;
    [SerializeField] private float currentMaxSP = 100;
    [SerializeField] private float baseMaxSP = 100;
    [SerializeField] private float multiplierSP = 1;
        // Stats
    [SerializeField] private float buildRange = 10;     // units
    [SerializeField] private float jumpTime = 0; // seconds
    [SerializeField] private float maxJumpTime = 0.1f;  // seconds
        // Statuses
    [SerializeField] private bool isMoving = false;
    [SerializeField] private bool isOnGround = false;
    [SerializeField] private bool isJumping = false;
        // Movements
            // Acceleration
    [SerializeField] private float groundAccel = 15;
    [SerializeField] private float jumpAccel = 60;
    [SerializeField] private float airAccel = 9;
            // Max Speeds
    [SerializeField] private float maxGroundSpeed = 15;
    [SerializeField] private float maxJumpSpeed = 30;
    [SerializeField] private float maxAirSpeed = 15;

    // Getters
        // Physics Body
    public Rigidbody2D GetRigidbody() { return rb; }
        // HP
    public float GetHp() { return currentHP; }
    public float GetMaxHp() { return currentMaxHP; }
        // MP
    public float GetMp() { return currentMP; } 
    public float GetMaxMp() { return currentMaxMP; }
        // SP
    public float GetSp() { return currentSP; }
    public float GetMaxSp() { return currentMaxSP; }
        // Stats
    public float GetBuildRange() { return buildRange; }
    public float GetCurrentJumpTime() { return jumpTime; }
    public float GetMaxJumpTime() { return maxJumpTime; }
        // Statuses
    public bool IsMoving() { return isMoving; }
    public bool OnGround() { return isOnGround; }
    public bool IsJumping() { return isJumping; }
    public bool Alive() { return currentHP > 0; }
        // Movements
            // Accelerations
    public float GetGroundAccel() { return groundAccel; }
    public float GetJumpAccel() { return jumpAccel; }
    public float GetAirAccel() { return airAccel; }
            // Max Speeds
    public float GetMaxGroundSpeed() { return maxGroundSpeed; }
    public float GetMaxJumpSpeed() { return maxJumpSpeed; }
    public float GetMaxAirSpeed() { return maxAirSpeed; }

    // Setters
    public void SetMoving(bool status) { isMoving = status; }
    public void SetGroundStatus(bool status) { isOnGround = status; }
    public void SetJumping(bool status) { isJumping = status; }
    public void SetJumpTime(float time) 
    { 
        jumpTime = time; 
    }

    // Methods
    public void HealHp(float val)
    {
        currentHP += val;
        if (currentHP > baseMaxHP) {currentHP = baseMaxHP;}
    }
    public void HealMp(float val)
    {
        currentMP += val;
        if (currentMP > currentMaxMP) {currentMP = currentMaxMP;}
    }
    public void HealSp(float val)
    {
        currentSP += val;
        if (currentSP > currentMaxSP) {currentSP = currentMaxSP;}
    }
    public void ModifyBaseMaxHP(float val) {baseMaxHP += val;}
    public void ModifyBaseMaxMP(float val) {baseMaxMP += val;}
    public void ModifyBaseMaxSP(float val) {baseMaxSP += val;}
    public void AddJumpTime(float deltaSeconds) 
    {
        jumpTime += deltaSeconds;
    }

    // Game Functions
    public void Update()
    {
        currentMaxHP = baseMaxHP * multiplierHP;
        currentMaxMP = baseMaxMP * multiplierMP;
        currentMaxSP = baseMaxSP * multiplierSP;
    }
}
