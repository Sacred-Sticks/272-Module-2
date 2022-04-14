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

    // Update is called once per frame
    void Update()
    {
        if (canStartTimer && numRespawns > 0) StartCoroutine("StartTimer");
    }

    IEnumerator StartTimer()
    {
        canStartTimer = false;
        yield return new WaitForSeconds(waitTime);
        Instantiate(stoneStatue, player.position, player.rotation);
        canStartTimer = true;
        numRespawns--;
    }
}
