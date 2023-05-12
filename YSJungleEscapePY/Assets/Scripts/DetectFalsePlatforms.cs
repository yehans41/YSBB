using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFalsePlatforms : MonoBehaviour
{
    public bool hit;
    int FalseLayer = 1 << 8;
    void Update()
    {
        hit = Physics.Raycast(transform.position, transform.forward, 4, FalseLayer);
        Debug.DrawRay(transform.position, transform.forward * 4, Color.red);
        if (hit)
        {
            Debug.LogWarning("Be careful!");
        }
        else
        {
            Debug.Log("All Clear");
        }
    }
}