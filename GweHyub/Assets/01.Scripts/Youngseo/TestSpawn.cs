using System;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _orb;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject obj = Instantiate(_orb, Vector3.zero, Quaternion.identity);
            Destroy(obj, 3);
        }
    }
}