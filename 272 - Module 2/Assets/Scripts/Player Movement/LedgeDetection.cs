using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetection : MonoBehaviour
{
    [SerializeField] private LayerMask floorLayer;

    private bool canClimb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == floorLayer)
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == floorLayer)
        {
            canClimb = false;
        }
    }

    public bool GetCanClimb()
    {
        return canClimb;
    }
}
