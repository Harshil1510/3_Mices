using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Camera : MonoBehaviour
{
    internal static object mainCamera;
    internal static Camera MainCamera;
    internal static Camera main;
    public GameObject target;
    internal float orthographicSize;

    internal Vector2 ScreenToWorldPoint(Vector3 vector3)
    {
        throw new NotImplementedException();
    }

    internal Vector3 WorldToViewportPoint(Vector3 position)
    {
        throw new NotImplementedException();
    }

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, -10);   
    }
}
