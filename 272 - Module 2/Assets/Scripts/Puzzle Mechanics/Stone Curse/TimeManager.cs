using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private GameObject stoneStatue;
    [SerializeField] private Transform player;
    [Space]
    [SerializeField] private int numRespawns;

    private bool canStartTimer = true;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (canStartTimer && numRespawns > 0) StartCoroutine("StartTimer");
        timer -= Time.deltaTime;
    }

    IEnumerator StartTimer()
    {
        timer = waitTime;
        canStartTimer = false;
        yield return new WaitForSeconds(waitTime);
        GameObject statue = Instantiate(stoneStatue, player.position, player.rotation);
        statue.GetComponent<SpriteRenderer>().flipX = player.GetComponent<SpriteRenderer>().flipX;
        canStartTimer = true;
        numRespawns--;
    }

    public float GetTimer()
    {
        return timer;
    }

    public float GetLives()
    {
        return numRespawns;
    }
}
