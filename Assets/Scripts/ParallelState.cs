
using System;
using System.Threading.Tasks;
using UnityEngine;

public class ParallelState : AbstractState
{

    

    public override async void EnterState(StateManager context) {

        // toggle switch material to closed
        Material material = context.switchGO.gameObject.GetComponent<Renderer>().material;
        material.SetTexture("_BaseMap", context.m_Closed);
        Debug.Log(material);

        // particles: get moving again
        foreach (GameObject cable in context.GetCables()) {
            ParticleSystem particles = cable.GetComponentInChildren<ParticleSystem>();
            if (cable.name == "Cable2p" || cable.name == "Cable3p" || cable.name == "Cable4p") {

                // take care of how long particles persist
                var main = particles.main;
                // cable 3 is half as short as others
                if (cable.name == "Cable3p") {
                    main.startLifetime = 0.6f;
                } else {
                    main.startLifetime = 1.2f;
                }

                var emission = particles.emission;
                emission.rateOverTime = 3.0f;
            }

            // cable 5, 6
            if (cable.name == "Cable5p" || cable.name == "Cable6p") {
                var emission = particles.emission;
                emission.enabled = true;
                await Task.Delay(1500);
            }

            if(cable.name == "Cable7p") {
                var shape = particles.shape;
                shape.position += Vector3.forward * -0.2f;
                var main = particles.main;
                main.startLifetime = 2.44f;
            }

        }

        // lamp: set emission to rgb(191, 109, 0), intensity 0.45f
        Material lampMat = context.lamp.gameObject.GetComponent<Renderer>().material;
        lampMat.SetColor("_EmissionColor", new Color(1.02f, 0.58f, 0f));
    }

    public override void UpdateState(StateManager context) {

    }

}
