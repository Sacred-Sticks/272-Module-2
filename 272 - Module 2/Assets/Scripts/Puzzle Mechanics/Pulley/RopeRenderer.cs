using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RopeRenderer : MonoBehaviour
{
    [SerializeField] private Transform[] vertexes;

    private LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = vertexes.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < vertexes.Length; i++)
        {
            lr.SetPosition(i, vertexes[i].position);
        }
    }
}
