using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    public GameObject fire;
    public bool onFire;
    public FireDoor door;
    public int triggerNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            fire.SetActive(true);
            onFire = true;
            door.SetTrigger(triggerNum,true);
        }
    }
}
