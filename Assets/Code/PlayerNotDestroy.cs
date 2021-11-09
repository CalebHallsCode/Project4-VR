using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotDestroy : MonoBehaviour
{
    public static PlayerNotDestroy player;
    // Start is called before the first frame update
    void Awake()
    {
        if (player != null)
        {
            Destroy(gameObject);
        }
        else
        {
            player = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
