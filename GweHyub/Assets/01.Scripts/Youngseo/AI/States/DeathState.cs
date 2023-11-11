using UnityEngine;

public class DeathState : AIState
{
    public override void OnEnterState()
    {
        _brain.GetComponent<AgentHp>().Damaged(1000);
    }

    public override void OnExitState()
    {
        
    }

    public override void UpdateState()
    {
        
    }
}