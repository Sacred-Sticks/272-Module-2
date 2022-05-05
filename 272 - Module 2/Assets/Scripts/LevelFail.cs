using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFail : MonoBehaviour
{
    [SerializeField] private GameObject manager;
    [SerializeField] private float levelWaitTime;

    private LivesManager livesManager;

    private void Start()
    {
        livesManager = manager.GetComponent<LivesManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Invoke("RespawnPlayer", levelWaitTime);
    }

    private void RespawnPlayer()
    {
        livesManager.SpawnStatue();
    }
}
