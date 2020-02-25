
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdownoculus : MonoBehaviour
{
    public GameObject pointer;
    private void Awake()
    {
        GraphicRaycaster gr = GetComponent<GraphicRaycaster>();
        OVRRaycaster OVRrc = null;
        if (gr != null)
        {
            gr.enabled = false;
            OVRrc = gameObject.AddComponent<OVRRaycaster>();
            OVRrc.pointer = pointer;
            OVRrc.blockingObjects = OVRRaycaster.BlockingObjects.All;
        }
    }
}