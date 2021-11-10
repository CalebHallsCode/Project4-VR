using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class musicScript : MonoBehaviour
{
    public AudioSource _audiosource;

    // Start is called before the first frame update
    void Start()
    {

        _audiosource = GetComponent<AudioSource>();
        _audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
