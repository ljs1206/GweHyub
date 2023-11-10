using UnityEngine;

public class ChaseState : AIState
{
    public float _speed = 3f;
    
    public override void OnEnterState()
    {
        
    }

    public override void OnExitState()
    {
        
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _brain.transform.position += (_brain.PlayerTrm.position - _brain.transform.position).normalized * (Time.deltaTime * _speed);
    }
}