using System.Collections;
using DG.Tweening;
using UnityEngine;

public class DeadMarch : BossPattern
{
    [SerializeField] private AIBrain _brain;
    
    public override void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        float currentTime = 0;
        float lastSpawnTime = -9999f;
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                StartCoroutine(JangSeungCoroutine());
            }

            yield return new WaitForSeconds(2f);
        }
    }

    private Vector3 GetRandomPos()
    {
        float rdRad = Random.Range(-Mathf.PI, Mathf.PI);
        return new Vector3(Mathf.Cos(rdRad), Mathf.Sin(rdRad)) * Random.Range(5, 15f) + transform.position;
    }
    
    private Vector3 GetPlayerNearRandomPos()
    {
        return (Vector3)Random.insideUnitCircle * 4f + _brain.PlayerTrm.position + Vector3.up * 10.75f;
    }

    private IEnumerator JangSeungCoroutine()
    {
        Vector3 rdPos;
        if (Random.Range(0, 100) < 70) rdPos = GetRandomPos();
        else rdPos = GetPlayerNearRandomPos();
        
        RedCircleEffect redCircle = PoolManager.Instance.Pop("RedCircle") as RedCircleEffect;
        redCircle.transform.position = rdPos + Vector3.down * 10.75f;
        redCircle.SetScale(40, 2.5f, 1.5f);
        
        yield return new WaitForSeconds(1f);
        
        Jangseung obj = PoolManager.Instance.Pop("Jangseung") as Jangseung;
        obj.transform.position = rdPos;
        obj.transform.DOMoveY(obj.transform.position.y - 7, 0.5f)
            .SetEase(Ease.InCirc);
    }
}