using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    /** state machine design pattern
        might be a little overkill considering we have only 2 states
        with no big intermissions but i thought it might be fun
        ¯\_(ツ)_/¯
     */
    // tracks out current state
    AbstractState currentState;

    // every possible state instanciated
    ParallelState parallelState = new ParallelState();
    SequentialState sequentialState = new SequentialState();

    // every object we might need:
    // switch
    // cable 2-7
    // lamppara

    // Start is called before the first frame update
    void Start()
    {
        // initialize parallel as default
        currentState = parallelState;
        currentState.enterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.updateState(this);
    }

    void switchState(AbstractState futureState) {
        currentState = futureState;
        currentState.enterState(this);
    }
}
