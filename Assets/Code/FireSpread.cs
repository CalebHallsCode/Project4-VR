using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour
{
    public GameObject fireball;
    public ObjectBurning fireObj;
    public Transform fire;
    private Transform followPoint;
    //public GameObject firePrefab;
    public float interval, lifetime=10f;
    public Vector3 offset;
    public int spreadNum = 1;
    public bool canSpread;
    public Transform point;
    // Start is called before the first frame update
    void Start()
    {
        //ObjectBurning parent= GetComponentInParent<ObjectBurning>();
        if (fireObj)
        {
            fireObj.numOfFire += 1;
            fire.localScale = Vector3.one * fireObj.fireSize;
        }
        transform.localScale = Vector3.one * fireObj.fireSize;
        Destroy(gameObject,lifetime);
        StartCoroutine(Spread());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = point.position;
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
        if (fireObj)
        {
            fireObj.numOfFire -= 1;
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
