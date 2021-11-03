using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFire : MonoBehaviour
{
    public GameObject fire;
    public float coolDown = 1f;
    private bool canFire=true;
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
        if (canFire)
        {
            Vector3 point = collision.contacts[0].point;
            Instantiate(fire, point, Quaternion.identity, collision.transform);
            StartCoroutine(CoodDown());
        }
    }
    IEnumerator CoodDown()
    {
        canFire = false;
        yield return new WaitForSeconds(coolDown);
        canFire = true;
    }
}
