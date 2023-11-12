using UnityEngine;

public class RushState : AIState
{
    private Vector3 _dir;
    [SerializeField] private float _speed = 10f;
    
    public override void OnEnterState()
    {
        _brain.LookPlayer();
        _dir = _brain.PlayerTrm.position - _brain.transform.position;
    }

    public override void OnExitState()
    {
        
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _brain.transform.position += _dir.normalized * (Time.deltaTime * _speed);
    }
}