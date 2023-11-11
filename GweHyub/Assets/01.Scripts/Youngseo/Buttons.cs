using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}