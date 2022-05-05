using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private GameObject stoneStatue;
    [SerializeField] private Transform player;
    [Space]
    [SerializeField] private int numRespawns;

    private bool canStartTimer = true;
    private bool canSpawn;

    public void SpawnStatue()
    {
        if (numRespawns > 0)
        {
            GameObject statue = Instantiate(stoneStatue, player.position, player.rotation);
            statue.GetComponent<SpriteRenderer>().flipX = player.GetComponent<SpriteRenderer>().flipX;
            canStartTimer = true;
            numRespawns--;
            canSpawn = false;
        }
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
    }
}
