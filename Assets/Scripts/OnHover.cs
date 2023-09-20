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

    public TMP_Text WorldText;

    private const string label = "The count is:";
    private int i = 0;

    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        m_Color = m_Renderer.material.color;

    }
    void OnMouseOver()
    {
        m_Color.a = hover_opacity;
        WorldText.text = label + i;
        i++;
    }

    void OnMouseExit()
    {
        WorldText.text = "";
        m_Color.a = 1f;
    }
}
