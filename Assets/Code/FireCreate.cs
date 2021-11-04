using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCreate : MonoBehaviour
{
    public GameObject fire;
    public GameObject firePoint;
    public float spreadForce;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3 (Random.Range(-1,1), Random.Range(0, 1), Random.Range(-1, 1))*spreadForce);
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Vector3 point = collision.contacts[0].point;
        GameObject newPoint=Instantiate(firePoint, point, Quaternion.identity, collision.gameObject.transform);
        FireSpread newFire=Instantiate(fire,point,Quaternion.identity).GetComponent<FireSpread>();
        newFire.point = newPoint.transform;
        newFire.fireObj = collision.gameObject.GetComponent<ObjectBurning>();
        Destroy(gameObject);
    }
}
