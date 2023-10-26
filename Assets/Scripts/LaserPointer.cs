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
        laserPointer.PointerColliding += HandleCollision;
    }

    private void HandlePointerIn(object sender, PointerEventArgs e) //issue
    {

        // IPointerEnterHandler pointerEnterHandler = e.target.GetComponent<IPointerEnterHandler>();
        if (e.target.GetComponent<OnHover>())
        {
            e.target.GetComponent<OnHover>().OnPointerEnter();
        }

    }

    private void HandleCollision(object sender, PointerEventArgs e)
    {
        
    }

    private void HandlePointerOut(object sender, PointerEventArgs e) // issue
    {
        if (e.target.GetComponent<OnHover>())
        {
            e.target.GetComponent<OnHover>().OnPointerExit();
        }
    }
}
