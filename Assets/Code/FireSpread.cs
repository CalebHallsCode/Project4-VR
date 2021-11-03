using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour
{
    public GameObject fireball;
    public float interval, lifetime=10f;
    public Vector3 offset;
    public int spreadNum = 1;
    public bool canSpread;
    // Start is called before the first frame update
    void Start()
    {
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
}
