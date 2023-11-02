using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 모르면 안됨

    #region property

    #endregion

    #region private
    private PoolingListSO _poolingListSO;
    #endregion

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Same Object is Runing");
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        CreateLevelManager();
        CreatePoolManager();
    }

    private void CreatePoolManager()
    {
        PoolManager.Instance = new PoolManager(transform);
        // 여기에 필요한 애들 풀 만들어줘야 함
        foreach (PoolingPair pair in _poolingListSO.pairs)
        {
            PoolManager.Instance.CreatePool(pair.prefab, pair.Count);
        }
    }

    private void CreateLevelManager()
    {
        LevelManager.Instance = gameObject.AddComponent<LevelManager>();
    }
}
