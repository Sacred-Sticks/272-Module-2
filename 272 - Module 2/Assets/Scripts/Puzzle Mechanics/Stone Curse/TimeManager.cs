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
        StartCoroutine("StartTimer");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if (numRespawns > 0 && canStartTimer)
        {
            Debug.Log("Timer Ran Out, causing respawn");
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

    private void SpawnStatue()
    {
        GameObject statue = Instantiate(stoneStatue, player.position, player.rotation);
        statue.GetComponent<SpriteRenderer>().flipX = player.GetComponent<SpriteRenderer>().flipX;
        canStartTimer = true;
        numRespawns--;
        canSpawn = false;
        timer = waitTime;
        Debug.Log("Statue Spawned");
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
