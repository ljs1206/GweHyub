using System.Collections;
using UnityEngine;

public class Jangseung : PoolableMono
{
    [SerializeField] private float _lifeTime = 1.5f;
    
    public override void Init()
    {
        StartCoroutine(DelayPush());
    }

    private IEnumerator DelayPush()
    {
        yield return new WaitForSeconds(_lifeTime);
        PoolManager.Instance.Push(this);
    }
}