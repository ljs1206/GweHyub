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
        float currentTime = 0;
        float lastSpawnTime = -9999f;
        
        while (currentTime < 5)
        {
            currentTime += Time.deltaTime;
            if (0.2f < Time.time - lastSpawnTime)
            {
                lastSpawnTime = Time.time;
                
                AIBrain obj;
                int rdNum = Random.Range(0, 4);
                if (rdNum == 0) obj = PoolManager.Instance.Pop("Dokkaebi") as AIBrain;
                else if (rdNum == 1) obj = PoolManager.Instance.Pop("Sammiho") as AIBrain;
                else if (rdNum == 2) obj = PoolManager.Instance.Pop("Bulgasari") as AIBrain;
                else obj = PoolManager.Instance.Pop("Ghost") as AIBrain;
            
                obj.SetPosition(GetRandomPos());
            }
            
            yield return null;
        }
    }

    private Vector3 GetRandomPos()
    {
        float rdRad = Random.Range(-Mathf.PI, Mathf.PI);
        return new Vector3(Mathf.Cos(rdRad), Mathf.Sin(rdRad)) * Random.Range(5, 10f) + transform.position;
    }
}