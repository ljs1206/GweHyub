using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PileDriving : BossPattern
{
    [SerializeField] private Transform _pileTrm;
    
    public override void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        RedCircleEffect redCircle = PoolManager.Instance.Pop("RedCircle") as RedCircleEffect;
        redCircle.transform.position = transform.position + Vector3.down * 2;
        redCircle.SetScale(50, 10, 3.5f);
        yield return new WaitForSeconds(2f);
        _pileTrm.gameObject.SetActive(true);
        _pileTrm.position = transform.position + Vector3.up * _pileTrm.lossyScale.y;
        _pileTrm.DOMoveY(_pileTrm.position.y + 2, 1);
        yield return new WaitForSeconds(1f);
        _pileTrm.DOMoveY(_pileTrm.position.y - 14f, 0.5f).SetEase(Ease.InCubic).OnComplete(() => _pileTrm.gameObject.SetActive(false));
    }
}