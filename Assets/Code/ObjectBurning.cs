using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBurning : MonoBehaviour
{
    public int numOfFire;
    public float maxHealth,fireSize=1;
    public Color onFireColor = Color.black;
    private Color startColor;
    private float damage = 1f,health;
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        renderer = GetComponent<MeshRenderer>();
        startColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        health -= damage * numOfFire * Time.deltaTime;
        if (numOfFire>0)
        {
            float lerp = 1-(health / maxHealth);
            renderer.material.color = Color.Lerp(startColor,onFireColor,lerp);
        }
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
}
