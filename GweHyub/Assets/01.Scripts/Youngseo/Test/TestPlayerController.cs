using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(x, y).normalized * (Time.deltaTime * _speed);
    }
}