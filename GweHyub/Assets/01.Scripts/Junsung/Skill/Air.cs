using DG.Tweening;
using UnityEngine;

public class Air : MonoBehaviour
{
    public void PlantAir()
    {
        transform.DOScale(1, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
