using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBrain : MonoBehaviour
{
    private List<AIState> _states;
    [SerializeField] private AIState _currentState;
    public Transform PlayerTrm;

    private void Awake()
    {
        _states = new();
        GetComponentsInChildren(_states);
        
        _states.ForEach(state => state.SetUp(this.transform));
    }

    private void Update()
    {
        _currentState.UpdateState(); //현재 스테이트를 계속 업데이트 해줌
    }

    public void ChangeState(AIState state)
    {
        _currentState.OnExitState(); //현재스테이트를 나가고
        _currentState = state; //받아온 스테이트로 변경하고
        _currentState.OnEnterState(); //그 스테이트를 들어감
    }
}