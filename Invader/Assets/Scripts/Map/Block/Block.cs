using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    // Backing Fields
    private float _MaxHealth;

    // Properties
    public uint Id { get; protected set; }
    public Sprite Sprite { get; private set; }
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
    private void SetSprite()
    {
        Sprite = AtlasLoader.GetSprite(Name);
        gameObject.AddComponent<SpriteRenderer>().sprite = Sprite;
    }
    protected void CreateCollider()
    {
        gameObject.AddComponent<BoxCollider2D>();
    }

    protected virtual void Start()
    {
        SetSprite();
    }
}
