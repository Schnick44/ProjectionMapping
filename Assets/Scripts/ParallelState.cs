
using UnityEngine;

public class ParallelState : AbstractState
{

    

    public override void EnterState(StateManager context) {

        // toggle switch material to closed
        Material material = context.switchGO.gameObject.GetComponent<Renderer>().material;
        material.SetTexture("_BaseMap", context.m_Closed);
        Debug.Log(material);

        // particles: get moving again


        // lamp: set emission to rgb(191, 109, 0), intensity 0.45f

    }

    public override void UpdateState(StateManager context) {

    }

}
