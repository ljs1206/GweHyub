using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicAttack : AIState
{
    [SerializeField] private float _speed = 3f;
    public enum AttackType { Melee, ADC}

    [SerializeField] private AttackType _currentType;
    
    private float _lastAtkTime = -9999f;
    [SerializeField] private float _attackDelay = 1f;
    [SerializeField] private int _damage = 3;

    [SerializeField] private GameObject _projectile;
    
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
        
        if (_attackDelay > Time.time - _lastAtkTime) return; //마지막 공격으로부터 흐른 시간이 공격 딜레이보다 작으면 리턴
        _lastAtkTime = Time.time;

        if (_currentType == AttackType.Melee)
        {
            Debug.Log($"{_damage} Damage");
        }
        else
        {
            Debug.Log($"{_damage} Damage");
            Vector3 dir = _brain.PlayerTrm.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Instantiate(_projectile, transform.position, Quaternion.Euler(0, 0, angle));
        }
    }
}
