using UnityEngine;

namespace _01.Scripts.Youngseo.States
{
    public class AttackState : AIState
    {
        private float _lastAtkTime = -9999f;
        [SerializeField] private float _attackDelay = 1f;
        [SerializeField] private int _damage = 3;
        
        public override void OnEnterState()
        {
            
        }

        public override void OnExitState()
        {
            
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (_lastAtkTime + _attackDelay > Time.time) return; //마지막 공격 시각 + 공격 딜레이가 현재 시각보다 작을때 밑 코드 실행
            _lastAtkTime = Time.time;

            Debug.Log($"{_damage} Damage");
        }
    }
}