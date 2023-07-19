using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract void Enter();

    public abstract void Exit();

    public abstract void UpdateState();

    public abstract bool CanTransit(State state);
}

