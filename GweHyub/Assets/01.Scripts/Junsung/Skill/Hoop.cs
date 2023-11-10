using System.Collections;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    private void Start()
    {
        StartCoroutine(Run());
    }

    private void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * speed));
    }

    private IEnumerator Run()
    {
        while(true)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 361));

            yield return new WaitForSeconds(1.5f);
        }
    }
}
