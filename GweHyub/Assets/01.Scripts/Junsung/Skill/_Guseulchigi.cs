using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class _Guseulchigi : Skills

{

    [Header("MoveVariable")]
    [SerializeField]
    private item guseulchigi;
    [SerializeField]
    private float moveValue;

    private List<Vector3> distanceRank = new();
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Attack()
    {
        if (CheckEnemy()[0] == null)
        {
            float rand = Random.Range(0, 2 * Mathf.PI);
            Vector3 roate = new Vector3(Mathf.Sin(rand), Mathf.Cos(rand) * moveValue);

            transform.DOMove(roate, 0.5f);

            return;
        }

        for(int i = 0; i < CheckEnemy().Length; i++)
        {
            distanceRank.Add(CheckEnemy()[i].transform.position - player.transform.position);
        }

        distanceRank.Sort(compare1);

        StartCoroutine(chainAttack());
    }

    int compare1(Vector3 a, Vector3 b)
    {
        return a.magnitude < b.magnitude ? -1 : 1;
    }

    private IEnumerator chainAttack()
    {
        transform.DOMove(distanceRank[0], 0.3f);

        yield return new WaitForSeconds(0.1f);

        for (int i = 1; i < guseulchigi.chainCount + 1; i++)
        {
            yield return new WaitForSeconds(0.2f);
            transform.DOMove(distanceRank[i], 0.3f);
        }

    }
}
