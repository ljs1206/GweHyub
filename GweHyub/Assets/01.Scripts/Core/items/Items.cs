using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct item // 전통놀이 아이템
{
    public string name;
    public int power;
    public float attackDelay;
    public float range;
    public float speed;
    public float holdingTime;
    public float knockBackRange;
    public float Size;
    public float chainCount;

    public UnityEvent skill;
}

[CreateAssetMenu(menuName = "SO/item")]
public class Items : ScriptableObject
{
    public item[] _items;
}
