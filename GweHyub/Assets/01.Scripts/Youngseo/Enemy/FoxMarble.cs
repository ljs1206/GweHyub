using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class FoxMarble : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;
    private Vector3 _dir;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        _dir = transform.right;
    }

    private void Update()
    {
        transform.position += _dir * (Time.deltaTime * _speed);
        transform.rotation *= Quaternion.Euler(0, 0, 500 * Time.deltaTime);
    }
}