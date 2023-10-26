using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using Valve.VR.Extras;

public class OnHover : MonoBehaviour
{
    float hover_opacity = 0.5f;
    MeshRenderer m_Renderer;
    Color m_Color;

    // material of object, that script is attached to
    private Material m_Material;
    private Color m_MaterialColor;


    public TMP_Text WorldText;
    public string Voltage;
    public string Amperage;

    private string label;
    private MeshRenderer m_TextRenderer;
    private MeshRenderer m_BgRenderer;


    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        m_Color = m_Renderer.material.color;
        // very hacky to be able to manipulate alpha values
        m_Material = GetComponent<Renderer>().material;
        m_MaterialColor = m_Material.color;

        if (Voltage == null) Voltage = "6V";
        if (Amperage == null) Amperage = "600mA";
        label =" Spannung: " + Voltage + "\nStromstärke: " + Amperage;

        m_TextRenderer = WorldText.GetComponent<MeshRenderer>();
        m_TextRenderer.enabled = false;

        m_BgRenderer = WorldText.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        m_BgRenderer.enabled = false;

    }
    public void OnPointerEnter()
    {
        Debug.Log("pointer enter detected");
        m_Color.a = hover_opacity;
        WorldText.text = label;
        // check for transparency and adjust if necessary
        if (m_MaterialColor.a > hover_opacity) 
        {
            m_MaterialColor.a = hover_opacity;
            m_Material.color = m_MaterialColor;
        }

        m_TextRenderer.enabled = true;
        m_BgRenderer.enabled = true;
    }

    public void OnPointerExit()
    {
        WorldText.GetComponent<MeshRenderer>();
        m_Color.a = 1f;
        // check transparency + adjust
        if (m_MaterialColor.a < 1f) 
        {
            m_MaterialColor.a = 1f;
            m_Material.color = m_MaterialColor;
        }

        m_TextRenderer.enabled = false;
        m_BgRenderer.enabled = false;
    }
}
