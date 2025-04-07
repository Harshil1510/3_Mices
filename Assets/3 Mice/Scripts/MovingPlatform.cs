using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f; 
    public float moveDistance = 5f; 

    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(moveDistance, 0, 0); 
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        { 
            targetPosition = targetPosition == startPosition ? startPosition + new Vector3(moveDistance, 0, 0) : startPosition;
        }
    }
}