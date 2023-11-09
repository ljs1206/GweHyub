using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : PoolableMono
{
    //poolableMono�� ��� ���� ��� �ֵ��� T�� �� �� �ִ�.
    private Stack<T> _pool = new Stack<T>();
    private T _prefab;
    private Transform _parent;

    public Pool(T prefab, Transform parent, int count)
    {
        _prefab = prefab;
        _parent = parent;

        for (int i = 0; i < count; i++)
        {
            T obj = GameObject.Instantiate(prefab, parent);
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
            obj.gameObject.SetActive(false);
            _pool.Push(obj);
        }
    }

    public T Pop()
    {
        T obj = null;

        if (_pool.Count <= 0) // Ǯ�� ������ ����
        {
            obj = GameObject.Instantiate(_prefab, _parent);
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
        }
        else //Ǯ�� ������ �ִ�
        {
            obj = _pool.Pop();
            obj.gameObject.SetActive(true); //��Ƽ�길 �Ѽ� ������
        }

        return obj;
    }

    public void push(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Push(obj);
    }
}