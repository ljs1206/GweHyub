using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // �𸣸� �ȵ�

    #region property

    #endregion

    #region private
    [SerializeField] private PoolingListSO _poolingListSO;
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
        Cursor.visible = false; 
    }

    private void CreatePoolManager()
    {
        PoolManager.Instance = new PoolManager(transform);
        // ���⿡ �ʿ��� �ֵ� Ǯ �������� ��
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
