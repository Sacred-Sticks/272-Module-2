using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlank : MonoBehaviour
{
    [SerializeField] private Transform platform;
    [SerializeField] private float lowValue;

    private void Update()
    {
        if (platform.position.y <= transform.position.y + lowValue)
        {
            Destroy(gameObject);
        }
    }
}
