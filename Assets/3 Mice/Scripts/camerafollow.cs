using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public List<Transform> players;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (players.Count == 0)
        {
            return;
        }
        Vector3 centerPoint = GetCenterPoint();
        Vector3 targetPosition = centerPoint + offset;
        targetPosition.z = -10f;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
    Vector3 GetCenterPoint()
    {
        if (players.Count == 1)
        {
            return players[0].position;
        }
        Bounds bounds = new Bounds(players[0].position, Vector3.zero);
        for (int i = 1; i < players.Count; i++)
        {
            bounds.Encapsulate(players[i].position);
        }
        return bounds.center;
    }
}