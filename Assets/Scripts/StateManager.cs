using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    /** state machine design pattern
        might be a little overkill considering we have only 2 states
        with no big intermissions but i thought it might be fun
        ¯\_(ツ)_/¯
     */
    // tracks our current state
    AbstractState currentState;

    // every possible state instanciated
    private ParallelState parallelState = new ParallelState();
    SequentialState sequentialState = new SequentialState();

    // every object we might need:
    // switch
    public GameObject switchGO;
    // cable 2-7
    public GameObject cable2;
    public GameObject cable3;
    public GameObject cable4;
    public GameObject cable5;
    public GameObject cable6;
    public GameObject cable7;
    // lamppara
    public GameObject lamp;

    private List<GameObject> cables;

    // also do textures bc i'm dumb and cant find how to toggle textures
    public Texture m_Open, m_Closed;

    // Start is called before the first frame update
    void Start()
    {
        // initialize parallel as default
        currentState = parallelState;
        cables = new List<GameObject> { cable2, cable3, cable4, cable5, cable6, cable7 };

        // do things supposed to happen when parallel state is just switched to
        //currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        if (Input.anyKeyDown) {
            Debug.Log("input registered");
            if (currentState is ParallelState) {
                currentState = sequentialState;
                currentState.EnterState(this);
            } else {
                currentState = parallelState;
                currentState.EnterState(this);
            }
        }
    }

    void switchState(AbstractState futureState) {
        currentState = futureState;
        currentState.EnterState(this);
    }

    public List<GameObject> GetCables() {
        return cables;
    }
}
