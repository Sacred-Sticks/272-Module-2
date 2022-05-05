using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesRemaining : MonoBehaviour
{
    [SerializeField] private GameObject manager;

    private TextMeshProUGUI uiElement;
    private LivesManager livesManager;

    // Start is called before the first frame update
    void Start()
    {
        livesManager = manager.GetComponent<LivesManager>();
        uiElement = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        uiElement.text = "Lives: " + livesManager.GetLives().ToString();
    }
}
