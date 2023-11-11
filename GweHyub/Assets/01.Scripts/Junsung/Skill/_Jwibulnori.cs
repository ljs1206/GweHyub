using System;
using UnityEngine;

public class _Jwibulnori : Skills
{
    [SerializeField]
    private float rotateSpeed;

    private void Update()
    {
        transform.Rotate(-Vector3.forward, Time.deltaTime * rotateSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out AgentHp agent))
        {
            agent.Damaged(_damage);
        }
    }
}
