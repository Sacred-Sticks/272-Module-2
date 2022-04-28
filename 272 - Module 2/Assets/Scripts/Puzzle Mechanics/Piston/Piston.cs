using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    [SerializeField] private bool pistonActive;
    [SerializeField] private float pistonSize;
    [SerializeField] private float timeToExtend;
    [SerializeField] private float timeToRetract;
    [Space]
    [SerializeField] private Transform sprite;
    [SerializeField] private float moveRight;

    private float currentSize;
    private bool menuPistonUsed;

    // Start is called before the first frame update
    void Start()
    {
        if (pistonActive)
        {
            currentSize = pistonSize;
        } else
        {
            currentSize = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pistonActive && currentSize < pistonSize)
        {
            currentSize = currentSize + pistonSize * Time.deltaTime / timeToExtend;
            if (currentSize > pistonSize)
            {
                currentSize = pistonSize;
            }
        } else if (!pistonActive && currentSize > 0)
        {
            currentSize = currentSize - pistonSize * Time.deltaTime / timeToRetract;
            if (currentSize < 0)
            {
                currentSize = 0;
            }
        }

        transform.localScale = new Vector3(currentSize, transform.localScale.y, transform.localScale.z);
    }

    public void togglePistonActive()
    {
        pistonActive = !pistonActive;
    }

    public void TempPistonToggle()
    {
        if (!menuPistonUsed)
        {
            menuPistonUsed = true;
            StartCoroutine("PistonTimedToggle");
        }
    }

    IEnumerator PistonTimedToggle()
    {
        togglePistonActive();
        yield return new WaitForSeconds(.25f);
        togglePistonActive();
    }
}
