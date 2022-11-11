using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    // Attributes
    [SerializeField] protected Character character;

    [Header("Animation")]
    [SerializeField] private Animator anim;
    [SerializeField] Transform weapon;


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

    public void Attack(float damage, float range)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), range);
        if (hit.collider != null)
        {
            ACharacter ac = hit.collider.gameObject.GetComponent<ACharacter>();
            if (ac)
            {
                ac.Damage(damage, transform);
                character.SetIsOnCombat(true);
                ac.SetIsOnCombat(true);
            }
        }
        weapon.right = Camera.main.ScreenToWorldPoint(Input.mousePosition) - weapon.position;
        anim.SetTrigger("Attack");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        character.SetGroundStatus(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        character.SetGroundStatus(false);
    }
}
