using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    [SerializeField] protected AIBrain _brain;
    public bool IsReverse;

    public abstract bool MakeADecision();
}