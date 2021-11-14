using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator _animator;
    AudioSource audio;
    public AudioClip openClip, closeClip;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDoor(bool open)
    {
        _animator.SetBool("Open",open);
        if (open)
        {
            audio.Stop();
            audio.PlayOneShot(openClip);
        }
        else
        {
            audio.Stop();
            audio.PlayOneShot(closeClip);
        }
    }
}
