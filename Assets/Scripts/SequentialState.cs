
using System.Threading.Tasks;
using UnityEngine;

public class SequentialState : AbstractState
{
    Renderer m_Renderer;
    public override async void EnterState(StateManager context) {

        // Switch: set material closed
        m_Renderer = context.switchGO.gameObject.GetComponent<Renderer>();
        m_Renderer.material.SetTexture("_BaseMap", context.m_Open);
        // set switch particles to only reach half of switch
        ParticleSystem switchParticles = context.switchGO.GetComponentInChildren<ParticleSystem>();
        var switchParticlesMain = switchParticles.main;
        switchParticlesMain.startLifetime = 0.5f;

        // particles: pause particlesystems (pause())
        foreach (GameObject cable in context.GetCables()) {
            // get particles
            ParticleSystem particles = cable.GetComponentInChildren<ParticleSystem>();
            
            // cables 2-4 create jam effect
            if (cable.name == "Cable2p" || cable.name == "Cable3p" || cable.name == "Cable4p") {

                // make particles persistent (forever)
                var main = particles.main;
                main.startLifetime = 5.0f;

                // lower emission so that particles wont be flooded too early
                if (cable.name != "Cable2p") {
                    var emission = particles.emission;
                    emission.rateOverTime = 1.0f;
                }
            }

            // cables 5,6 emission to zero
            if (cable.name == "Cable5p" || cable.name == "Cable6p") {
                var emission = particles.emission;
                emission.enabled = false;
                await Task.Delay(1500);
            }

            // cable 7 translate and reduce time
            if (cable.name == "Cable7p") {
                var shape = particles.shape;
                shape.position += Vector3.forward * 0.2f;
                var main = particles.main;
                main.startLifetime = 1.7f;
            }

        }

        // reduce glow (emission to black? parallel separate material?)
        Material lampMat = context.lamp.gameObject.GetComponent<Renderer>().material;
        lampMat.SetColor("_EmissionColor", new Color(0f, 0f, 0f));
        
    }

    public override void UpdateState(StateManager context) {
        
    }

}
