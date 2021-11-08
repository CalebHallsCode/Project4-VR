using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class PlayerMove : MonoBehaviour
{
    public int speed = 1;
    public XRNode handRole = XRNode.LeftHand;
    Rigidbody _rigidbody;
    Transform camTrans;
    void Start()
    {
        handleVRStart();
    }

    void Update()
    {
        handleVRUpdate();
    }
    void handleVRStart()
    {
        camTrans = Camera.main.transform;
        _rigidbody = GetComponent<Rigidbody>();

    }
    void handleVRUpdate()
    {
        InputDevices.GetDeviceAtXRNode(handRole).TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 direction);
        Vector3 moveDir = camTrans.forward * direction.y + camTrans.right * direction.x;
        moveDir.y = _rigidbody.velocity.y;
        _rigidbody.velocity = moveDir * speed;

    }
}
