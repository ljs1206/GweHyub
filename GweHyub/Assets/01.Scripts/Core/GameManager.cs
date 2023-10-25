using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 모르면 안됨 이영서

    #region property

    #endregion

    #region private

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
    }

    private void CreateLevelManager()
    {
        LevelManager.Instance = gameObject.AddComponent<LevelManager>();
    }
}
