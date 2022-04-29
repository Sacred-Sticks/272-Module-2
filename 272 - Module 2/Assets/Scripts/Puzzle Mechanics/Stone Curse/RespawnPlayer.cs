using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private Transform player;
    private Transform respawnPoint;

    void Start()
    {
        player = GameObject.Find("OldMan").transform;
        respawnPoint = GameObject.Find("Respawn Point").transform;
        player.position = respawnPoint.position;
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
