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
}