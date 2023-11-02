using System.Collections.Generic;
using UnityEngine;

public class BossBrain : MonoBehaviour
{
    private List<BossPattern> _patterns;
    private int _prevIdx = -1;

    [SerializeField] private float _attackDelay;
    private float _lastAtkTime = -9999f;

    private void Awake()
    {
        GetComponentsInChildren(_patterns);
    }

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
        return _patterns[rdIdx];
    }
}