
using UnityEngine;

public abstract class AbstractState
{
    // it feels wrong but uppercase function names are convention
    public abstract void EnterState(StateManager context);

    public abstract void UpdateState(StateManager context);
}
