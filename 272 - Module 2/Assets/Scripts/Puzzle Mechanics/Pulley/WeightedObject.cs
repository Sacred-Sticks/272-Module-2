using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedObject : MonoBehaviour
{
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIsWeighted(bool isActive)
    {
        if (isActive) body.gravityScale = 0;
        else body.gravityScale = 1;
    }
}
