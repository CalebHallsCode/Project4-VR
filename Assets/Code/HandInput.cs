using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandInput : MonoBehaviour
{
    public TextMesh outText;
    public XRNode handRole = XRNode.LeftHand;
    InputDevice handController;
    void Start()
    {
        handController = InputDevices.GetDeviceAtXRNode(handRole);
    }


    void Update()
    {

        handController.TryGetFeatureValue(CommonUsages.triggerButton, out bool hTrigger);
        handController.TryGetFeatureValue(CommonUsages.primaryButton, out bool pTrigger);
        handController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool sTrigger);
        handController.TryGetFeatureValue(CommonUsages.menuButton, out bool mButton);

        if (hTrigger)
        {
            outText.text = "hTrigger";
        }
        else if (pTrigger)
        {
            outText.text = "pTrigger";
        }
        else if (sTrigger)
        {
            outText.text = "sTrigger";
        }
        else if (mButton)
        {
            outText.text = "mButton";
        }
        else
            outText.text = "none";

    }
}
