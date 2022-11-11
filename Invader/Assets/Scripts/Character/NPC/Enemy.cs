using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ACharacter
{
    [Header("Stats")]
    [SerializeField] private float knockbackPower;
    [SerializeField] private float damageMin;
    [SerializeField] private float damageMax;

    void OnCollisionEnter2D(Collision2D col)
    {
        ACharacter ac = col.gameObject.GetComponent<ACharacter>();
        if (ac)
        {
            float damage = Random.Range(damageMin, damageMax);
            ac.Damage(damage, transform);
            SetIsOnCombat(true);
            ac.SetIsOnCombat(true);
            Vector2 pos = (col.transform.position - transform.position).normalized;
            col.rigidbody.AddForce(pos * knockbackPower);
        }
    }
}
