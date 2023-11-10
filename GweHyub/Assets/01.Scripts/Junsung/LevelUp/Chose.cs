using UnityEngine;
using UnityEngine.UI;

public class Chose : MonoBehaviour
{
    [SerializeField]
    private GameObject Skill;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void isClick()
    {
        
    }
}
