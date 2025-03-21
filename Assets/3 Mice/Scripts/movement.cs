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
        for (int i = 0; i < 20; i++)
        {
            GameObject newPlatform = new GameObject("Platform" + (Platform.Count + 1));
            newPlatform.transform.parent = transform; 
            newPlatform.AddComponent<SpriteRenderer>().color = Color.red; 
            newPlatform.AddComponent<BoxCollider2D>(); 
            newPlatform.transform.localScale = new Vector3(2f, 0.5f, 1f); 

            GameObject newStartPoint = new GameObject("StartPoint" + (startpoint.Count + 1));
            GameObject newEndPoint = new GameObject("EndPoint" + (endpoint.Count + 1));

            Vector2 startPos = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            Vector2 endPos = startPos + new Vector2(5f, 0);

            newPlatform.transform.position = startPos;
            newStartPoint.transform.position = startPos;
            newEndPoint.transform.position = endPos;

            Platform.Add(newPlatform);
            startpoint.Add(newStartPoint);
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
        if (Platform.Count > 0 && startpoint.Count > 0 && endpoint.Count > 0)
        {
            for (int i = 0; i < Platform.Count; i++) 
            {
                if (Platform[i] == null || startpoint[i] == null || endpoint[i] == null)
                    continue;
                Gizmos.color = Color.green;
                Gizmos.DrawLine(startpoint[i].transform.position, endpoint[i].transform.position);
            }
        }
    }
}
