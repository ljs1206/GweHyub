using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // 인스펙터에 직렬화
public struct PoolingPair
{
    public PoolableMono prefab;
    public int Count;
}

[CreateAssetMenu(menuName = "SO/PoolList")]
public class PoolingListSO : ScriptableObject
{
    public List<PoolingPair> pairs;
}