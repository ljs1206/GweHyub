using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public static PoolManager Instance;

    private Dictionary<string, Pool<PoolableMono>> _pools
                        = new Dictionary<string, Pool<PoolableMono>>();
    private Transform _trmParent;

    public PoolManager(Transform trmParent)
    {
        _trmParent = trmParent;
    }

    public void CreatePool(PoolableMono prefab, int count = 10)
    {
        Pool<PoolableMono> pool = new Pool<PoolableMono>(prefab, _trmParent, count);
        _pools.Add(prefab.gameObject.name, pool); // ��ųʸ��� ����Ѵ�.
    }

    public PoolableMono Pop(string name)
    {
        if (!_pools.ContainsKey(name))
        {
            Debug.LogError($"Prefab dose ont exist on pool : {name}");
            return null;
        }

        PoolableMono item = _pools[name].Pop();
        item.Init();
        return item;
    }

    public void Push(PoolableMono obj)
    {
        _pools[obj.name].push(obj);
    }
}