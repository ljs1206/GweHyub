using System.Collections.Generic;
using UnityEngine;

public class AIBrain : PoolableMono
{
    private List<AIState> _states;
    [SerializeField] private AIState _currentState;
    public Transform PlayerTrm;
    public float lastAtkTime = -9999f;

    private AgentHp _agentHp;

    private Transform _visualTrm;
    private Vector3 _prevScale;
    [SerializeField] private bool _isLookPlayer = true;

    private void Awake()
    {
        PlayerTrm = GameObject.FindWithTag("Player").transform;
        _agentHp = GetComponent<AgentHp>();
        _visualTrm = transform.Find("Visual");
        _prevScale = _visualTrm.localScale;
        
        _states = new();
        GetComponentsInChildren(_states);
        
        _states.ForEach(state => state.SetUp(this.transform));
    }

    private void Update()
    {
        _currentState.UpdateState(); //현재 스테이트를 계속 업데이트 해줌
        if (_isLookPlayer) LookPlayer();
    }

    public void ChangeState(AIState state)
    {
        _currentState.OnExitState(); //현재 스테이트를 나갈 때 실행해줄 코드 실행
        _currentState = state; //받아온 스테이트로 변경하고
        _currentState.OnEnterState(); //그 스테이트를 들어갈 때 실행해줄 코드 실행
    }

    public override void Init()
    {
        lastAtkTime = -9999f;
        _agentHp.InitHp();
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
        _currentState.OnEnterState();
    }

    public void LookPlayer()
    {
        _visualTrm.localScale = new Vector3(_prevScale.x * (transform.position.x < PlayerTrm.position.x ? -1 : 1), _prevScale.y * 1, 1);
    }
}