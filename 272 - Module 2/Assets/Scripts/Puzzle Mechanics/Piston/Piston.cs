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
        moveRight += sprite.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        sprite.localPosition = new Vector3(moveRight, 0, 0);
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

        transform.localScale = new Vector3(currentSize, 1, 1);
    }

    public void togglePistonActive()
    {
        pistonActive = !pistonActive;
    }
}
