using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    private List<AIDecision> _decisions;
    public AIState NextState;

    public void SetUp()
    {
        _decisions = new();
        GetComponents(_decisions);
    }

    public bool MakeATransition()
    {
        bool result = false;
        foreach (var decision in _decisions)
        {
            result = decision.MakeADecision();
            if (decision.IsReverse)
            {
                result = !result;
            }
            if (result == false) return false; //하나라도 만족하지 않는 디씨젼이 있다면 return false;
        }

        return result;
    }
}