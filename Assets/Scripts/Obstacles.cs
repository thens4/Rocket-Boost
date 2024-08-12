using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    Collider obstaclesCollider;
    void Start()
    {
        obstaclesCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            obstaclesCollider.enabled = false;


        }
    }
    

}
