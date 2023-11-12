using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{

    [SerializeField]
    private Items items;

    public Image[] images;
    public TextMeshProUGUI[] textMeshPros;

    private List<Sprite> readySprite = new();
    public Dictionary<string, item> currnetSprite = new();

    public void LevelUpF()
    {
        currnetSprite.Clear();
        readySprite.Clear();

        if (itemManager.instance.currentItems.Count >= 3)
        {
            for(int i = 0; itemManager.instance.currentItems.Count < 3; i++)
            {
                images[i].sprite = itemManager.instance.currentItems[i].sprite;
                textMeshPros[i].text = itemManager.instance.currentItems[i].name;
                textMeshPros[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
                = itemManager.instance.currentItems[i].tooltip;
            }
        }

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
            currnetSprite.Add(images[i].sprite.name, items._items[rand]);
            textMeshPros[i].text = itemManager.instance.currentItems[i].name;
            textMeshPros[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
            = itemManager.instance.currentItems[i].tooltip;
        }
    }
}
