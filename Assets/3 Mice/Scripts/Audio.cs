using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private static Audio background_Music;
    void Awake()
    {
        if (background_Music == null)
        {
            background_Music = this;
            DontDestroyOnLoad(background_Music);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}