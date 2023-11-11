using UnityEngine;

public class HpBar : MonoBehaviour
{
    private Transform _barTrm;
    private SpriteRenderer _barRenderer;

    [SerializeField] private Color _color1;
    [SerializeField] private Color _color2;

    private void Awake()
    {
        _barTrm = transform.Find("Hp");
        _barRenderer = _barTrm.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void SetBar(float hp)
    {
        _barTrm.localScale = new Vector3(hp, _barTrm.localScale.y, 1);
        _barRenderer.color = Color.Lerp(_color2, _color1, hp);
    }
}