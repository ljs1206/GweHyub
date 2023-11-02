using UnityEngine;
using UnityEngine.Events;

public class AgentHp : MonoBehaviour
{
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
                Debug.Log("Die");
            }
        }
    }
    [SerializeField] private int _maxHp = 3;
    public UnityEvent OnDie;

    private void Awake()
    {
        _curHp = _maxHp;
    }

    public void Damaged(int damage)
    {
        CurHp -= damage;
    }
}