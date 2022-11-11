using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] Transform target;
#pragma warning restore 0649

    void Update()
    {
        if (target != null) { transform.position = target.position; }
    }
}
