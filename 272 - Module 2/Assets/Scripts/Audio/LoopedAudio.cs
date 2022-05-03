using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class LoopedAudio : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    private Rigidbody2D body;
    private AudioSource source;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        source.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (body.velocity.magnitude > 0 && !source.isPlaying)
        {
            source.Play();
            Debug.Log("Started Rope Audio");
        } else if (body.velocity.magnitude <= 0 && source.isPlaying)
        {
            Debug.Log("Stopped Rope Audio");
            source.Stop();
        }
    }
}
