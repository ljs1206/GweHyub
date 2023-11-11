using UnityEngine;

public class Skills : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [Header("Overlap")]
    [SerializeField]
    private Vector2 point;
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask layer;

    protected Collider2D[] CheckEnemy()
    {
        return Physics2D.OverlapCircleAll((Vector2)transform.position + point, radius, layer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + point, radius);
    }
}
