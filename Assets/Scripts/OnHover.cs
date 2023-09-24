using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;

public class OnHover : MonoBehaviour
{
    float hover_opacity = 0.5f;
    MeshRenderer m_Renderer;
    Color m_Color;

    // material of object, that script is attached to
    private Material m_Material;
    private Color m_MaterialColor;


    public TMP_Text WorldText;

    private const string label = "The count is:";
    private int i = 0;

    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        m_Color = m_Renderer.material.color;
        // very hacky to be able to manipulate alpha values
        m_Material = GetComponent<Renderer>().material;
        m_MaterialColor = m_Material.color;
    }
    void OnMouseOver()
    {
        m_Color.a = hover_opacity;
        WorldText.text = label + i;
        i++;
        // check for transparency and adjust if necessary
        if (m_MaterialColor.a > hover_opacity) 
        {
            m_MaterialColor.a = hover_opacity;
            m_Material.color = m_MaterialColor;
        }
    }

    void OnMouseExit()
    {
        WorldText.text = "";
        m_Color.a = 1f;
        // check transparency + adjust
        if (m_MaterialColor.a < 1f) 
        {
            m_MaterialColor.a = 1f;
            m_Material.color = m_MaterialColor;
        }
    }
}
