using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    // Backing Fields
    private float _MaxHealth;

    // Properties
    public uint Id { get; protected set; }
    public string Name { get; protected set; }
    public float Health { get; private set; }
    public float MaxHealth
    {
        get => _MaxHealth;
        set
        {
            Health = value;
            _MaxHealth = value;
        }
    }

    // Methods
    protected void ReduceHealth(float damage)
    {
        Health -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (Health <= 0) Destroy(gameObject);
    }

    protected Sprite LoadSprite()
    {
        return AtlasLoader.GetSprite(Name); ;
    }

    public virtual void Start()
    {
        SpriteRenderer renderer = gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = LoadSprite();
    }
}
