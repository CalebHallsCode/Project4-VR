using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCandle : MonoBehaviour
{
    public GameObject showObj;
    public GameObject fire;
    public bool onFire;
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
        if (collision.gameObject.CompareTag("Torch"))
        {
            Onfire();
        }
    }
    public void Onfire()
    {
        fire.SetActive(true);
        onFire = true;
        showObj.SetActive(true);
    }
}
