using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ConstantAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip openingClip;
    [SerializeField] private AudioClip loopingClip;

    private AudioSource audioSource;
    private bool openerPlaying;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.clip = openingClip;
        audioSource.Play();
        openerPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (openerPlaying && !audioSource.isPlaying)
        {
            openerPlaying = false;
            audioSource.clip = loopingClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
