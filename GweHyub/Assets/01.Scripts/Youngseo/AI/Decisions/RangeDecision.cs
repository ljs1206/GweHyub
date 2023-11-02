using UnityEngine;

namespace _01.Scripts.Youngseo.Decisions
{
    public class RangeDecision : AIDecision
    {
        [SerializeField] private float _range = 1f;

        public override bool MakeADecision()
        {
            return Vector3.Distance(transform.position, _brain.PlayerTrm.position) < _range;
        }
    }
}