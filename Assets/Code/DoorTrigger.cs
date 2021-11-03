using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorScript door;
    private List<GameObject> objectsOnTrigger;
    private bool isOpen;
    public bool openOnCollide=true;
    // Start is called before the first frame update
    void Start()
    {
        objectsOnTrigger = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpen&&objectsOnTrigger.Count > 0) {
            door.SetDoor(openOnCollide);
            isOpen = true;
        }else if (isOpen && objectsOnTrigger.Count <= 0)
        {
            door.SetDoor(!openOnCollide);
            isOpen = false;
        }
        for (int i=0;i<objectsOnTrigger.Count;i++)
        {
            if (objectsOnTrigger[i] == null)
            {
                objectsOnTrigger.RemoveAt(i);
                i -= 1;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        objectsOnTrigger.Add(collision.gameObject);
    }
    void OnCollisionExit(Collision collision)
    {
        objectsOnTrigger.Remove(collision.gameObject);
    }


}
