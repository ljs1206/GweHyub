using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void OnClickStart()
    {
        StartCoroutine(DelayStart());
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    private IEnumerator DelayStart()
    {
        YSUIManager.Instance.DOFadePanel(1, 1);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}