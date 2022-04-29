using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactTrigger : MonoBehaviour
{
    [SerializeField] private string[] tags;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string tag in tags)
        {
            if (collision.gameObject.tag == tag)
            {
                GetComponent<AnimationEventAudio>().playSingleSound();
                break;
            }
        }
    }
}
