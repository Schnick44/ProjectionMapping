using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class OnHover : MonoBehaviour
{
    float hover_opacity = 0.5f;
    MeshRenderer m_Renderer;
    Color m_Color;

    private GameObject TextGameObject;
    private TextMesh m_TextMesh;

    public Vector3 DisplayLocation = new Vector3(0, 0, 0);
    public Vector3 DisplayRotation = new Vector3(0, 0, 0);

    private const string label = "The count is:";
    private int i = 0;

    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        m_Color = m_Renderer.material.color;

        TextGameObject = new GameObject();
        TextGameObject.name = "TextGameObject";
        m_TextMesh = TextGameObject.AddComponent(typeof(TextMesh)) as TextMesh;
        m_TextMesh.text = "init";
    }
    void OnMouseOver()
    {
        Debug.Log("over");

        m_Color.a = hover_opacity;

        m_TextMesh.text = label + i;
        i++;
    }

    void OnMouseExit()
    {
        Debug.Log("exit");
        m_Color.a = 1f;

        m_TextMesh.text = "";
    }
}
