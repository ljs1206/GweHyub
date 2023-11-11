using System.Collections;
using DG.Tweening;
using UnityEngine;

public class RedCircleEffect : PoolableMono
{
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Init()
    {
        _spriteRenderer.color = new Color(0.84f, 0.2f, 0.2f, 0);
        transform.localScale = Vector3.zero;
    }

    public void SetScale(int damage, float scale, float time)
    {
        StartCoroutine(DOScaleAndDOFadeCoroutine(damage, scale, time));
    }

    private IEnumerator DOScaleAndDOFadeCoroutine(int damage, float scale, float time)
    {
        transform.DOScale(new Vector3(scale, scale * 0.75f, 1), 1);
        _spriteRenderer.DOFade(0.5f, 1);
        yield return new WaitForSeconds(time);
        Collider2D[] cols = Physics2D.OverlapCapsuleAll(transform.position, new Vector2(scale, scale * 0.75f), CapsuleDirection2D.Horizontal, 0, 1 << 6);
        foreach (var col in cols)
        {
            if (col.TryGetComponent(out AgentHp agentHp))
            {
                Debug.Log(agentHp.gameObject.name);
                agentHp.Damaged(damage);
            }
        }
        _spriteRenderer.DOFade(0, 0.5f);
    }
}
