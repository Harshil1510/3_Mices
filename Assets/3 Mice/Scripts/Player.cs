/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject platform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trigger"))
        {
            Instantiate(platform, new Vector3(0, -16,0),Quaternion.identity);
        }
    }   
}

*/
internal class Player
{
}