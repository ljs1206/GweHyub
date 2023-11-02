using UnityEngine;
using System.Collections;

public class _Jwibulnori : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;

    private void Update()
    {
        transform.Rotate(-Vector3.forward, Time.deltaTime * rotateSpeed);
    }
}
