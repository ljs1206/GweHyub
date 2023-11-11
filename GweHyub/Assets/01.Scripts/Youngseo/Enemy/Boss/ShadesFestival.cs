using System.Collections;
using UnityEngine;

public class ShadesFestival : BossPattern
{
    public override void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        for (int i = 0; i < 25; i++)
        {
            AIBrain obj;
            int rdNum = Random.Range(0, 4);
            if (rdNum == 0) obj = PoolManager.Instance.Pop("Dokkaebi") as AIBrain;
            else if (rdNum == 1) obj = PoolManager.Instance.Pop("Sammiho") as AIBrain;
            else if (rdNum == 2) obj = PoolManager.Instance.Pop("Bulgasari") as AIBrain;
            else obj = PoolManager.Instance.Pop("Ghost") as AIBrain;
        
            obj.SetPosition(GetRandomPos());
            yield return new WaitForSeconds(0.2f);
        }
    }

    private Vector3 GetRandomPos()
    {
        float rdRad = Random.Range(-Mathf.PI, Mathf.PI);
        return new Vector3(Mathf.Cos(rdRad), Mathf.Sin(rdRad)) * Random.Range(3, 6f) + transform.position;
    }
}