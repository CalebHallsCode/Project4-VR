using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour
{
    public GameObject fireball;
    //public GameObject firePrefab;
    public float interval, lifetime=10f;
    public Vector3 offset;
    public int spreadNum = 1;
    public bool canSpread;
    // Start is called before the first frame update
    void Start()
    {
        ObjectBurning parent= GetComponentInParent<ObjectBurning>();
        if (parent)
        {
            parent.numOfFire += 1;
        }
        Destroy(gameObject,lifetime);
        StartCoroutine(Spread());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spread()
    {
        float time = 0;
        while (true)
        {
            if (canSpread)
            {
                time += Time.deltaTime;
                if (time > interval)
                {
                    time = 0;
                    for (int i=0;i<spreadNum;i++)
                    {
                        GameObject fireBall = Instantiate(fireball, transform.position+ offset, Quaternion.identity);
                    }
                    
                }
            }
            yield return null;
        }
    }
    void OnDestroy()
    {
        ObjectBurning parent = GetComponentInParent<ObjectBurning>();
        if (parent)
        {
            parent.numOfFire -= 1;
        }
    }
    //void OnTriggerEnter(Collision collision)
    //{
    //    ObjectBurning collideObj=collision.gameObject.GetComponent<ObjectBurning>();
    //    if (collideObj&& collideObj.numOfFire<=0)
    //    {
    //        collideObj.numOfFire += 1;
    //        Instantiate(firePrefab,collision.GetContact(0).point,Quaternion.identity);
    //    }
    //}
    //void OnTriggerEnter(Collider other)
    //{
    //    ObjectBurning collideObj = other.GetComponent<ObjectBurning>();
    //    if (collideObj && collideObj.numOfFire <= 0)
    //    {
    //        Instantiate(fireball, transform.position, Quaternion.identity).GetComponent<FireCreate>().spreadForce = 0 ;
    //    }
    //}
}
