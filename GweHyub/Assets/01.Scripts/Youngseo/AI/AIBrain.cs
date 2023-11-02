using System.Collections.Generic;
using UnityEngine;

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
        _currentState.OnEnterState();
    }

    private void Update()
    {
        _currentState.UpdateState(); //현재 스테이트를 계속 업데이트 해줌
    }

    public void ChangeState(AIState state)
    {
        _currentState.OnExitState(); //현재 스테이트를 나갈 때 실행해줄 코드 실행
        _currentState = state; //받아온 스테이트로 변경하고
        _currentState.OnEnterState(); //그 스테이트를 들어갈 때 실행해줄 코드 실행
    }
}