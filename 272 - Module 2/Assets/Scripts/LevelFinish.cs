using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] private float levelWaitTime;
    [SerializeField] private int nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        Invoke("loadNextScene", levelWaitTime);
    }

    private void loadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
