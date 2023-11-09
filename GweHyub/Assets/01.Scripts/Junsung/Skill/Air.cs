using DG.Tweening;
using UnityEngine;

public class Air : Skills
{
    private ParticleSystem gonggiEffect;
    private CapsuleCollider2D capsuleCollider;

    private void Awake()
    {
        gonggiEffect = transform.Find("gonggiEffect").GetComponent<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        transform.localScale = Vector3.zero;
        capsuleCollider.enabled = false;
    }

    private void Update()
    {
        #region DebugCode
        if (Input.GetKeyDown(KeyCode.W))
        {
            capsuleCollider.enabled = true;
            PlantAir();
        }
        #endregion
    }

    public void PlantAir()
    {
        transform.DOScale(1, 0.3f).SetEase(Ease.InOutBounce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gonggiEffect.Play();
    }
}
