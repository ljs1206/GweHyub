using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int[] Exp;

    #region property

    private int currentLevel = 1;
    public int CurrentLevel
    {
        get => currentLevel; set => currentLevel = value;
    }

    private int currentExp;
    public int CurrentExp
    {
        get => currentExp; set => currentExp = value;   
    }
    #endregion

    public void ExpUp(int upValue, Action levelUpAction) // exp를 받아온 값 만큼 높임
    {
        currentExp += upValue;
        if(currentExp >= Exp[currentLevel - 1])
        {
            currentLevel++;
            _LevelUp(levelUpAction);
        }
    }

    private void _LevelUp(Action levelUpAction) // 레벨업 할시 실행할 함수들을 불러옴
    {
        levelUpAction?.Invoke();
        CurrentLevel++;
    }
}
