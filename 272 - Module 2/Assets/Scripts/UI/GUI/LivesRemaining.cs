using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesRemaining : MonoBehaviour
{
    [SerializeField] private GameObject manager;

    private TextMeshProUGUI uiElement;
    private TimeManager timeManager;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = manager.GetComponent<TimeManager>();
        uiElement = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        uiElement.text = timeManager.GetLives().ToString();
    }
}
