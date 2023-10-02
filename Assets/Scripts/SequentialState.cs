
using UnityEngine;

public class SequentialState : AbstractState
{
    Renderer m_Renderer;
    public override void EnterState(StateManager context) {

        // Switch: set material closed
        m_Renderer = context.switchGO.gameObject.GetComponent<Renderer>();
        m_Renderer.material.SetTexture("_BaseMap", context.m_Open);

        // particles: pause particlesystems (pause())


        // reduce glow (emission to black? parallel separate material?)
        Material lampMat = context.lamp.gameObject.GetComponent<Renderer>().material;
        lampMat.SetColor("_EmissionColor", new Color(0f, 0f, 0f));
        
    }

    public override void UpdateState(StateManager context) {
        
    }

}
