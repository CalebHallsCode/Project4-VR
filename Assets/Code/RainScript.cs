using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    public LayerMask raycastLayer;
    public float height = 30f,distance=50f;
    private bool canCast=true;
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
            //Debug.Log("fire enter");
            if (canCast) {
                Vector3 pos = other.transform.position;
                RayCast(pos);
            }
            
            
        }
    }
    private void RayCast(Vector3 pos)
    {
        pos.y += height;
        RaycastHit raycastHit;
        Physics.Raycast(pos, Vector3.down, out raycastHit, distance, raycastLayer);
        if (raycastHit.collider.CompareTag("Torch"))
        {
            TorchFire torch=raycastHit.collider.GetComponent<TorchFire>();
            if (torch.fireOn)
            {
                torch.TurnFire(false);
                StartCoroutine(Cooldown());
            }
        }
    }
    private IEnumerator Cooldown()
    {
        canCast = false;
        for(int i = 0; i < 5; i++)
        {
            yield return new WaitForFixedUpdate();
        }
        canCast = true;
    }
}
