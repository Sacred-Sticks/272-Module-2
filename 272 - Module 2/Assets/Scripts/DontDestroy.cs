using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.Find("Musics") != gameObject)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
