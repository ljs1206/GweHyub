using System;
using UnityEngine;

public class FoxMarble : PoolableMono
{
    [SerializeField] private float _speed = 15f;
    private Vector3 _dir;

    private void Awake()
    {
        Init();
    }

    public override void Init()
    {
        
    }

    private void Update()
    {
        transform.position += _dir * (Time.deltaTime * _speed);
        transform.rotation *= Quaternion.Euler(0, 0, 500 * Time.deltaTime);
    }

    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);
        _dir = transform.right;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out AgentHp agent))
        {
            agent.Damaged(10);
        }
    }
}