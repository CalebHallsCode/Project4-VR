using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCreate : MonoBehaviour
{
    public GameObject fire;
    public float spreadForce;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3 (Random.Range(-1,1), Random.Range(0, 1), Random.Range(-1, 1))*spreadForce);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Vector3 point = collision.contacts[0].point;
        Instantiate(fire,point,Quaternion.identity,collision.transform);
        Destroy(gameObject);
    }
}
