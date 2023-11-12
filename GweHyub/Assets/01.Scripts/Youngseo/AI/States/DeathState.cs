using UnityEngine;

public class DeathState : AIState
{
    public override void OnEnterState()
    {
        PoolManager.Instance.Push(_brain);
    }

    public override void OnExitState()
    {
        
    }

    public override void UpdateState()
    {
        
    }
}