using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFire : MonoBehaviour
{
    public GameObject fire;
    public float coolDown = 1f;
    private bool canFire=true;
    public GameObject firePoint,thisFire;
    private bool fireOn=true;
    public AudioClip fireOnClip,fireOffClip;
    private AudioSource audio;
    //public LayerMask raycastLayer;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition = Vector2.zero;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (fireOn)
        {
            Debug.Log("enter");
            if (collision.gameObject.layer == 10)
            {
                collision.gameObject.GetComponent<FireTrigger>().Onfire();
            }
            else if (canFire)
            {
                Vector3 point = collision.contacts[0].point;
                GameObject newPoint = Instantiate(firePoint, point, Quaternion.identity, collision.gameObject.transform);
                FireSpread newFire = Instantiate(fire, point, Quaternion.identity).GetComponent<FireSpread>();
                newFire.point = newPoint.transform;
                newFire.fireObj = collision.gameObject.GetComponent<ObjectBurning>();
                audio.PlayOneShot(fireOnClip);
                StartCoroutine(CoodDown());
            }
        }
    }
    IEnumerator CoodDown()
    {
        canFire = false;
        yield return new WaitForSeconds(coolDown);
        canFire = true;
    }
    public void TurnFire(bool isOn)
    {
        fireOn = isOn;
        thisFire.SetActive(isOn);
        if (isOn)
        {
            audio.PlayOneShot(fireOnClip);
        }
        else
        {
            audio.PlayOneShot(fireOffClip);
        }
    }
}
