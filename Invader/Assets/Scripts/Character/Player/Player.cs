using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ACharacter
{
    // Attributes
    [Header("Health Point")]
    [SerializeField] private float regenPercentHP;          // percentage of max
    [SerializeField] private float regenMultiplierHP;       // ratio of current to max
    [SerializeField] private float regenFactorHP;           // factor of multiplier (big => good)
    [SerializeField] private float minMultiplierRegenHP;    // minimum ratio
    [SerializeField] private float maxMultiplierRegenHP;    // maximum ratio

    [Header("Mana Point")]
    [SerializeField] private float regenPercentMP;
    [SerializeField] private float regenMultiplierMP;
    [SerializeField] private float regenFactorMP;
    [SerializeField] private float minMultiplierRegenMP;
    [SerializeField] private float maxMultiplierRegenMP;

    [Header("Stamina Point")]
    [SerializeField] private float regenPercentSP;
    [SerializeField] private float regenMultiplierSP;
    [SerializeField] private float regenFactorSP;
    [SerializeField] private float minMultiplierRegenSP;
    [SerializeField] private float maxMultiplierRegenSP;

    [Header("Stamina Consumption", order = 1)]
    [Header("Running", order = 2)]
    [SerializeField] private float baseRunConsumeSP = 5;
    [SerializeField] private float runConsumePercentSP;
    [SerializeField] private float runConsumeMultiplierSP;
    [SerializeField] private float runConsumeFactorSP;
    [SerializeField] private float minMultiplierRunConsumeSP;
    [SerializeField] private float maxMultiplierRunConsumeSP;

    // Setters
    public void SetRegenMultiplierHP(float multiplier)
    {
        regenMultiplierHP = Mathf.Clamp(multiplier, minMultiplierRegenHP, maxMultiplierRegenHP);
    }

    public void SetRegenMultiplierMP(float multiplier)
    {
        regenMultiplierMP = Mathf.Clamp(multiplier, minMultiplierRegenMP, maxMultiplierRegenMP);
    }

    public void SetRegenMultiplierSP(float multiplier)
    {
        regenMultiplierSP = Mathf.Clamp(multiplier, minMultiplierRegenSP, maxMultiplierRegenSP);
    }

    public void SetRunConsumeMultiplierSP(float multiplier)
    {
        runConsumeMultiplierSP = Mathf.Clamp(multiplier, minMultiplierRunConsumeSP, maxMultiplierRunConsumeSP);
    }

    // Methods
    private void NaturalRegenHP()
    {
        float baseRegen = regenPercentHP * GetMaxHP();
        if (regenMultiplierHP <= maxMultiplierRegenHP)
        {
            SetRegenMultiplierHP(regenFactorHP * GetHP() / GetMaxHP());
            
        }
        float regenAmount = baseRegen * regenMultiplierHP * Time.deltaTime;
        HealHP(regenAmount);
    }
    private void NaturalRegenMP()
    {
        float baseRegen = regenPercentMP * GetMaxMP();
        if (regenMultiplierMP <= maxMultiplierRegenMP)
        {
            SetRegenMultiplierMP(regenFactorMP * GetMP() / GetMaxHP());
        }
        float regenAmount = baseRegen * regenMultiplierMP * Time.deltaTime;
        HealMP(regenAmount);
    }
    private void NaturalRegenSP()
    {
        float baseRegen = regenPercentSP * GetMaxSP();
        if (regenMultiplierSP <= maxMultiplierRegenSP)
        {
            SetRegenMultiplierSP(regenFactorSP * GetSP() / GetMaxSP());
        }
        float regenAmount = baseRegen * regenMultiplierSP * Time.deltaTime;
        HealSP(regenAmount);
    }

    private void RunConsumeSP()
    {
        float baseConsumption = baseRunConsumeSP + runConsumePercentSP * GetMaxSP();
        if (runConsumeMultiplierSP <= maxMultiplierRunConsumeSP)
        {
            SetRunConsumeMultiplierSP(runConsumeFactorSP * (GetMaxSP() - GetSP()) / GetMaxSP());
        }
        float consumptionAmount = baseConsumption * runConsumeMultiplierSP * Time.deltaTime;
        ConsumeSP(consumptionAmount);
    }

    // Fuctions
    private void Start()
    {
        // percentage of max
        regenPercentHP = 0.1f;
        regenPercentMP = 0.08f;
        regenPercentSP = 0.3f;
        runConsumePercentSP = 0.5f;

        // factor of multiplier (bigger -> faster)
        regenFactorHP = 0.8f;
        regenFactorMP = 0.8f;
        regenFactorSP = 0.85f;
        runConsumeFactorSP = 0.9f;

        // minimum ratio
        minMultiplierRegenHP = 0.05f;
        minMultiplierRegenMP = 0.025f;
        minMultiplierRegenSP = 0.15f;
        minMultiplierRunConsumeSP = 0.2f;

        // maximum ratio
        maxMultiplierRegenHP = 0.8f;
        maxMultiplierRegenMP = 0.8f;
        maxMultiplierRegenSP = 0.9f;
        maxMultiplierRunConsumeSP = 1f;
    }
    private void FixedUpdate()
    {
        if (GetHP() < GetMaxHP()) { NaturalRegenHP(); }
        if (GetMP() < GetMaxMP()) { NaturalRegenMP(); }
        
        if (!IsRunning())
        {
            if (GetSP() < GetMaxSP()) { NaturalRegenSP(); }
        }
        else
        {
            RunConsumeSP();
        }
    }
}
