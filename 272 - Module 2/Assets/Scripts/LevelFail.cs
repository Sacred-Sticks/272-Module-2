using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFail : MonoBehaviour
{
    [SerializeField] private GameObject manager;
    [SerializeField] private float levelWaitTime;

    private TimeManager timeManager;

    private void Start()
    {
        timeManager = manager.GetComponent<TimeManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Invoke("RespawnPlayer", levelWaitTime);
    }

    private void RespawnPlayer()
    {
        timeManager.SpawnStatue();
    }
}
