using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AController : MonoBehaviour
{
    // Attributes
    [SerializeField] protected ACharacter character;

    // Abstracts
    public abstract void FixedUpdate();

    // Methods
    protected void UpdateMovement(Vector2 vector) 
    {
        if (!vector.Equals(Vector2.zero))
        {
            character.GetRigidbody().AddForce(vector);
        }
    }

    protected void SetDrag(float val) 
    {
        character.GetRigidbody().drag = val;
    }

    // Functions

    void OnTriggerStay2D() {
        character.SetGroundStatus(true);
    }

    void OnTriggerExit2D() {
        character.SetGroundStatus(false);
    }
}
