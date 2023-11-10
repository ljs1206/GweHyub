using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private LayerMask _layer;
    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(x, y).normalized * (Time.deltaTime * _speed);

        if (Input.GetButtonDown("Jump"))
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 10, _layer);
            foreach (var col in cols)
            {
                if (col.TryGetComponent(out AgentHp agentHp))
                {
                    Debug.Log(agentHp.gameObject.name);
                    agentHp.Damaged(50);
                }
            }
        }
    }
}