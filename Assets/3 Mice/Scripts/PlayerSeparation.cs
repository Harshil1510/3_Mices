using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeparation : MonoBehaviour
{
    public Transform[] players;  
    public float minDistance; 
    public float pushSpeed; 

    void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            for (int j = i + 1; j < players.Length; j++)
            {
                float distance = Vector2.Distance(players[i].position, players[j].position);

                if (distance < minDistance)
                {
                    Vector2 direction = (players[j].position - players[i].position).normalized;
                    float pushAmount = (minDistance - distance) / 2;
                    players[i].position -= (Vector3)(direction * pushAmount * Time.deltaTime * pushSpeed);
                    players[j].position += (Vector3)(direction * pushAmount * Time.deltaTime * pushSpeed);
                }
            }
        }
    }
}
