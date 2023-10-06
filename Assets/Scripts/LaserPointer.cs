using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR.Extras;

[RequireComponent(typeof(SteamVR_LaserPointer))] // issue
public class LaserPointer : MonoBehaviour
{ 
    private SteamVR_LaserPointer laserPointer; // issue

    private void OnEnable() {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn -= HandlePointerIn;
        laserPointer.PointerIn += HandlePointerIn;
        laserPointer.PointerOut -= HandlePointerOut;
        laserPointer.PointerOut += HandlePointerOut;
    }

    private void HandlePointerIn(object sender, PointerEventArgs e) //issue
    {
        Debug.Log("[SENDER:] " + sender);
        Debug.Log("[PointerEvent:] " + e);
    }

    private void HandlePointerOut(object sender, PointerEventArgs e) // issue
    {
        Debug.Log("[SENDER:] " + sender);
        Debug.Log("[PointerEvent:] " + e);
    }
}
