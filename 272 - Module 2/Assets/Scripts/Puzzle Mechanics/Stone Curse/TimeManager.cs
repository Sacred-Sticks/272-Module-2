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
    private bool canSpawn;

    private void Start()
    {
        timer = waitTime;
        StartCoroutine("StartTimer");
    }

    // Update is called once per frame
    void Update()
    {
        if (numRespawns > 0) timer -= Time.deltaTime;
        else numRespawns = 0;
        //Debug.Log(timer);
        if (numRespawns > 0 && canStartTimer)
        {
            //Debug.Log("Timer Ran Out, causing respawn");
            StartCoroutine("StartTimer");
        }
    }

    IEnumerator StartTimer()
    {
        int currentLife = numRespawns;
        canSpawn = true;
        canStartTimer = false;
        yield return new WaitForSeconds(waitTime);
        if (currentLife == numRespawns) SpawnStatue();
        
    }

    public void SpawnStatue()
    {
        if (numRespawns > 0)
        {
            GameObject statue = Instantiate(stoneStatue, player.position, player.rotation);
            statue.GetComponent<SpriteRenderer>().flipX = player.GetComponent<SpriteRenderer>().flipX;
            canStartTimer = true;
            numRespawns--;
            canSpawn = false;
            timer = waitTime;
            //Debug.Log("Statue Spawned");
        }
    }

    public float GetTimer()
    {
        return timer;
    }

    public float GetLives()
    {
        return numRespawns;
    }

    public void ResetTimer()
    {
        if (numRespawns >= 1) {
            SpawnStatue();
        }
        if (numRespawns > 0)
        {
            timer = waitTime;
        }
    }
}
