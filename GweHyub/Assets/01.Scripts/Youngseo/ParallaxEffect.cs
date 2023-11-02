using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Transform _mainCamTrm;

    private Vector3 _textureUnitSize;

    private void Awake()
    {
        _mainCamTrm = Camera.main.transform;

        Sprite s = GetComponent<SpriteRenderer>().sprite;
        Texture2D t = s.texture;

        _textureUnitSize.x = t.width / s.pixelsPerUnit;
        _textureUnitSize.y = t.height / s.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        Vector3 camPos = _mainCamTrm.position;
        Vector3 offset = camPos - transform.position;
        if (Mathf.Abs(offset.x) >= _textureUnitSize.x || 
            Mathf.Abs(offset.y) >= _textureUnitSize.y)
        {
            float offsetX = offset.x % _textureUnitSize.x;
            float offsetY = offset.y % _textureUnitSize.y;
            transform.position = new Vector3(camPos.x - offsetX, camPos.y - offsetY);
        }
    }
}