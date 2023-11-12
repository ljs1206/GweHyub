using System;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class YSUIManager : MonoBehaviour
{
    public static YSUIManager Instance;
    private Image _fadePanel;
    [SerializeField] private TMP_Text _timerText;

    private void Awake()
    {
        Instance ??= this;
        Transform canvasTrm = GameObject.Find("Canvas").transform;

        _fadePanel = canvasTrm.Find("FadePanel").GetComponent<Image>();
    }

    private void Start()
    {
        _fadePanel.DOFade(0, 1);
    }

    public void DOFadePanel(float value, float duration)
    {
        _fadePanel.DOFade(value, duration);
    }

    private void Update()
    {
        if (_timerText is not null) _timerText.text = $"Until the battle\n<color=#D60C04>{9 - (int)Time.time / 60}:{59 - (int)Time.time % 60}</color>";
    }
}
