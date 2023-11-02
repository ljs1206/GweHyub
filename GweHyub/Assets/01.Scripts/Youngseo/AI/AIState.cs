using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : MonoBehaviour, IState
{
    protected List<AITransition> _transitions;
    protected AIBrain _brain;

    public virtual void SetUp(Transform agent)
    {
        _brain = agent.GetComponent<AIBrain>();

        _transitions = new();
        GetComponentsInChildren(_transitions);
        
        _transitions.ForEach(transition => transition.SetUp());
    }

    public abstract void OnEnterState();

    public abstract void OnExitState();

    public virtual void UpdateState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.MakeATransition()) //만족하는 트랜지션이 있으면
            {
                _brain.ChangeState(transition.NextState); //해당 트랜지션의 다음 스테이트로 변경
            }
        }
    }
}