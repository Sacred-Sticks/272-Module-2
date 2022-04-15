using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisePlayerHeight : MonoBehaviour
{
    [SerializeField] private Vector3 yPositionBoost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            collision.gameObject.transform.position += yPositionBoost;
        }
    }
}
