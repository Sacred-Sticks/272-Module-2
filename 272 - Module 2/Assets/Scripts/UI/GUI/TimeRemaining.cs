using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeRemaining : MonoBehaviour
{
    [SerializeField] private GameObject manager;

    private TextMeshProUGUI uiElement;
    private TimeManager timeManager;

    private bool canUpdate;

    // Start is called before the first frame update
    void Start()
    {
        uiElement = GetComponent<TextMeshProUGUI>();
        timeManager = manager.GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float timeRemaining = timeManager.GetTimer();
        if (!(timeRemaining < 0))
        uiElement.text = timeRemaining.ToString("F2");
    }
}
