using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BossBrain : MonoBehaviour
{
    [SerializeField] private List<BossPattern> _patterns;
    private BossPattern _currentPattern;
    private int _prevIdx = -1;

    [SerializeField] private float _attackDelay;
    private float _lastAtkTime = -9999f;

    [SerializeField] private ChaseState _chaseState;

    private void Update()
    {
        if (_attackDelay > Time.time - _lastAtkTime) return;
        _lastAtkTime = Time.time;
        
        ChoosePattern().Attack();
    }

    private BossPattern ChoosePattern()
    { 
        int rdIdx; 
        do rdIdx = Random.Range(0, _patterns.Count); 
        while (rdIdx == _prevIdx);
        _prevIdx = rdIdx;
        _currentPattern = _patterns[rdIdx];
        StartCoroutine(StopWhileAttack());
        return _patterns[rdIdx];
    }

    private IEnumerator StopWhileAttack()
    {
        float prevSpeed = _chaseState._speed;
        _chaseState._speed = 0;
        yield return new WaitForSeconds(_currentPattern._duration);
        _chaseState._speed = prevSpeed;
    }
}