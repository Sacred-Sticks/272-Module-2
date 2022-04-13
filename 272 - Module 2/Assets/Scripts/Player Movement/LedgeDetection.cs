using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetection : MonoBehaviour
{
    [SerializeField] private string floorTag;

    private bool canClimb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == floorTag)
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == floorTag)
        {
            canClimb = false;
        }
    }

    public bool GetCanClimb()
    {
        return canClimb;
    }
}
