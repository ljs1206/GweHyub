using UnityEngine;

public class TestRotate : MonoBehaviour
{
    [SerializeField] private float _startDeg;
    [SerializeField] private float _speed = 2f;
    
    private void Update()
    {
        float theta = _startDeg * Mathf.Deg2Rad + Time.time * _speed;
        //transform.position = new Vector3(2 * Mathf.Cos(theta) + 5 * Mathf.Cos(2 * theta / 3),
        //    2 * Mathf.Sin(theta) - 5 * Mathf.Sin(2 * theta / 3)) / 2;
        
        transform.position = transform.TransformDirection(new Vector3(Mathf.Sin(theta), Mathf.Cos(theta) / 2) * 3);
    }
}