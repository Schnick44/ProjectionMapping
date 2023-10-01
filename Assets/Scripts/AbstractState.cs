
using UnityEngine;

public abstract class AbstractState
{
    public abstract void enterState(StateManager context);

    public abstract void updateState(StateManager context);
}
