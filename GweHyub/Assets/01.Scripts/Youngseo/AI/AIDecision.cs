using UnityEngine;

[RequireComponent(typeof(AITransition))]
public abstract class AIDecision : MonoBehaviour
{
    [SerializeField] protected AIBrain _brain;
    public bool IsReverse;

    public abstract bool MakeADecision();
}