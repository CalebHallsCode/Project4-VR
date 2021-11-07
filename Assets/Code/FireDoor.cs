using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDoor : MonoBehaviour
{
    public FireTrigger[] triggers;
    private bool[] triggersOnFire;
    private DoorScript door;
    //private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        triggersOnFire = new bool[triggers.Length];
        door = GetComponent<DoorScript>();
        for (int i = 0;i<triggers.Length;i++)
        {
            triggers[i].triggerNum = i;
            triggers[i].door = this;
            triggersOnFire[i] = triggers[i].onFire;
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    public void SetTrigger(int num,bool onFire)
    {
        triggersOnFire[num] = onFire;
        bool open = true;
        foreach (bool trigger in triggersOnFire)
        {
            if (!trigger)
            {
                open= false;
            }
        }
        if (open)
        {
            door.SetDoor(true);
        }
    }
}
