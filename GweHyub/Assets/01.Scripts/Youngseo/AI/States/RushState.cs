using UnityEngine;

public class RushState : AIState
{
    private Vector3 _dir;
    [SerializeField] private float _speed = 10f;
    
    public override void OnEnterState()
    {
        transform.localScale = new Vector3(transform.position.x < _brain.PlayerTrm.position.x ? -1 : 1, 1, 1);
        
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