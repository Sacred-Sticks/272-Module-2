using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AnimationEventAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] randomFromList;
    [SerializeField] private AudioClip singleSound;
    [Space]
    private AudioSource soundSource;


    // Update is called once per frame
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }

    public void playRandomSound()
    {
        AudioClip clip = randomFromList[Random.Range(0, randomFromList.Length - 1)];
        soundSource.clip = clip;
        soundSource.Play();
    }

    public void playSingleSound()
    {
        soundSource.clip = singleSound;
        soundSource.Play();
        Debug.Log("Played " + singleSound.name);
    }
}
