using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    public LayerMask raycastLayer;
    public float height = 30f,distance=50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Torch"))
        {
            Debug.Log("fire enter");
            Vector3 pos = other.transform.position;
            pos.y += height;
            RaycastHit raycastHit;
            Physics.Raycast(pos, Vector3.down, out raycastHit, distance, raycastLayer);
            if (raycastHit.collider.CompareTag("Torch"))
            {
                raycastHit.collider.GetComponent<TorchFire>().TurnFire(false);
            }
        }
    }
}
