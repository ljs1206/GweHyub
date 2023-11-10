using UnityEngine;
using UnityEngine.Events;

public class AgentHp : MonoBehaviour
{
    [SerializeField] private int _expAmount;
    
    private int _curHp;

    public int CurHp
    {
        get => _curHp;
        set
        {
            _curHp = value;
            _curHp = Mathf.Clamp(_curHp, 0, _maxHp);
            if (_curHp <= 0)
            {
                OnDie?.Invoke();
                if (TryGetComponent(out AIBrain brain))
                {
                    PoolManager.Instance.Push(brain);
                    LevelManager.Instance.ExpUp(_expAmount, null);
                }
            }
        }
    }
    [SerializeField] private int _maxHp = 3;
    public UnityEvent OnDie;

    private void Awake()
    {
        CurHp = _maxHp;
    }

    public void Damaged(int damage)
    {
        CurHp -= damage;
    }
}