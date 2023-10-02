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
    private GameObject switchGO;
    // cable 2-7
    private GameObject cable2;
    private GameObject cable3;
    private GameObject cable4;
    private GameObject cable5;
    private GameObject cable6;
    private GameObject cable7;
    // lamppara
    private GameObject lamp;

    // Start is called before the first frame update
    void Start()
    {
        // initialize parallel as default
        currentState = parallelState;
        currentState.EnterState(this);

        // switch
        switchGO = GameObject.Find("Switch");
        // cable 2-7
        cable2 = GameObject.Find("Cable2p");
        cable3 = GameObject.Find("Cable3p");
        cable4 = GameObject.Find("Cable4p");
        cable5 = GameObject.Find("Cable5p");
        cable6 = GameObject.Find("Cable6p");
        cable7 = GameObject.Find("Cable7p");
        lamp = GameObject.Find("LampParallel");

        // test that init works - it does 
        print(lamp.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    void switchState(AbstractState futureState) {
        currentState = futureState;
        currentState.EnterState(this);
    }
}
