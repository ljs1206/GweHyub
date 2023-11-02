using UnityEngine;

public class _Guseulchigi : MonoBehaviour
{
    [Header("Overlap")]
    [SerializeField]
    private Vector2 size;
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask layer;

    private void Attack

    private Collider2D[] CheckEnemy()
    {
        return Physics2D.OverlapCircleAll(size, radius, layer);
    }
}
