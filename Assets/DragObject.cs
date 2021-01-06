using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public Camera cam;
    public Transform cube;
    public float distanceFromCamera;
    private Rigidbody rb;

    private void Start()
    {
        distanceFromCamera = Vector3.Distance(cube.position, cam.transform.position);
        rb = cube.GetComponent<Rigidbody>();
    }

    private Vector3 lastPos;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = distanceFromCamera;
            pos = cam.ScreenToWorldPoint(pos);
            //cube.position = new Vector3(pos.x,cube.position.y, pos.z);
            rb.velocity = (pos - cube.position) * 10;
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = Vector3.zero;
        }
        
        
    }
}
