using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] private ACharacter target;

    void Update()
    {
        Slider bar = GetComponent<Slider>();
        bar.value = target.GetHP();
    }
}
