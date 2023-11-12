using UnityEngine;
using UnityEngine.UI;

public class LBTN : MonoBehaviour
{
    [SerializeField]
    private PlayerLevel level;

    private Image image;

    private void Awake()
    {
        image = transform.Find("image").GetComponent<Image>();
    }


    public void FBTN()
    {
        if (itemManager.instance.currentItems.Count < 3)
        {
            itemManager.instance.currentItems.Add(level.currnetSprite[image.sprite.name]);
        }
        else
        {
            itemManager.instance.currentItems[level.currnetSprite[]);
        }
    }
}
