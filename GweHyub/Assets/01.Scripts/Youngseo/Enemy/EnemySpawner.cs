using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _lastSpawnTime = -9999f;
    private float _currentTime = 0;

    private void Update()
    {
        if (Random.Range(0.2f, 1f) > Time.time - _lastSpawnTime) return;
        _lastSpawnTime = Time.time;

        AIBrain obj;
        int rdNum = Random.Range(0, 4);
        if (rdNum == 0) obj = PoolManager.Instance.Pop("Dokkaebi") as AIBrain;
        else if (rdNum == 1) obj = PoolManager.Instance.Pop("Sammiho") as AIBrain;
        else if (rdNum == 2) obj = PoolManager.Instance.Pop("Bulgasari") as AIBrain;
        else obj = PoolManager.Instance.Pop("Ghost") as AIBrain;
        
        obj.SetPosition(GetRandomPos());

        SpawnBoss();
    }

    private Vector3 GetRandomPos()
    {
        float rdRad = Random.Range(-Mathf.PI, Mathf.PI);
        return new Vector3(Mathf.Cos(rdRad), Mathf.Sin(rdRad)) * 25 + transform.position;
    }

    private void SpawnBoss()
    {
        if (Time.time > 3)
        {
            Debug.Log(9);
            AIBrain boss = PoolManager.Instance.Pop("Boss") as AIBrain;
            boss.SetPosition(GetRandomPos() / 5);
            enabled = false;
        }
    }
}
