using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f,0f,-10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    [SerializeField] private Transform target3;

    
    private void Update()
    {
        Vector3 targetPositon = target1.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPositon, ref velocity, smoothTime);
        Vector3 newPos = transform.position;
    }
}