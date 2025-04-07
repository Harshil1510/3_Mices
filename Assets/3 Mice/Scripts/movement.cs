using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public List<GameObject> Platform = new List<GameObject>();
    public List<GameObject> startpoint = new List<GameObject>();
    public List<GameObject> endpoint = new List<GameObject>();
    private List<int> directions = new List<int>();
    public float speed = 1.5f;

    private void Start()
    {
        for (int i = 0; i < startpoint.Count; i++) 
        {
            GameObject newPlatform = new GameObject("Platform" + (Platform.Count + 1));
            newPlatform.transform.parent = transform;
            newPlatform.AddComponent<SpriteRenderer>().color = Color.red;
            newPlatform.AddComponent<BoxCollider2D>();
            newPlatform.transform.localScale = new Vector3(2f, 0.5f, 1f);

            Vector3 position = startpoint[i].transform.position;
            Vector2 startPos = position;
            Vector2 endPos = startPos + new Vector2(5f, 0);

            newPlatform.transform.position = startPos;

            GameObject newEndPoint = new GameObject("EndPoint" + (endpoint.Count + 1));
            newEndPoint.transform.position = endPos;
            newEndPoint.transform.parent = newPlatform.transform;   
            Platform.Add(newPlatform);
            endpoint.Add(newEndPoint);
            directions.Add(1);
        }
    }

    private void Update()
    {
        int count = Mathf.Min(Platform.Count, startpoint.Count, endpoint.Count, directions.Count);

        for (int i = 0; i < count; i++)
        {
            if (Platform[i] == null || startpoint[i] == null || endpoint[i] == null)
                continue;

            Vector2 target = (directions[i] == 1) ? (Vector2)endpoint[i].transform.position : (Vector2)startpoint[i].transform.position;
            Platform[i].transform.position = Vector2.MoveTowards(Platform[i].transform.position, target, speed * Time.deltaTime);

            if (Vector2.Distance(Platform[i].transform.position, target) < 0.1f)
            {
                directions[i] *= -1;
            }
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < startpoint.Count; i++)
        {
            if (startpoint[i] == null || endpoint.Count <= i || endpoint[i] == null)
                continue;

            Gizmos.color = Color.green;
            Gizmos.DrawLine(startpoint[i].transform.position, endpoint[i].transform.position);
        }
    }
}
