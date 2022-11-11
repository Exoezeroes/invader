using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ACharacter
{
#pragma warning disable 0649
    [Header("Stats")]
    [SerializeField] private float knockbackPower;
    [SerializeField] private float damageMin;
    [SerializeField] private float damageMax;
#pragma warning restore 0649
    void OnCollisionEnter2D(Collision2D col)
    {
        Character ac = col.gameObject.GetComponent<Character>();
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
