using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverManager : MonoBehaviour
{
    float hover_opacity = 0.5f;
    MeshRenderer m_Renderer;

    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }
    void OnMouseOver()
    {
        m_Renderer.material.color.a = hover_opacity;
    }

    void OnMouseExit()
    {
        m_Renderer.material.color.a = 1f;
    }
}
