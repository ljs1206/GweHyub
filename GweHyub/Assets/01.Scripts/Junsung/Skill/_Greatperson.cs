using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Greatperson : MonoBehaviour
{
    private SpriteRenderer sp;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    public void Skill()
    {
        sp.color = Color.red;
    }
}
