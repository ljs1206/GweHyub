using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{

    [SerializeField]
    private Items items;

    public Image[] images;

    private List<Sprite> readySprite = new();

    public void LevelUpF()
    {
        readySprite.Clear();

        int rand = 0;
        for(int i = 0; i < images.Length; i++)
        {
            rand = 0;
            rand = Random.Range(0, items._items.Length);

            while(readySprite.IndexOf(items._items[rand].sprite) != -1) 
            {
                rand = Random.Range(0, items._items.Length);
            }

            images[i].sprite = items._items[rand].sprite;
            readySprite.Add(images[i].sprite);
        }
    }
}
