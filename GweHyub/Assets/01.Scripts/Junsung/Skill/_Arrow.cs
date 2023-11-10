using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class _Arrow : Skills
{
    private Animator bowAnimator;
    private Animator arrowAnimator;
    private GameObject arrow;

    [SerializeField]
    private Vector2 Size;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject child;

    private void Awake()
    {
        bowAnimator = GetComponent<Animator>();
        arrowAnimator = transform.Find("Arrow").GetComponent<Animator>();
    }

    private void Start()
    {
        print(arrowAnimator.GetBool("isAttack"));
    }

    public void Shot()
    {
        bowAnimator.SetBool("isAttack", true);
        //arrowAnimator.SetBool("isAttack", true);
    }

    public void MoveArrowEnd()
    {
        //arrowAnimator.SetBool("isAttack", false);
        bowAnimator.SetBool("isAttack", false);
    }

    public void RotateBody()
    {
        Collider2D[] cols = CheckEnemy();
        GameObject obj = cols[Random.Range(0, cols.Length)].gameObject;
        Vector3 dir = transform.position - obj.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void ShotArrow()
    {
        print(transform.GetChild(0));
        child.transform.localPosition = Vector3.zero;
        child.transform.Translate(Vector3.right * (Time.deltaTime * speed));
    }
}
